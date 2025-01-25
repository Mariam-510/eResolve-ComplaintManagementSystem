using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
using ComplaintManagementSystem.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ComplaintManagementSystem.Forms.LoginAndSignUpForms
{
    public partial class CitizenSignUpForm : Form
    {
        private readonly ComplaintSystemContext _context;

        #region Ctor
        public CitizenSignUpForm(ComplaintSystemContext context)
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

        #region SignUp
        private void butSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string name = txtName.Text;
            string phoneNumber = txtPhone.Text;

            try
            {
                // Validate phone number format (11 to 15 characters)
                if (phoneNumber.Length < 11 || phoneNumber.Length > 15)
                {
                    throw new ArgumentException("Phone number must be between 11 and 15 characters.");
                }

                AccountController accountController = new AccountController(_context);
                accountController.Register(username, password, "Citizen");

                var account = accountController.GetAccountByUsername(username);

                if (account == null)
                {
                    throw new InvalidOperationException("Account registration failed.");
                }

                CitizenController citizenController = new CitizenController(_context);
                Citizen citizen = new Citizen
                {
                    Name = name,
                    PhoneNumber = phoneNumber,
                    AccountId = account.Id
                };

                citizenController.AddCitizen(citizen);

                MessageBox.Show("Sign-up successful. You can now log in.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                CitizenLoginForm citizenLoginForm = new CitizenLoginForm(_context);
                citizenLoginForm.Show();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Go to login Page
        private void Account_Click(object sender, EventArgs e)
        {
            CitizenLoginForm citizenLoginForm = new CitizenLoginForm(_context);
            this.Hide();
            citizenLoginForm.Show();
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
