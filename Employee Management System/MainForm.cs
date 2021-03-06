using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class MainForm : Form
    {
        public static EmployeeToMatch emp;
        public DataView currentView;
        private DataTable datatable;
        private DataView standardView;
        private ExportToFiles<CSV_IO> file_list = new ExportToFiles<CSV_IO>();

        private string filepath = @"C:\Users\37544\source\repos\Employee Management System\Employee Management System\kirans.csv";

        public MainForm()
        {
            InitializeComponent();
            datatable = new CSV_IO(filepath).readCSV;
            standardView = datatable.DefaultView;
            gridEmployees.DataSource = standardView;
            currentView = standardView;
            file_list.files = new List<string> { filepath };
            file_list.file_writer = new CSV_IO(filepath);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
           
        private void btnSpecificEmps_Click(object sender, EventArgs e)
        {
            var searchform = new SearchForm();

            searchform.ShowDialog();

            List<string> allParams = new List<string>();
            //here add fields you want to filter and their impact on rowview in string form

            if (emp.Id != "") allParams.Add(String.Format("Id = {0}", emp.Id));
            if (emp.FullName != "") allParams.Add(String.Format("FullName = '{0}'", emp.FullName));
            if (emp.Address != "") allParams.Add(String.Format("Address = '{0}'", emp.Address));
            if (emp.Designation != "") allParams.Add(String.Format("Designation = '{0}'", emp.Designation));
            if (emp.Department != "") allParams.Add(String.Format("Department = '{0}'", emp.Department));
            if (emp.HoursWorked != "") allParams.Add(String.Format("HoursWorked = '{0}'", emp.HoursWorked));
            if (emp.Wage != "") allParams.Add(String.Format("Wage = '{0}'", emp.Wage));

            string finalFilter = string.Join(" and ", allParams);
            datatable.DefaultView.RowFilter = "(" + finalFilter + ")";
            
           
        }

        private bool isDeleting;
        private void btnDeleteEmps_Click(object sender, EventArgs e)
        {
            isDeleting = !isDeleting;
            gridEmployees.AllowUserToDeleteRows = isDeleting;

            if (gridEmployees.AllowUserToDeleteRows) btnDeleteEmps.Text = "Stop deleting";
            else btnDeleteEmps.Text = "Delete Employee";
        }

        
        private bool isChanging = false;

        private void btnAddChangeEmps_Click(object sender, EventArgs e)
        {
            isChanging = !isChanging;
            gridEmployees.ReadOnly = !isChanging;
            gridEmployees.AllowUserToAddRows = isChanging;

            if (!gridEmployees.ReadOnly) btnAddChangeEmps.Text = "Stop changing";
            else btnAddChangeEmps.Text = "Add/Change Employees' Data";
        }

        private void btnAllEmps_Click(object sender, EventArgs e)
        {
            currentView.RowFilter = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //(new CSV_IO(filepath)).ExportDatatableToFile(filepath, datatable);
            file_list.Export(datatable);
        }




        /*
        private void btnModifyEmps_Click(object sender, EventArgs e)
        {
            isModifying = !isModifying;
            gridEmployees.ReadOnly = !isModifying;

            if (!gridEmployees.ReadOnly) btnChangeEmps.Text = "Stop changing";
            else btnChangeEmps.Text = "Change Employees' Data";

        }

        private void btnAddEmps_Click(object sender, EventArgs e)
        {
            isAdding = !isAdding;
            gridEmployees.Rows[gridEmployees.RowCount - 1].ReadOnly = !isAdding;//AllowUserToAddRows = isAdding;

            if (gridEmployees.AllowUserToAddRows) btnAddChangeEmps.Text = "Stop adding";
            else btnAddChangeEmps.Text = "Add Employee";
        }
        */
    }

    public class EmployeeToMatch
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Wage { get; set; }
        public string HoursWorked { get; set; }
    }


}
