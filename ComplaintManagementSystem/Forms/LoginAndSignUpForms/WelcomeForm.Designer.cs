namespace ComplaintManagementSystem.Forms.LoginAndSignUpForms
{
    partial class WelcomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            butEmployee = new Button();
            butCitizen = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // butEmployee
            // 
            butEmployee.BackColor = Color.White;
            butEmployee.Cursor = Cursors.Hand;
            butEmployee.FlatAppearance.BorderSize = 0;
            butEmployee.FlatStyle = FlatStyle.Flat;
            butEmployee.Font = new Font("Segoe UI", 13.8F);
            butEmployee.ForeColor = Color.SteelBlue;
            butEmployee.Location = new Point(587, 305);
            butEmployee.Name = "butEmployee";
            butEmployee.Size = new Size(159, 50);
            butEmployee.TabIndex = 4;
            butEmployee.Text = "Employee";
            butEmployee.UseVisualStyleBackColor = false;
            butEmployee.Click += butEmployee_Click;
            // 
            // butCitizen
            // 
            butCitizen.BackColor = Color.White;
            butCitizen.Cursor = Cursors.Hand;
            butCitizen.FlatAppearance.BorderSize = 0;
            butCitizen.FlatStyle = FlatStyle.Flat;
            butCitizen.Font = new Font("Segoe UI", 13.8F);
            butCitizen.ForeColor = Color.SteelBlue;
            butCitizen.Location = new Point(244, 305);
            butCitizen.Name = "butCitizen";
            butCitizen.Size = new Size(159, 50);
            butCitizen.TabIndex = 5;
            butCitizen.Text = "Citizen";
            butCitizen.UseVisualStyleBackColor = false;
            butCitizen.Click += butCitizen_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.citizen;
            pictureBox1.Location = new Point(256, 182);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(600, 182);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(125, 102);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(244, 112);
            label1.Name = "label1";
            label1.Size = new Size(495, 41);
            label1.TabIndex = 8;
            label1.Text = "Simplifying Complaint Management";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(407, 386);
            label2.Name = "label2";
            label2.Size = new Size(191, 31);
            label2.TabIndex = 9;
            label2.Text = "choose your Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(446, 34);
            label3.Name = "label3";
            label3.Size = new Size(178, 54);
            label3.TabIndex = 10;
            label3.Text = "eResolve";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(360, 26);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(90, 71);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(972, 450);
            Controls.Add(pictureBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(butCitizen);
            Controls.Add(butEmployee);
            Name = "WelcomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Welcome Page";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button butEmployee;
        private Button butCitizen;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox3;
    }
}
