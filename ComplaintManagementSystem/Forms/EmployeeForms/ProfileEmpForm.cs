using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
using ComplaintManagementSystem.Forms.CitizenForms;
using ComplaintManagementSystem.Forms.LoginAndSignUpForms;
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

namespace ComplaintManagementSystem.Forms.EmployeeForms
{
    public partial class ProfileEmpForm : Form
    {
        private readonly ComplaintSystemContext _context;

        private int _empId;

        EmployeeController employeeController;

        #region Ctor
        public ProfileEmpForm(ComplaintSystemContext context, int empId)
        {
            InitializeComponent();
            _context = context;
            _empId = empId;
            employeeController = new EmployeeController(_context);
            this.FormClosing += ExitFormClosing;
        }
        #endregion

        #region Closing Event
        private void ExitFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Close Button
        private void butClose_Click(object sender, EventArgs e)
        {
            HomePageEmployeeForm homePage = new HomePageEmployeeForm(_context, _empId);
            this.Hide();
            homePage.Show();
        }
        #endregion

        #region Edit Button
        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                string newName = txtName.Text.Trim();
                string newPhone = txtPhone.Text.Trim();
                string currentPassword = txtCurrentPassword.Text.Trim();
                string newPassword = txtNewPassword.Text.Trim();

                if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newPhone))
                {
                    MessageBox.Show("Name and phone number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate phone number format (11 to 15 characters)
                if (newPhone.Length < 11 || newPhone.Length > 15)
                {
                    throw new ArgumentException("Phone number must be between 11 and 15 characters.");
                }

                if (!string.IsNullOrEmpty(newPassword) && string.IsNullOrEmpty(currentPassword))
                {
                    MessageBox.Show("Please enter your current password to set a new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var _emp = employeeController.GetEmployeeById(_empId);

                // Update citizen information
                var updatedCEmployee = new Employee
                {
                    Name = newName,
                    PhoneNumber = newPhone,
                    Salary = _emp.Salary,
                    DateOfBirth = _emp.DateOfBirth,
                    CityId = _emp.CityId,
                    DepartmentId = _emp.DepartmentId
                };


                employeeController.UpdateEmployee(_emp.Id, updatedCEmployee);

                // Update password if provided
                if (!string.IsNullOrEmpty(newPassword))
                {
                    AccountController accountController = new AccountController(_context);
                    accountController.UpdatePassword(_emp.AccountId, currentPassword, newPassword);
                }

                MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                InitialLoad();

            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Form Load
        private void ProfileEmpForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _emp = employeeController.GetEmployeeById(_empId);
                labelUserName.Text = "Welcome " + _emp.Account.Username;
                InitialLoad();
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Initial Load
        private void InitialLoad()
        {
            var _emp = employeeController.GetEmployeeById(_empId);
            txtUserName.Text = _emp.Account.Username;
            txtName.Text = _emp.Name;
            txtPhone.Text = _emp.PhoneNumber;
            txtSalary.Text = _emp.Salary.ToString();
            txtAge.Text = _emp.Age.ToString();
            txtDateOfBirth.Text = _emp.DateOfBirth.ToString("dd-MM-yyyy");
            txtCity.Text = _emp.City.Name;
            txtDepartment.Text = _emp.Department.Name;
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
        }
        #endregion

        #region HomePage Button
        private void butHomePage_Click(object sender, EventArgs e)
        {

            HomePageEmployeeForm homePage = new HomePageEmployeeForm(_context, _empId);
            this.Hide();
            homePage.Show();
        }
        #endregion

        #region Profile Button
        private void butEditProfile_Click(object sender, EventArgs e)
        {
            ProfileEmpForm profileForm = new ProfileEmpForm(_context, _empId);
            this.Hide();
            profileForm.Show();
        }
        #endregion

        #region Complaints Buuton
        private void butComplaints_Click(object sender, EventArgs e)
        {

            ComplaintsEmpForm complaintsEmpForm = new ComplaintsEmpForm(_context, _empId);
            this.Hide();
            complaintsEmpForm.Show();
        }
        #endregion


        #region Password Show / Hide
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.PasswordChar == '\0')
            {
                button2.BringToFront();
                txtCurrentPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.PasswordChar == '*')
            {
                button1.BringToFront();
                txtCurrentPassword.PasswordChar = '\0';
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.PasswordChar == '\0')
            {
                button3.BringToFront();
                txtNewPassword.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.PasswordChar == '*')
            {
                button4.BringToFront();
                txtNewPassword.PasswordChar = '\0';
            }
        }
        #endregion

        #region Logout Button
        private void butLogout_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            this.Hide();
            welcomeForm.Show();
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            this.Hide();
            welcomeForm.Show();
        }
        #endregion



    }
}
