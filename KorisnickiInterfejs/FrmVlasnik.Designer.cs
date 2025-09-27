namespace KorisnickiInterfejs
{
    partial class FrmVlasnik
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
            dgvVlasnici = new DataGridView();
            txtIme = new TextBox();
            txtTelefon = new TextBox();
            txtAdresa = new TextBox();
            txtEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnOsvezi = new Button();
            btnDodaj = new Button();
            btnIzmeni = new Button();
            btnObrisi = new Button();
            txtPretraga = new TextBox();
            btnPretrazi = new Button();
            cboMesto = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvVlasnici).BeginInit();
            SuspendLayout();
            // 
            // dgvVlasnici
            // 
            dgvVlasnici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVlasnici.Location = new Point(82, 66);
            dgvVlasnici.Name = "dgvVlasnici";
            dgvVlasnici.Size = new Size(401, 241);
            dgvVlasnici.TabIndex = 0;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(173, 328);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(310, 23);
            txtIme.TabIndex = 1;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(173, 357);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(310, 23);
            txtTelefon.TabIndex = 2;
            // 
            // txtAdresa
            // 
            txtAdresa.Location = new Point(173, 386);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(310, 23);
            txtAdresa.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(173, 415);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(310, 23);
            txtEmail.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 331);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 6;
            label1.Text = "Ime i prezime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(82, 360);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 7;
            label2.Text = "Broj telefona:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(82, 389);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 8;
            label3.Text = "Adresa:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(82, 418);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 9;
            label4.Text = "E-mail:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(82, 447);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 10;
            label5.Text = "Mesto:";
            // 
            // btnOsvezi
            // 
            btnOsvezi.Location = new Point(82, 490);
            btnOsvezi.Name = "btnOsvezi";
            btnOsvezi.Size = new Size(75, 23);
            btnOsvezi.TabIndex = 11;
            btnOsvezi.Text = "Osvezi";
            btnOsvezi.UseVisualStyleBackColor = true;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(190, 490);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(75, 23);
            btnDodaj.TabIndex = 12;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(299, 490);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(75, 23);
            btnIzmeni.TabIndex = 13;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(408, 490);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(75, 23);
            btnObrisi.TabIndex = 14;
            btnObrisi.Text = "Obrisi";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // txtPretraga
            // 
            txtPretraga.Location = new Point(173, 24);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.Size = new Size(310, 23);
            txtPretraga.TabIndex = 15;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(82, 24);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(75, 23);
            btnPretrazi.TabIndex = 16;
            btnPretrazi.Text = "Pretrazi";
            btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // cboMesto
            // 
            cboMesto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMesto.FormattingEnabled = true;
            cboMesto.Location = new Point(173, 444);
            cboMesto.Name = "cboMesto";
            cboMesto.Size = new Size(310, 23);
            cboMesto.TabIndex = 17;
            // 
            // FrmVlasnik
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 557);
            Controls.Add(cboMesto);
            Controls.Add(btnPretrazi);
            Controls.Add(txtPretraga);
            Controls.Add(btnObrisi);
            Controls.Add(btnIzmeni);
            Controls.Add(btnDodaj);
            Controls.Add(btnOsvezi);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(txtAdresa);
            Controls.Add(txtTelefon);
            Controls.Add(txtIme);
            Controls.Add(dgvVlasnici);
            Name = "FrmVlasnik";
            Text = "FrmVlasnik";
            ((System.ComponentModel.ISupportInitialize)dgvVlasnici).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvVlasnici;
        private TextBox txtIme;
        private TextBox txtTelefon;
        private TextBox txtAdresa;
        private TextBox txtEmail;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnOsvezi;
        private Button btnDodaj;
        private Button btnIzmeni;
        private Button btnObrisi;
        private TextBox txtPretraga;
        private Button btnPretrazi;
        private ComboBox cboMesto;

        public DataGridView DgvVlasnici { get => dgvVlasnici; set => dgvVlasnici = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtTelefon { get => txtTelefon; set => txtTelefon = value; }
        public TextBox TxtAdresa { get => txtAdresa; set => txtAdresa = value; }
        public TextBox TxtEmail { get => txtEmail; set => txtEmail = value; }
        public Button BtnOsvezi { get => btnOsvezi; set => btnOsvezi = value; }
        public Button BtnDodaj { get => btnDodaj; set => btnDodaj = value; }
        public Button BtnIzmeni { get => btnIzmeni; set => btnIzmeni = value; }
        public Button BtnObrisi { get => btnObrisi; set => btnObrisi = value; }
        public TextBox TxtPretraga { get => txtPretraga; set => txtPretraga = value; }
        public Button BtnPretrazi { get => btnPretrazi; set => btnPretrazi = value; }
        public ComboBox CboMesto { get => cboMesto; set => cboMesto = value; }
    }
}