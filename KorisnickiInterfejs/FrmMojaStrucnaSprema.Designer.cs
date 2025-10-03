namespace KorisnickiInterfejs
{
    partial class FrmMojaStrucnaSprema
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
            dgvRSS = new DataGridView();
            grpIzmena = new GroupBox();
            btnIzmeni = new Button();
            label1 = new Label();
            txtBrojSertifikata = new TextBox();
            grpDodavanje = new GroupBox();
            label3 = new Label();
            cboStrucnaSprema = new ComboBox();
            btnDodaj = new Button();
            label2 = new Label();
            txtBrojSertifikataNovo = new TextBox();
            btnObrisi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRSS).BeginInit();
            grpIzmena.SuspendLayout();
            grpDodavanje.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRSS
            // 
            dgvRSS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRSS.Location = new Point(48, 51);
            dgvRSS.Name = "dgvRSS";
            dgvRSS.Size = new Size(357, 191);
            dgvRSS.TabIndex = 0;
            // 
            // grpIzmena
            // 
            grpIzmena.Controls.Add(btnIzmeni);
            grpIzmena.Controls.Add(label1);
            grpIzmena.Controls.Add(txtBrojSertifikata);
            grpIzmena.Location = new Point(48, 269);
            grpIzmena.Name = "grpIzmena";
            grpIzmena.Size = new Size(357, 94);
            grpIzmena.TabIndex = 1;
            grpIzmena.TabStop = false;
            grpIzmena.Text = "Izmena";
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(263, 57);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(75, 23);
            btnIzmeni.TabIndex = 2;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 26);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 1;
            label1.Text = "Broj sertifikata:";
            // 
            // txtBrojSertifikata
            // 
            txtBrojSertifikata.Location = new Point(124, 23);
            txtBrojSertifikata.Name = "txtBrojSertifikata";
            txtBrojSertifikata.Size = new Size(214, 23);
            txtBrojSertifikata.TabIndex = 0;
            // 
            // grpDodavanje
            // 
            grpDodavanje.Controls.Add(label3);
            grpDodavanje.Controls.Add(cboStrucnaSprema);
            grpDodavanje.Controls.Add(btnDodaj);
            grpDodavanje.Controls.Add(label2);
            grpDodavanje.Controls.Add(txtBrojSertifikataNovo);
            grpDodavanje.Location = new Point(48, 364);
            grpDodavanje.Name = "grpDodavanje";
            grpDodavanje.Size = new Size(357, 131);
            grpDodavanje.TabIndex = 3;
            grpDodavanje.TabStop = false;
            grpDodavanje.Text = "Dodavanje";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 29);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 4;
            label3.Text = "Strucna sprema:";
            // 
            // cboStrucnaSprema
            // 
            cboStrucnaSprema.FormattingEnabled = true;
            cboStrucnaSprema.Location = new Point(124, 26);
            cboStrucnaSprema.Name = "cboStrucnaSprema";
            cboStrucnaSprema.Size = new Size(214, 23);
            cboStrucnaSprema.TabIndex = 3;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(263, 93);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(75, 23);
            btnDodaj.TabIndex = 2;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 62);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 1;
            label2.Text = "Broj sertifikata:";
            // 
            // txtBrojSertifikataNovo
            // 
            txtBrojSertifikataNovo.Location = new Point(124, 59);
            txtBrojSertifikataNovo.Name = "txtBrojSertifikataNovo";
            txtBrojSertifikataNovo.Size = new Size(214, 23);
            txtBrojSertifikataNovo.TabIndex = 0;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(330, 20);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(75, 23);
            btnObrisi.TabIndex = 5;
            btnObrisi.Text = "Obrisi";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // FrmMojaStrucnaSprema
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 535);
            Controls.Add(btnObrisi);
            Controls.Add(grpDodavanje);
            Controls.Add(grpIzmena);
            Controls.Add(dgvRSS);
            Name = "FrmMojaStrucnaSprema";
            Text = "FrmMojaStrucnaSprema";
            ((System.ComponentModel.ISupportInitialize)dgvRSS).EndInit();
            grpIzmena.ResumeLayout(false);
            grpIzmena.PerformLayout();
            grpDodavanje.ResumeLayout(false);
            grpDodavanje.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRSS;
        private GroupBox grpIzmena;
        private Button btnIzmeni;
        private Label label1;
        private TextBox txtBrojSertifikata;
        private GroupBox grpDodavanje;
        private Label label3;
        private ComboBox cboStrucnaSprema;
        private Button btnDodaj;
        private Label label2;
        private TextBox txtBrojSertifikataNovo;
        private Button btnObrisi;

        public DataGridView DgvRSS { get => dgvRSS; set => dgvRSS = value; }
        public GroupBox GrpIzmena { get => grpIzmena; set => grpIzmena = value; }
        public Button BtnIzmeni { get => btnIzmeni; set => btnIzmeni = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public TextBox TxtBrojSertifikata { get => txtBrojSertifikata; set => txtBrojSertifikata = value; }
        public GroupBox GrpDodavanje { get => grpDodavanje; set => grpDodavanje = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Button BtnDodaj { get => btnDodaj; set => btnDodaj = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public TextBox TxtBrojSertifikataNovo { get => txtBrojSertifikataNovo; set => txtBrojSertifikataNovo = value; }
        public Button BtnObrisi { get => btnObrisi; set => btnObrisi = value; }
        public ComboBox CboStrucnaSprema { get => cboStrucnaSprema; set => cboStrucnaSprema = value; }
    }
}