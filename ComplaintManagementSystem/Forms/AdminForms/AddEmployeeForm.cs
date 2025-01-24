using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ComplaintManagementSystem.Forms.AdminForms
{
    public partial class AddEmployeeForm : Form
    {
        private readonly ComplaintSystemContext _context;
        EmployeeController employeeController;
        AccountController accountController;
        CityController cityController;
        DepartmentController departmentController;

        private int _empId;

        #region Ctor
        public AddEmployeeForm(ComplaintSystemContext context, int empId)
        {
            InitializeComponent();
            _context = context;
            _empId = empId;
            employeeController = new EmployeeController(_context);
            accountController = new AccountController(_context);
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

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            var _emp = employeeController.GetEmployeeById(_empId);
            labelUserName.Text = "Welcome " + _emp.Account.Username;

            // Populate Cities in comboBoxCity
            var cities = cityController.GetAllCities();
            comboBoxCity.DataSource = cities;
            comboBoxCity.DisplayMember = "Name";
            comboBoxCity.ValueMember = "Id";
            comboBoxCity.SelectedIndex = 5;

            // Populate Departments in comboBoxCategory
            var departments = departmentController.GetAllDepartments();
            comboBoxDep.DataSource = departments;
            comboBoxDep.DisplayMember = "Name";
            comboBoxDep.ValueMember = "Id";
            comboBoxDep.SelectedIndex = -1;

            List<string> roles = ["Employee", "Admin"];
            comboBoxRole.DataSource = roles;

        }


        #region Add Button
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                string userName = txtUserName.Text.Trim();
                string name = txtName.Text.Trim();
                string salary = txtSalary.Text.Trim();
                string phone = txtPhone.Text.Trim();
                int city = (int)comboBoxCity.SelectedValue;
                int? dep = comboBoxDep.SelectedIndex == -1 ? null : (int)comboBoxDep.SelectedValue;
                DateTime dateTime = dateTimePicker1.Value;
                string password = txtPassword.Text.Trim();
                string role = comboBoxRole.SelectedValue.ToString();

                // Check for empty fields
                if (string.IsNullOrEmpty(name) ||
                    string.IsNullOrEmpty(userName) ||
                    string.IsNullOrEmpty(phone) ||
                    string.IsNullOrEmpty(salary) ||
                    string.IsNullOrEmpty(password) ||
                    comboBoxCity.SelectedIndex == -1 ||
                    dateTime == null)
                {
                    MessageBox.Show("All fields are required. Please fill in all the details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate phone number format (11 to 15 characters)
                if (phone.Length < 11 || phone.Length > 15)
                {
                    MessageBox.Show("Phone number must be between 11 and 15 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate salary
                if (!decimal.TryParse(salary, out decimal parsedSalary) || parsedSalary <= 0)
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

                accountController.Register(userName, password, role);

                var account = accountController.GetAccountByUsername(userName);

                if (account == null)
                {
                    throw new InvalidOperationException("Account registration failed.");
                }

                var employee = new Employee
                {
                    Name = name,
                    PhoneNumber = phone,
                    Salary = parsedSalary,
                    DateOfBirth = dateTime,
                    CityId = city,
                    DepartmentId = dep,
                    AccountId = account.Id
                };

                employeeController.AddEmployee(employee);


                MessageBox.Show("Employee Added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUserName.Text = "";
                txtName.Text = "";
                txtSalary.Text = "";
                txtPhone.Text = "";
                comboBoxCity.SelectedIndex = 5;
                comboBoxDep.SelectedIndex = -1;
                txtPassword.Text = "";
                comboBoxRole.SelectedIndex = 0;
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

        #region Logout Button
        private void butLogout_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            this.Hide();
            welcomeForm.Show();
        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            this.Hide();
            welcomeForm.Show();
        }
        #endregion

    }
}
