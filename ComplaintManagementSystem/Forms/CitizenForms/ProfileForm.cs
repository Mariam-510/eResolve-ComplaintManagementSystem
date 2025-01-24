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

namespace ComplaintManagementSystem.Forms.CitizenForms
{
    public partial class ProfileForm : Form
    {
        private readonly ComplaintSystemContext _context;

        private int _citizenId;

        CitizenController citizenController;

        #region Ctor
        public ProfileForm(ComplaintSystemContext context, int citizenId)
        {
            InitializeComponent();
            _context = context;
            _citizenId = citizenId;
            citizenController = new CitizenController(_context);
            this.FormClosing += ExitFormClosing;
        }
        #endregion

        #region Closing Event
        private void ExitFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Form Load
        private void ProfileForm_Load(object sender, EventArgs e)
        {
            var _citizen = citizenController.GetCitizenById(_citizenId);
            labelUserName.Text = "Welcome " + _citizen.Account.Username;
            try
            {
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
            var _citizen = citizenController.GetCitizenById(_citizenId);
            txtUserName.Text = _citizen.Account.Username;
            txtName.Text = _citizen.Name;
            txtPhone.Text = _citizen.PhoneNumber;
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
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

                // Update citizen information
                var updatedCitizen = new Citizen
                {
                    Name = newName,
                    PhoneNumber = newPhone,
                };

                var _citizen = citizenController.GetCitizenById(_citizenId);

                citizenController.UpdateCitizen(_citizen.Id, updatedCitizen);

                // Update password if provided
                if (!string.IsNullOrEmpty(newPassword))
                {
                    AccountController accountController = new AccountController(_context);
                    accountController.UpdatePassword(_citizen.AccountId, currentPassword, newPassword);
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

        #region Delete Button
        private void butDelete_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before deleting
            DialogResult dialogResult = MessageBox.Show(
                "Are you sure you want to delete this citizen?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.Yes)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        CitizenController citizenController = new CitizenController(_context);
                        AccountController accountController = new AccountController(_context);
                        ComplaintController complaintController = new ComplaintController(_context);

                        var _citizen = citizenController.GetCitizenById(_citizenId);

                        // Delete the citizen's account
                        accountController.DeleteAccount(_citizen.AccountId);

                        // Delete the citizen's complaints
                        var complaints = citizenController.GetComplaintsForCitizenFiltered(_citizen.Id);
                        foreach (var complaint in complaints)
                        {
                            complaintController.DeleteComplaint(complaint.Id);
                        }

                        // Delete the citizen record
                        citizenController.DeleteCitizen(_citizen.Id);

                        // Commit the transaction if all operations succeed
                        transaction.Commit();

                        MessageBox.Show("Citizen deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CitizenLoginForm citizenLoginForm = new CitizenLoginForm(_context);
                        this.Hide();
                        citizenLoginForm.Show();
                    }
                    catch (KeyNotFoundException ex)
                    {
                        // Roll back the transaction if a key error occurs
                        transaction.Rollback();
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Roll back the transaction if any other error occurs
                        transaction.Rollback();
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // If No is selected, do nothing
                return;
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

    }
}
