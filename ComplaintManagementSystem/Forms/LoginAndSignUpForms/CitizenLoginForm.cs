using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
using ComplaintManagementSystem.Forms.CitizenForms;
using ComplaintManagementSystem.Models;

namespace ComplaintManagementSystem.Forms.LoginAndSignUpForms
{
    public partial class CitizenLoginForm : Form
    {
        private readonly ComplaintSystemContext _context;

        #region Ctor
        public CitizenLoginForm(ComplaintSystemContext context)
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

        #region Go to SignUp Form
        private void butSignUp_Click(object sender, EventArgs e)
        {
            CitizenSignUpForm citizenSignUpForm = new CitizenSignUpForm(_context);
            this.Hide();
            citizenSignUpForm.Show();
        }
        #endregion

        #region Login Button
        private void butLogin_Click(object sender, EventArgs e)
        {
            AccountController accountController = new AccountController(_context);
            CitizenController citizenController = new CitizenController(_context);

            string username = txtUserName.Text;
            string password = txtPassword.Text;

            try
            {
                Account account = accountController.Login(username, password);

                // Check if the account's role is "Citizen"
                if (account.Role != "Citizen")
                {
                    MessageBox.Show("You must have a Citizen account to login.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method if the role is not "Citizen"
                }

                // Get the Citizen details using the account Id
                var _citizen = citizenController.GetCitizenByAccountId(account.Id);

                // Open the home page for the citizen
                HomePageForm homePage = new HomePageForm(_context, _citizen.Id);
                this.Hide();
                homePage.Show();
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
