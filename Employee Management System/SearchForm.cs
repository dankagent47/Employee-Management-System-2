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
            emp.Id = textId.Text; emp.FullName = 
            emp.Id = textId.Text;
            emp.FullName = textFullName.Text;
            emp.Address = textAddress.Text;
            emp.Contact = textContact.Text;
            emp.Email = textEmail.Text;
            emp.Designation = textDesignation.Text;
            emp.Department = textDepartment.Text;
            emp.WageRate = textWageRate.Text;

            MainForm.employeeToMatch = emp;
        }
    }
}
