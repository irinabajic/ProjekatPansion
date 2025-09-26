namespace KorisnickiInterfejs
{
    partial class FrmRegistracijaRadnika
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
            label1 = new Label();
            txtIme = new TextBox();
            txtTelefon = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            txtPotvrda = new TextBox();
            label5 = new Label();
            btnRegistruj = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 56);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "Ime i prezime:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(166, 53);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(194, 23);
            txtIme.TabIndex = 1;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(166, 87);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(194, 23);
            txtTelefon.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 90);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 2;
            label2.Text = "Broj telefona:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(166, 120);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(194, 23);
            txtUsername.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 123);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 4;
            label3.Text = "Username:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(166, 152);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(194, 23);
            txtPassword.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 155);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 6;
            label4.Text = "Password:";
            // 
            // txtPotvrda
            // 
            txtPotvrda.Location = new Point(166, 186);
            txtPotvrda.Name = "txtPotvrda";
            txtPotvrda.Size = new Size(194, 23);
            txtPotvrda.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(68, 189);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 8;
            label5.Text = "Potvrda:";
            label5.Click += label5_Click;
            // 
            // btnRegistruj
            // 
            btnRegistruj.Location = new Point(166, 234);
            btnRegistruj.Name = "btnRegistruj";
            btnRegistruj.Size = new Size(194, 23);
            btnRegistruj.TabIndex = 10;
            btnRegistruj.Text = "Register";
            btnRegistruj.UseVisualStyleBackColor = true;
            // 
            // FrmRegistracijaRadnika
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 307);
            Controls.Add(btnRegistruj);
            Controls.Add(txtPotvrda);
            Controls.Add(label5);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(txtTelefon);
            Controls.Add(label2);
            Controls.Add(txtIme);
            Controls.Add(label1);
            Name = "FrmRegistracijaRadnika";
            Text = "FrmRegistracijaRadnika";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIme;
        private TextBox txtTelefon;
        private Label label2;
        private TextBox txtUsername;
        private Label label3;
        private TextBox txtPassword;
        private Label label4;
        private TextBox txtPotvrda;
        private Label label5;
        private Button btnRegistruj;

        public Label Label1 { get => label1; set => label1 = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtTelefon { get => txtTelefon; set => txtTelefon = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public TextBox TxtUsername { get => txtUsername; set => txtUsername = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public TextBox TxtPassword { get => txtPassword; set => txtPassword = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public TextBox TxtPotvrda { get => txtPotvrda; set => txtPotvrda = value; }
        public Label Label5 { get => label5; set => label5 = value; }
        public Button BtnRegistruj { get => btnRegistruj; set => btnRegistruj = value; }
    }
}