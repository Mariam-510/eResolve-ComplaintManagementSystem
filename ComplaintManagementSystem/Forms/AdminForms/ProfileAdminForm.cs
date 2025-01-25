using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
using ComplaintManagementSystem.Forms.LoginAndSignUpForms;
using ComplaintManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComplaintManagementSystem.Forms.AdminForms
{
    public partial class ProfileAdminForm : Form
    {
        private readonly ComplaintSystemContext _context;

        private int _empId;

        EmployeeController employeeController;
        CityController cityController;
        DepartmentController departmentController;

        #region Ctor
        public ProfileAdminForm(ComplaintSystemContext context, int empId)
        {
            InitializeComponent();
            _context = context;
            _empId = empId;
            employeeController = new EmployeeController(_context);
            cityController = new CityController(_context);
            departmentController = new DepartmentController(_context);
            this.FormClosing += ExitFormClosing;
        }
        #endregion

        #region Closing Event
        private void ExitFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region HomePage Button
        private void butHomePage_Click(object sender, EventArgs e)
        {

            HomePageAdminForm homePage = new HomePageAdminForm(_context, _empId);
            this.Hide();
            homePage.Show();
        }
        #endregion

        #region Profile Button
        private void butEditProfile_Click(object sender, EventArgs e)
        {
            ProfileAdminForm profileForm = new ProfileAdminForm(_context, _empId);
            this.Hide();
            profileForm.Show();
        }
        #endregion

        #region Employees Button
        private void butEmployees_Click(object sender, EventArgs e)
        {
            EmployeesForm employeesForm = new EmployeesForm(_context, _empId);
            this.Hide();
            employeesForm.Show();
        }
        #endregion

        #region Complaints Buuton
        private void butComplaints_Click(object sender, EventArgs e)
        {
            ComplaintsAdminForm complaintsAdminForm = new ComplaintsAdminForm(_context, _empId);
            this.Hide();
            complaintsAdminForm.Show();
        }
        #endregion

        #region Add Emp Button
        private void butAddEmp_Click(object sender, EventArgs e)
        {

            AddEmployeeForm addEmployeeForm = new AddEmployeeForm(_context, _empId);
            this.Hide();
            addEmployeeForm.Show();
        }
        #endregion

        #region Edit Button
        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                string newName = txtName.Text.Trim();
                string newSalary = txtSalary.Text.Trim();
                string newPhone = txtPhone.Text.Trim();
                int newCity = (int)comboBoxCity.SelectedValue;
                int? newDep = comboBoxDep.SelectedIndex == -1 ? null : (int)comboBoxDep.SelectedValue;
                DateTime dateTime = dateTimePicker1.Value;
                string currentPassword = txtCurrentPassword.Text.Trim();
                string newPassword = txtNewPassword.Text.Trim();

                // Check for empty fields
                if (string.IsNullOrEmpty(newName) ||
                    string.IsNullOrEmpty(newPhone) ||
                    string.IsNullOrEmpty(newSalary) ||
                    comboBoxCity.SelectedIndex == -1 ||
                    dateTime == null)
                {
                    MessageBox.Show("All fields are required. Please fill in all the details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate phone number format (11 to 15 characters)
                if (newPhone.Length < 11 || newPhone.Length > 15)
                {
                    MessageBox.Show("Phone number must be between 11 and 15 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate salary
                if (!decimal.TryParse(newSalary, out decimal parsedSalary) || parsedSalary <= 0)
                {
                    MessageBox.Show("Salary must be a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate age (18 to 60 years old)
                int age = DateTime.Now.Year - dateTime.Year;
                if (dateTime > DateTime.Now.AddYears(-age)) age--; // Adjust for birth date not yet reached this year

                if (age < 18 || age > 60)
                {
                    MessageBox.Show("Age must be between 18 and 60 years old.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrEmpty(newPassword) && string.IsNullOrEmpty(currentPassword))
                {
                    MessageBox.Show("Please enter your current password to set a new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var _emp = employeeController.GetEmployeeById(_empId);

                // Update employee information
                var updatedEmployee = new Employee
                {
                    Name = newName,
                    PhoneNumber = newPhone,
                    Salary = parsedSalary,
                    DateOfBirth = dateTime,
                    CityId = newCity,
                    DepartmentId = newDep
                };

                employeeController.UpdateEmployee(_emp.Id, updatedEmployee);

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
        private void ProfileAdminForm_Load(object sender, EventArgs e)
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

            // Populate Cities in comboBoxCity
            var cities = cityController.GetAllCities();
            comboBoxCity.DataSource = cities;
            comboBoxCity.DisplayMember = "Name";
            comboBoxCity.ValueMember = "Id";

            // Populate Departments in comboBoxCategory
            var departments = departmentController.GetAllDepartments();
            comboBoxDep.DataSource = departments;
            comboBoxDep.DisplayMember = "Name";
            comboBoxDep.ValueMember = "Id";
            comboBoxDep.SelectedIndex = -1;

            var _emp = employeeController.GetEmployeeById(_empId);
            comboBoxCity.SelectedValue = _emp.CityId;
            if(_emp.DepartmentId != null)
                comboBoxDep.SelectedValue = _emp.DepartmentId;

            txtUserName.Text = _emp.Account.Username;
            txtName.Text = _emp.Name;
            txtPhone.Text = _emp.PhoneNumber;
            txtSalary.Text = _emp.Salary.ToString();
            txtAge.Text = _emp.Age.ToString();
            dateTimePicker1.Value = _emp.DateOfBirth;
            comboBoxDep.SelectedItem = _emp.DepartmentId;
            comboBoxCity.SelectedItem = _emp.CityId;
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
        }
        #endregion

        #region Close Button
        private void butClose_Click(object sender, EventArgs e)
        {

            HomePageAdminForm homePage = new HomePageAdminForm(_context, _empId);
            this.Hide();
            homePage.Show();
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
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            this.Hide();
            welcomeForm.Show();
        }
        #endregion

    }
}
