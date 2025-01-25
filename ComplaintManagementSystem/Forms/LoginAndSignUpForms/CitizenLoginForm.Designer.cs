namespace ComplaintManagementSystem.Forms.LoginAndSignUpForms
{
    partial class CitizenLoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CitizenLoginForm));
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            butLogin = new Button();
            labelUserName = new Label();
            labelPassword = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            butSignUp = new Button();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox7 = new PictureBox();
            label11 = new Label();
            butClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(549, 202);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(280, 30);
            txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(549, 299);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(280, 30);
            txtPassword.TabIndex = 1;
            // 
            // butLogin
            // 
            butLogin.BackColor = Color.SteelBlue;
            butLogin.FlatAppearance.BorderSize = 0;
            butLogin.FlatStyle = FlatStyle.Flat;
            butLogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butLogin.ForeColor = Color.White;
            butLogin.Location = new Point(635, 342);
            butLogin.Name = "butLogin";
            butLogin.Size = new Size(94, 45);
            butLogin.TabIndex = 2;
            butLogin.Text = "Login";
            butLogin.UseVisualStyleBackColor = false;
            butLogin.Click += butLogin_Click;
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUserName.ForeColor = Color.White;
            labelUserName.Location = new Point(549, 171);
            labelUserName.Name = "labelUserName";
            labelUserName.RightToLeft = RightToLeft.No;
            labelUserName.Size = new Size(103, 28);
            labelUserName.TabIndex = 4;
            labelUserName.Text = "UserName";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPassword.ForeColor = Color.White;
            labelPassword.Location = new Point(549, 269);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(93, 28);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Password";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.client_login_icon_4;
            pictureBox2.Location = new Point(527, 37);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(302, 120);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(444, 183);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(85, 63);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(444, 273);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(85, 70);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(75, 136);
            label1.Name = "label1";
            label1.Size = new Size(182, 81);
            label1.TabIndex = 11;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SteelBlue;
            label2.Location = new Point(84, 217);
            label2.Name = "label2";
            label2.Size = new Size(164, 81);
            label2.TabIndex = 12;
            label2.Text = "Page";
            // 
            // butSignUp
            // 
            butSignUp.BackColor = Color.SteelBlue;
            butSignUp.FlatAppearance.BorderSize = 0;
            butSignUp.FlatStyle = FlatStyle.Flat;
            butSignUp.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butSignUp.ForeColor = Color.White;
            butSignUp.Location = new Point(594, 390);
            butSignUp.Name = "butSignUp";
            butSignUp.Size = new Size(185, 41);
            butSignUp.TabIndex = 13;
            butSignUp.Text = "Don't have account?";
            butSignUp.UseVisualStyleBackColor = false;
            butSignUp.Click += butSignUp_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(835, 204);
            label3.Name = "label3";
            label3.Size = new Size(20, 28);
            label3.TabIndex = 26;
            label3.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(835, 299);
            label4.Name = "label4";
            label4.Size = new Size(20, 28);
            label4.TabIndex = 27;
            label4.Text = "*";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources._3;
            button1.Location = new Point(789, 301);
            button1.Name = "button1";
            button1.Size = new Size(37, 26);
            button1.TabIndex = 28;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(787, 301);
            button2.Name = "button2";
            button2.Size = new Size(37, 26);
            button2.TabIndex = 29;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.SteelBlue;
            pictureBox1.Image = Properties.Resources.Half_Circle_PNG_Photo1;
            pictureBox1.Location = new Point(-5, -10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(372, 471);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(4, 27);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(60, 63);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 41;
            pictureBox7.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.White;
            label11.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.SteelBlue;
            label11.Location = new Point(66, 37);
            label11.Name = "label11";
            label11.Size = new Size(135, 41);
            label11.TabIndex = 40;
            label11.Text = "eResolve";
            // 
            // butClose
            // 
            butClose.BackColor = Color.SteelBlue;
            butClose.FlatAppearance.BorderSize = 0;
            butClose.FlatStyle = FlatStyle.Flat;
            butClose.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butClose.ForeColor = Color.White;
            butClose.Location = new Point(859, 12);
            butClose.Name = "butClose";
            butClose.Size = new Size(94, 45);
            butClose.TabIndex = 42;
            butClose.Text = "Close";
            butClose.UseVisualStyleBackColor = false;
            butClose.Click += butClose_Click;
            // 
            // CitizenLoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(972, 450);
            Controls.Add(butClose);
            Controls.Add(pictureBox7);
            Controls.Add(label11);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox2);
            Controls.Add(labelPassword);
            Controls.Add(labelUserName);
            Controls.Add(butLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(butSignUp);
            Controls.Add(pictureBox1);
            Name = "CitizenLoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Citizen Login Page";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserName;
        private TextBox txtPassword;
        private Button butLogin;
        private Label labelUserName;
        private Label labelPassword;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label label1;
        private Label label2;
        private Button butSignUp;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox7;
        private Label label11;
        private Button butClose;
    }
}