using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
using ComplaintManagementSystem.Forms.LoginAndSignUpForms;
using ComplaintManagementSystem.Models;
using Microsoft.IdentityModel.Tokens;
using ScottPlot.Colormaps;
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
using System.Xml.Linq;
using static ScottPlot.Generate;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ComplaintManagementSystem.Forms.AdminForms
{
    public partial class EmployeesForm : Form
    {
        private readonly ComplaintSystemContext _context;
        private int _empId;
        EmployeeController employeeController;
        CityController cityController;
        DepartmentController departmentController;

        bool cFlag = true, dFlag = true;


        #region Ctor
        public EmployeesForm(ComplaintSystemContext context, int empId)
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

        #region Form Load
        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            var _emp = employeeController.GetEmployeeById(_empId);
            labelUserName.Text = "Welcome " + _emp.Account.Username;
            try
            {
                dataGridViewEmployee.DataSource = null;

                // Populate Cities in comboBoxCity
                var cities = cityController.GetAllCities();
                cities.Insert(0, new City { Id = 0, Name = "All" }); // Add "All" option
                comboBoxCityFilter.DataSource = cities;
                comboBoxCityFilter.DisplayMember = "Name";
                comboBoxCityFilter.ValueMember = "Id";

                // Populate Departments in comboBoxDepFilter
                var departments = departmentController.GetAllDepartments();
                departments.Insert(0, new Department { Id = 0, Name = "All" }); // Add "All" option
                comboBoxDepFilter.DataSource = departments;
                comboBoxDepFilter.DisplayMember = "Name";
                comboBoxDepFilter.ValueMember = "Id";

                cFlag = false; dFlag = false;

                RefreshEmpList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Employees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Selected Index Changed
        private void comboBoxCityFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshEmpList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading complaints: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxDepFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshEmpList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading complaints: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region InitializeDataGridView
        private void InitializeDataGridView()
        {
            dataGridViewEmployee.AutoGenerateColumns = true; // Automatically generate columns

            // Ensure the DataGridView is editable
            dataGridViewEmployee.ReadOnly = false;
            dataGridViewEmployee.AllowUserToAddRows = false;

            if (!dataGridViewEmployee.Columns.Contains("EditButton"))
            {
                // Add Edit Button
                var editButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Edit",
                    Name = "EditButton",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewEmployee.Columns.Add(editButtonColumn);
            }

            if (!dataGridViewEmployee.Columns.Contains("DeleteButton"))
            {
                // Add Delete Button
                var deleteButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Delete",
                    Name = "DeleteButton",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewEmployee.Columns.Add(deleteButtonColumn);
            }
        }
        #endregion

        #region Cell Click
        private void dataGridViewEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row

            var selectedEmpId = Convert.ToInt32(dataGridViewEmployee.Rows[e.RowIndex].Cells["Id"].Value);

            if (dataGridViewEmployee.Columns[e.ColumnIndex].Name == "EditButton")
            {
                // Handle Edit Button Click
                EditEmp(selectedEmpId);
            }
            else if (dataGridViewEmployee.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                // Handle Delete Button Click
                DeleteEmp(selectedEmpId);
            }
        }
        #endregion

        #region Edit Emp
        private void EditEmp(int selectedEmpId)
        {
            try
            {
                // Get the row being edited
                var row = dataGridViewEmployee.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => Convert.ToInt32(r.Cells["Id"].Value) == selectedEmpId);

                if (row == null) return;

                // Validate the row data
                if (!ValidateEmpRow(row)) return;

                var _emp = employeeController.GetEmployeeById(selectedEmpId);


                string newName = row.Cells["Name"]?.Value.ToString().Trim();
                string newSalary = row.Cells["Salary"]?.Value.ToString().Trim();
                string newPhone = row.Cells["PhoneNumber"]?.Value.ToString().Trim();
                int newCity = (int)row.Cells["CityId"].Value;
                int? newDep = (int)row.Cells["DepartmentId"].Value;
                var date = _emp.DateOfBirth;


                decimal.TryParse(row.Cells["salary"].Value.ToString(), out decimal parsedSalary);

                // Update employee information
                var updatedEmployee = new Employee
                {
                    Name = newName,
                    PhoneNumber = newPhone,
                    Salary = parsedSalary,
                    DateOfBirth = date,
                    CityId = newCity,
                    DepartmentId = newDep
                };

                employeeController.UpdateEmployee(selectedEmpId, updatedEmployee);

                MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the DataGridView
                RefreshEmpList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ValidateEmpRow
        private bool ValidateEmpRow(DataGridViewRow row)
        {
            // Check for empty fields
            if (string.IsNullOrEmpty(row.Cells["Name"]?.Value.ToString()) ||
                string.IsNullOrEmpty(row.Cells["PhoneNumber"]?.Value.ToString()) ||
                string.IsNullOrEmpty(row.Cells["Salary"]?.Value.ToString()))
            {
                MessageBox.Show("All fields are required. Please fill in all the details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate phone number format (11 to 15 characters)
            if (row.Cells["PhoneNumber"].Value.ToString().Length < 11 || row.Cells["PhoneNumber"].Value.ToString().Length > 15)
            {
                MessageBox.Show("Phone number must be between 11 and 15 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate salary
            if (!decimal.TryParse(row.Cells["salary"].Value.ToString(), out decimal parsedSalary) || parsedSalary <= 0)
            {
                MessageBox.Show("Salary must be a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion

        #region Delete Emp
        private void DeleteEmp(int selectedEmpId)
        {
            var result = MessageBox.Show("Are you sure you want to delete this Employee?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        // Get the row being edited
                        var row = dataGridViewEmployee.Rows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(r => Convert.ToInt32(r.Cells["Id"].Value) == selectedEmpId);

                        if (row == null) return;

                        var _selectedEmp = employeeController.GetEmployeeById(selectedEmpId);

                        // Delete account
                        AccountController accountController = new AccountController(_context);
                        accountController.DeleteAccount(_selectedEmp.AccountId);


                        // Delete the citizen record
                        employeeController.DeleteEmployee(selectedEmpId);

                        // Commit the transaction if all operations succeed
                        transaction.Commit();

                        MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the DataGridView after deletion
                        RefreshEmpList();
                    }
                    catch (Exception ex)
                    {
                        // Roll back the transaction if any other error occurs
                        transaction.Rollback();
                        MessageBox.Show("Error deleting Employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region RefreshComplaintList
        private void RefreshEmpList()
        {
            if (cFlag || dFlag)
                return;

            int? selectedCityId = (int)comboBoxCityFilter.SelectedValue == 0 ? null : (int)comboBoxCityFilter.SelectedValue;
            int? selectedDepId = (int)comboBoxDepFilter.SelectedValue == 0 ? null : (int)comboBoxDepFilter.SelectedValue;

            var emps = employeeController.GetFilteredEmployees(selectedCityId, selectedDepId, "Employee");

            // Set the data source for the DataGridView
            dataGridViewEmployee.DataSource = emps;

            // Make certain columns read-only
            dataGridViewEmployee.Columns["Age"].ReadOnly = true;
            dataGridViewEmployee.Columns["DateOfBirth"].ReadOnly = true;

            // Hide some unnecessary columns
            dataGridViewEmployee.Columns["Id"].Visible = false;
            dataGridViewEmployee.Columns["IsDeleted"].Visible = false;
            dataGridViewEmployee.Columns["CityId"].Visible = false;
            dataGridViewEmployee.Columns["DepartmentId"].Visible = false;
            dataGridViewEmployee.Columns["AccountId"].Visible = false;
            dataGridViewEmployee.Columns["City"].Visible = false;
            dataGridViewEmployee.Columns["Department"].Visible = false;
            dataGridViewEmployee.Columns["Account"].Visible = false;
            dataGridViewEmployee.Columns["Complaints"].Visible = false;

            if (!dataGridViewEmployee.Columns.Contains("CityComboBox"))
            {
                // Create and add combo boxes for City and Department columns
                DataGridViewComboBoxColumn cityComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    HeaderText = "City",
                    Name = "CityComboBox",
                    DataSource = cityController.GetAllCities(), // Get the cities from the controller
                    DisplayMember = "Name", // Assuming "CityName" is the name of the city in your data
                    ValueMember = "Id", // Assuming "CityId" is the ID of the city in your data
                    DataPropertyName = "CityId" // Bind this column to the "CityId" property of your complaint
                };
                dataGridViewEmployee.Columns.Add(cityComboBoxColumn);
            }

            if (!dataGridViewEmployee.Columns.Contains("DepartmentComboBox"))
            {
                DataGridViewComboBoxColumn departmentComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    HeaderText = "Department",
                    Name = "DepartmentComboBox",
                    DataSource = departmentController.GetAllDepartments(), // Get the departments from the controller
                    DisplayMember = "Name", // Assuming "DepartmentName" is the name of the department
                    ValueMember = "Id", // Assuming "DepartmentId" is the ID of the department
                    DataPropertyName = "DepartmentId" // Bind this column to the "DepartmentId" property of your complaint
                };
                dataGridViewEmployee.Columns.Add(departmentComboBoxColumn);
            }

            // Initialize the DataGridView's other settings
            InitializeDataGridView();
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
