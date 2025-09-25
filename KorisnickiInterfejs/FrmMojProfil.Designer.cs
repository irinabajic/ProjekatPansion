namespace KorisnickiInterfejs
{
    partial class FrmMojProfil
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtIme = new TextBox();
            txtTelefon = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnSacuvaj = new Button();
            btnOdustani = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 62);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "Ime i prezime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 94);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 1;
            label2.Text = "Broj telefona:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 128);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "Username:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 159);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 3;
            label4.Text = "Password:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(161, 59);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(206, 23);
            txtIme.TabIndex = 8;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(161, 91);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(206, 23);
            txtTelefon.TabIndex = 9;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(161, 125);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(206, 23);
            txtUsername.TabIndex = 10;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(161, 156);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(206, 23);
            txtPassword.TabIndex = 11;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(68, 223);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(107, 23);
            btnSacuvaj.TabIndex = 12;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            // 
            // btnOdustani
            // 
            btnOdustani.Location = new Point(260, 223);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(107, 23);
            btnOdustani.TabIndex = 13;
            btnOdustani.Text = "Odustani";
            btnOdustani.UseVisualStyleBackColor = true;
            // 
            // FrmMojProfil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 300);
            Controls.Add(btnOdustani);
            Controls.Add(btnSacuvaj);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtTelefon);
            Controls.Add(txtIme);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmMojProfil";
            Text = "FrmMojProfil";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtIme;
        private TextBox txtTelefon;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnSacuvaj;
        private Button btnOdustani;

        public TextBox TxtIme1 { get => txtIme; set => txtIme = value; }
        public TextBox TxtTelefon1 { get => txtTelefon; set => txtTelefon = value; }
        public TextBox TxtUsername { get => txtUsername; set => txtUsername = value; }
        public TextBox TxtPassword { get => txtPassword; set => txtPassword = value; }
        public Button BtnSacuvaj { get => btnSacuvaj; set => btnSacuvaj = value; }
        public Button BtnOdustani { get => btnOdustani; set => btnOdustani = value; }
        public TextBox TxtUsername1 { get => txtUsername; set => txtUsername = value; }
    }
}