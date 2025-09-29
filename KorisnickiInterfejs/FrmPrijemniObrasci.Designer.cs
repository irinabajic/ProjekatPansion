namespace KorisnickiInterfejs
{
    partial class FrmPrijemniObrasci
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
            dgvPrijemniObrasci = new DataGridView();
            btnOsvezi = new Button();
            btnDodaj = new Button();
            btnIzmeni = new Button();
            btnObrisi = new Button();
            btnPretrazi = new Button();
            txtPretraga = new TextBox();
            btnPrikaziDetalje = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPrijemniObrasci).BeginInit();
            SuspendLayout();
            // 
            // dgvPrijemniObrasci
            // 
            dgvPrijemniObrasci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrijemniObrasci.Location = new Point(56, 63);
            dgvPrijemniObrasci.Name = "dgvPrijemniObrasci";
            dgvPrijemniObrasci.Size = new Size(440, 216);
            dgvPrijemniObrasci.TabIndex = 0;
            // 
            // btnOsvezi
            // 
            btnOsvezi.Location = new Point(55, 298);
            btnOsvezi.Name = "btnOsvezi";
            btnOsvezi.Size = new Size(75, 23);
            btnOsvezi.TabIndex = 7;
            btnOsvezi.Text = "Osvezi";
            btnOsvezi.UseVisualStyleBackColor = true;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(173, 298);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(75, 23);
            btnDodaj.TabIndex = 8;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(298, 298);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(75, 23);
            btnIzmeni.TabIndex = 9;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(420, 298);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(75, 23);
            btnObrisi.TabIndex = 10;
            btnObrisi.Text = "Obrisi";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(56, 23);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(75, 23);
            btnPretrazi.TabIndex = 11;
            btnPretrazi.Text = "Pretrazi";
            btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // txtPretraga
            // 
            txtPretraga.Location = new Point(170, 23);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.Size = new Size(326, 23);
            txtPretraga.TabIndex = 12;
            // 
            // btnPrikaziDetalje
            // 
            btnPrikaziDetalje.Location = new Point(509, 63);
            btnPrikaziDetalje.Name = "btnPrikaziDetalje";
            btnPrikaziDetalje.Size = new Size(51, 216);
            btnPrikaziDetalje.TabIndex = 13;
            btnPrikaziDetalje.Text = "Detalji";
            btnPrikaziDetalje.UseVisualStyleBackColor = true;
            // 
            // FrmPrijemniObrasci
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 363);
            Controls.Add(btnPrikaziDetalje);
            Controls.Add(txtPretraga);
            Controls.Add(btnPretrazi);
            Controls.Add(btnObrisi);
            Controls.Add(btnIzmeni);
            Controls.Add(btnDodaj);
            Controls.Add(btnOsvezi);
            Controls.Add(dgvPrijemniObrasci);
            Name = "FrmPrijemniObrasci";
            Text = "FrmPrijemniObrasci";
            ((System.ComponentModel.ISupportInitialize)dgvPrijemniObrasci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPrijemniObrasci;
        private Button btnOsvezi;
        private Button btnDodaj;
        private Button btnIzmeni;
        private Button btnObrisi;
        private Button btnPretrazi;
        private TextBox txtPretraga;
        private Button btnPrikaziDetalje;

        public Button BtnOsvezi { get => btnOsvezi; set => btnOsvezi = value; }
        public Button BtnDodaj { get => btnDodaj; set => btnDodaj = value; }
        public Button BtnIzmeni { get => btnIzmeni; set => btnIzmeni = value; }
        public Button BtnObrisi { get => btnObrisi; set => btnObrisi = value; }
        public Button BtnPretrazi { get => btnPretrazi; set => btnPretrazi = value; }
        public DataGridView DgvPrijemniObrasci { get => dgvPrijemniObrasci; set => dgvPrijemniObrasci = value; }
        public TextBox TxtPretraga { get => txtPretraga; set => txtPretraga = value; }
    }
}