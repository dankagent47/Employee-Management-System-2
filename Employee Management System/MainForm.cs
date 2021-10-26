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
        public static EmployeeToMatch employeeToMatch;
        public DataView currentView;
        private DataTable datatable;
        private DataView standardView;

        private string filepath = @"C:\Users\37544\source\repos\Employee Management System\Employee Management System\kirans.csv";

        public MainForm()
        {
            InitializeComponent();
            datatable = new CSVtoDataTable.ReadCSV(filepath).readCSV;
            standardView = datatable.DefaultView;
            gridEmployees.DataSource = standardView;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*
        private void gridWorkers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gridEmployees.Rows[e.RowIndex].ReadOnly = true;

            if (gridEmployees.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)

            {

                gridEmployees.Rows[e.RowIndex].ReadOnly = isAdding ? false : true;

            }
        }
        */

        private void btnSpecificEmps_Click(object sender, EventArgs e)
        {
            var searchform = new SearchForm();
            searchform.ShowDialog();

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
        public string WageRate { get; set; }
    }
}
