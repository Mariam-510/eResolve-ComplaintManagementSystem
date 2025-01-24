using ComplaintManagementSystem.Context;

namespace ComplaintManagementSystem.Forms.LoginAndSignUpForms
{
    public partial class WelcomeForm : Form
    {
        private ComplaintSystemContext _context;

        #region Ctor
        public WelcomeForm()
        {
            _context = new ComplaintSystemContext();
            InitializeComponent();
            this.FormClosing += ExitFormClosing;
        }
        #endregion

        #region Closing Event
        private void ExitFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        // When Citizen button is clicked, open CitizenLoginForm
        private void butCitizen_Click(object sender, EventArgs e)
        {
            CitizenLoginForm citizenLoginForm = new CitizenLoginForm(_context);
            this.Hide();
            citizenLoginForm.Show();
        }

        // When Employee button is clicked, open EmployeeLoginForm
        private void butEmployee_Click(object sender, EventArgs e)
        {
            EmployeeLoginForm employeeLoginForm = new EmployeeLoginForm(_context);
            this.Hide();
            employeeLoginForm.Show();
            //this.Show();
        }

    }
}
