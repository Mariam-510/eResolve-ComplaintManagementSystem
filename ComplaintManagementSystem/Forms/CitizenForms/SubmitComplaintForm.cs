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
using System.Xml.Linq;

namespace ComplaintManagementSystem.Forms.CitizenForms
{
    public partial class SubmitComplaintForm : Form
    {
        private readonly ComplaintSystemContext _context;

        private int _citizenId;
        CitizenController citizenController;
        CityController cityController;
        DepartmentController departmentController;
        ComplaintController complaintController;

        #region Ctor
        public SubmitComplaintForm(ComplaintSystemContext context, int citizenId)
        {
            InitializeComponent();
            _context = context;
            _citizenId = citizenId;
            citizenController = new CitizenController(_context);
            cityController = new CityController(_context);
            departmentController = new DepartmentController(_context);
            complaintController = new ComplaintController(_context);
            this.FormClosing += ExitFormClosing;
        }
        #endregion

        #region Closing Event
        private void ExitFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Load Form
        private void SubmitComplaintForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Populate PhoneNumber
                var _citizen = citizenController.GetCitizenById(_citizenId);
                labelUserName.Text = "Welcome " + _citizen.Account.Username;
                txtPhone.Text = _citizen.PhoneNumber;

                // Populate Cities in comboBoxCity
                var cities = cityController.GetAllCities();
                comboBoxCity.DataSource = cities;
                comboBoxCity.DisplayMember = "Name";
                comboBoxCity.ValueMember = "Id";
                comboBoxCity.SelectedIndex = 5;

                // Populate Departments in comboBoxCategory
                var departments = departmentController.GetAllDepartments();
                comboBoxCategory.DataSource = departments;
                comboBoxCategory.DisplayMember = "Name";
                comboBoxCategory.ValueMember = "Id";
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

        #region Sumbit Button
        private void butSumbit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Complaint Title is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxCity.SelectedValue == null)
                {
                    MessageBox.Show("Please select a city.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxCategory.SelectedValue == null)
                {
                    MessageBox.Show("Please select a category (department).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.Text.Length < 11 || txtPhone.Text.Length > 15)
                {
                    MessageBox.Show("Phone number must be between 11 and 15 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Complaint Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a new Complaint object
                var complaint = new Complaint
                {
                    Title = txtTitle.Text.Trim(),
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(), // Set to null if empty
                    PhoneNumber = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    CityId = (int)comboBoxCity.SelectedValue,
                    DepartmentId = (int)comboBoxCategory.SelectedValue,
                    CitizenId = _citizenId
                };

                // Add the complaint using ComplaintController
                complaintController.AddComplaint(complaint);

                // Show success message
                MessageBox.Show("Complaint submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form fields for new input
                ClearFormFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while submitting the complaint: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ClearFormFields
        private void ClearFormFields()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            comboBoxCity.SelectedIndex = 5;
            comboBoxCategory.SelectedIndex = 0;
        }

        #endregion

        #region Close Button
        private void butClose_Click(object sender, EventArgs e)
        {
            HomePageForm homePage = new HomePageForm(_context, _citizenId);
            this.Hide();
            homePage.Show();
        }
        #endregion

        #region HomePage Button
        private void butHomePage_Click(object sender, EventArgs e)
        {
            HomePageForm homePage = new HomePageForm(_context, _citizenId);
            this.Hide();
            homePage.Show();
        }
        #endregion

        #region Profile Button
        private void butEditProfile_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(_context, _citizenId);
            this.Hide();
            profileForm.Show();
        }
        #endregion

        #region Submit Complaint Button
        private void butSubmit_Click(object sender, EventArgs e)
        {
            SubmitComplaintForm submitComplaintForm = new SubmitComplaintForm(_context, _citizenId);
            this.Hide();
            submitComplaintForm.Show();
        }
        #endregion

        #region Track Complaints Button
        private void butTrackComplaints_Click(object sender, EventArgs e)
        {
            TrackComplaintsForm trackComplaintsForm = new TrackComplaintsForm(_context, _citizenId);
            this.Hide();
            trackComplaintsForm.Show();
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
