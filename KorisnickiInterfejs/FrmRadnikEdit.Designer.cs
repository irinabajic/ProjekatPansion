namespace KorisnickiInterfejs.GUIKontroler
{
    partial class FrmRadnikEdit
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
            txtIme = new TextBox();
            groupBox1 = new GroupBox();
            label4 = new Label();
            txtPassword = new TextBox();
            txtNoviPassword = new TextBox();
            lblNoviPassword = new Label();
            label1 = new Label();
            label2 = new Label();
            txtUser = new TextBox();
            label3 = new Label();
            txtTelefon = new TextBox();
            btnOK = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtIme
            // 
            txtIme.Location = new Point(152, 50);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(170, 23);
            txtIme.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtNoviPassword);
            groupBox1.Controls.Add(lblNoviPassword);
            groupBox1.Location = new Point(44, 150);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(296, 118);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Promena lozinke";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 39);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 10;
            label4.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(109, 36);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(170, 23);
            txtPassword.TabIndex = 7;
            // 
            // txtNoviPassword
            // 
            txtNoviPassword.Location = new Point(109, 65);
            txtNoviPassword.Name = "txtNoviPassword";
            txtNoviPassword.Size = new Size(170, 23);
            txtNoviPassword.TabIndex = 9;
            // 
            // lblNoviPassword
            // 
            lblNoviPassword.AutoSize = true;
            lblNoviPassword.Location = new Point(15, 68);
            lblNoviPassword.Name = "lblNoviPassword";
            lblNoviPassword.Size = new Size(88, 15);
            lblNoviPassword.TabIndex = 8;
            lblNoviPassword.Text = "Novi password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 82);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 53);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 4;
            label2.Text = "Ime i prezime:";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(152, 79);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(170, 23);
            txtUser.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 111);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 6;
            label3.Text = "Broj telefona:";
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(152, 108);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(170, 23);
            txtTelefon.TabIndex = 5;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(225, 283);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(115, 23);
            btnOK.TabIndex = 7;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // FrmRadnikEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 361);
            Controls.Add(btnOK);
            Controls.Add(label3);
            Controls.Add(txtTelefon);
            Controls.Add(label2);
            Controls.Add(txtUser);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(txtIme);
            Name = "FrmRadnikEdit";
            Text = "FrmRadnikEdit";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIme;
        private GroupBox groupBox1;
        private Label label4;
        private TextBox txtPassword;
        private TextBox txtNoviPassword;
        private Label lblNoviPassword;
        private Label label1;
        private Label label2;
        private TextBox txtUser;
        private Label label3;
        private TextBox txtTelefon;
        private Button btnOK;

        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public GroupBox GroupBox1 { get => groupBox1; set => groupBox1 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public TextBox TxtPassword { get => txtPassword; set => txtPassword = value; }
        public TextBox TxtNoviPassword { get => txtNoviPassword; set => txtNoviPassword = value; }
        public Label Label5 { get => lblNoviPassword; set => lblNoviPassword = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public TextBox TxtUser { get => txtUser; set => txtUser = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public TextBox TxtTelefon { get => txtTelefon; set => txtTelefon = value; }
        public Button BtnOK { get => btnOK; set => btnOK = value; }
    }
}