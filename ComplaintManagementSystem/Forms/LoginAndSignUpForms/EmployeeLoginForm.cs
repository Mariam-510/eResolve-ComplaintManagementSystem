using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
using ComplaintManagementSystem.Forms.CitizenForms;
using ComplaintManagementSystem.Forms.AdminForms;
using ComplaintManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComplaintManagementSystem.Forms.EmployeeForms;

namespace ComplaintManagementSystem.Forms.LoginAndSignUpForms
{
    public partial class EmployeeLoginForm : Form
    {
        private readonly ComplaintSystemContext _context;
        #region Ctir
        public EmployeeLoginForm(ComplaintSystemContext context)
        {
            InitializeComponent();
            _context = context;
            this.FormClosing += ExitFormClosing;
        }
        #endregion

        #region Closing Event
        private void ExitFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Login Button
        private void butLogin_Click(object sender, EventArgs e)
        {
            AccountController accountController = new AccountController(_context);
            EmployeeController employeeController = new EmployeeController(_context);

            string username = txtUserName.Text;
            string password = txtPassword.Text;

            try
            {
                Account account = accountController.Login(username, password);

                // Ensure the account role is either "Admin" or "Employee"
                if (account.Role == "Admin")
                {
                    var _employee = employeeController.GetEmployeeByAccountId(account.Id);

                    HomePageAdminForm homePage = new HomePageAdminForm(_context, _employee.Id);
                    this.Hide();
                    homePage.Show();
                }
                else if (account.Role == "Employee")
                {
                    var _employee = employeeController.GetEmployeeByAccountId(account.Id);

                    HomePageEmployeeForm homePage = new HomePageEmployeeForm(_context, _employee.Id);
                    this.Hide();
                    homePage.Show();
                }
                else
                {
                    // If the role is neither Admin nor Employee
                    MessageBox.Show("You are not authorized to log in with this account role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region Password Show / Hide
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                button2.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                button1.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }
        #endregion

        #region Colse Button
        private void butClose_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            this.Hide();
            welcomeForm.Show();
        }
        #endregion

    }
}
