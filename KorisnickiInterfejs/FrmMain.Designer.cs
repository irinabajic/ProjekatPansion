namespace KorisnickiInterfejs
{
    partial class FrmMain
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
            lblImeIPrezime = new Label();
            lblEmail = new Label();
            lblTelefon = new Label();
            label6 = new Label();
            dgvKolege = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvKolege).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 62);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "Ime i prezime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 90);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "E-mail:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 18);
            label3.Name = "label3";
            label3.Size = new Size(112, 25);
            label3.TabIndex = 2;
            label3.Text = "Moji podaci";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 118);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 3;
            label4.Text = "Broj telefona:";
            // 
            // lblImeIPrezime
            // 
            lblImeIPrezime.AutoSize = true;
            lblImeIPrezime.Location = new Point(114, 62);
            lblImeIPrezime.Name = "lblImeIPrezime";
            lblImeIPrezime.Size = new Size(0, 15);
            lblImeIPrezime.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(114, 90);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(0, 15);
            lblEmail.TabIndex = 6;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Location = new Point(114, 118);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(0, 15);
            lblTelefon.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(578, 18);
            label6.Name = "label6";
            label6.Size = new Size(210, 25);
            label6.TabIndex = 8;
            label6.Text = "Informacije o kolegama";
            // 
            // dgvKolege
            // 
            dgvKolege.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKolege.Location = new Point(368, 62);
            dgvKolege.Name = "dgvKolege";
            dgvKolege.Size = new Size(420, 150);
            dgvKolege.TabIndex = 9;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvKolege);
            Controls.Add(label6);
            Controls.Add(lblTelefon);
            Controls.Add(lblEmail);
            Controls.Add(lblImeIPrezime);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmMain";
            Text = "FrmMain";
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKolege).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblImeIPrezime;
        private Label lblEmail;
        private Label lblTelefon;
        private Label label6;
        private DataGridView dgvKolege;

        public Label LblImeIPrezime { get => lblImeIPrezime; set => lblImeIPrezime = value; }
        public Label LblEmail { get => lblEmail; set => lblEmail = value; }
        public Label LblTelefon { get => lblTelefon; set => lblTelefon = value; }
        public DataGridView DgvKolege { get => dgvKolege; set => dgvKolege = value; }
    }
}