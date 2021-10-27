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
    public partial class SearchForm : Form
    {
        
        public SearchForm()
        {
            InitializeComponent();
 
        
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

            EmployeeToMatch emp = new EmployeeToMatch();
              
            emp.Id = textId.Text;
            emp.FullName = tFullName.Text;
            emp.Address = tAddress.Text;
            emp.Contact = tContact.Text;
            emp.Email = tEmail.Text;
            emp.Designation = tDesignation.Text;
            emp.Department = tDepartment.Text;
            emp.Wage = tWage.Text;
            emp.HoursWorked = tHoursWorked.Text;

            MainForm.emp = emp;
            this.Close();
        }

        private void textHoursWorked_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
