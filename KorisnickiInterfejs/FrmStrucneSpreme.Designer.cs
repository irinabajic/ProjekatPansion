namespace KorisnickiInterfejs
{
    partial class FrmStrucneSpreme
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
            dgvStrucneSpreme = new DataGridView();
            txtNaziv = new TextBox();
            txtPretraga = new TextBox();
            txtStepenObr = new TextBox();
            txtUstanova = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnOsvezi = new Button();
            btnDodaj = new Button();
            btnObrisi = new Button();
            btnIzmeni = new Button();
            btnPretrazi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStrucneSpreme).BeginInit();
            SuspendLayout();
            // 
            // dgvStrucneSpreme
            // 
            dgvStrucneSpreme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStrucneSpreme.Location = new Point(78, 63);
            dgvStrucneSpreme.Name = "dgvStrucneSpreme";
            dgvStrucneSpreme.Size = new Size(395, 221);
            dgvStrucneSpreme.TabIndex = 0;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(197, 307);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(276, 23);
            txtNaziv.TabIndex = 1;
            // 
            // txtPretraga
            // 
            txtPretraga.Location = new Point(197, 23);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.Size = new Size(276, 23);
            txtPretraga.TabIndex = 2;
            // 
            // txtStepenObr
            // 
            txtStepenObr.Location = new Point(197, 347);
            txtStepenObr.Name = "txtStepenObr";
            txtStepenObr.Size = new Size(276, 23);
            txtStepenObr.TabIndex = 3;
            // 
            // txtUstanova
            // 
            txtUstanova.Location = new Point(197, 387);
            txtUstanova.Name = "txtUstanova";
            txtUstanova.Size = new Size(276, 23);
            txtUstanova.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(78, 310);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 5;
            label1.Text = "Naziv:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 350);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 6;
            label2.Text = "Stepen obrazovanja:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 390);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 7;
            label3.Text = "Ustanova:";
            // 
            // btnOsvezi
            // 
            btnOsvezi.Location = new Point(78, 429);
            btnOsvezi.Name = "btnOsvezi";
            btnOsvezi.Size = new Size(75, 23);
            btnOsvezi.TabIndex = 8;
            btnOsvezi.Text = "Osvezi";
            btnOsvezi.UseVisualStyleBackColor = true;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(184, 429);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(75, 23);
            btnDodaj.TabIndex = 9;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(398, 429);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(75, 23);
            btnObrisi.TabIndex = 10;
            btnObrisi.Text = "Obrisi";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(291, 429);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(75, 23);
            btnIzmeni.TabIndex = 11;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(78, 23);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(75, 23);
            btnPretrazi.TabIndex = 12;
            btnPretrazi.Text = "Pretrazi";
            btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // FrmStrucneSpreme
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 493);
            Controls.Add(btnPretrazi);
            Controls.Add(btnIzmeni);
            Controls.Add(btnObrisi);
            Controls.Add(btnDodaj);
            Controls.Add(btnOsvezi);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUstanova);
            Controls.Add(txtStepenObr);
            Controls.Add(txtPretraga);
            Controls.Add(txtNaziv);
            Controls.Add(dgvStrucneSpreme);
            Name = "FrmStrucneSpreme";
            Text = "FrmStrucneSpreme";
            ((System.ComponentModel.ISupportInitialize)dgvStrucneSpreme).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvStrucneSpreme;
        private TextBox txtNaziv;
        private TextBox txtPretraga;
        private TextBox txtStepenObr;
        private TextBox txtUstanova;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnOsvezi;
        private Button btnDodaj;
        private Button btnObrisi;
        private Button btnIzmeni;
        private Button btnPretrazi;

        public Button BtnOsvezi { get => btnOsvezi; set => btnOsvezi = value; }
        public Button BtnDodaj { get => btnDodaj; set => btnDodaj = value; }
        public Button BtnObrisi { get => btnObrisi; set => btnObrisi = value; }
        public Button BtnIzmeni { get => btnIzmeni; set => btnIzmeni = value; }
        public Button BtnPretrazi { get => btnPretrazi; set => btnPretrazi = value; }
        public DataGridView DgvStrucneSpreme { get => dgvStrucneSpreme; set => dgvStrucneSpreme = value; }
        public TextBox TxtNaziv { get => txtNaziv; set => txtNaziv = value; }
        public TextBox TxtPretraga { get => txtPretraga; set => txtPretraga = value; }
        public TextBox TxtStepenObr { get => txtStepenObr; set => txtStepenObr = value; }
        public TextBox TxtUstanova { get => txtUstanova; set => txtUstanova = value; }
    }
}