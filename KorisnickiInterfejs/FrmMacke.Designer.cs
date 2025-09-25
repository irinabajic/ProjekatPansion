namespace KorisnickiInterfejs
{
    partial class FrmMacke
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
            dgvMacke = new DataGridView();
            txtNaziv = new TextBox();
            txtRasa = new TextBox();
            txtNapomene = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnOsvezi = new Button();
            btnDodaj = new Button();
            btnIzmeni = new Button();
            btnObrisi = new Button();
            btnPretrazi = new Button();
            txtPretraga = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvMacke).BeginInit();
            SuspendLayout();
            // 
            // dgvMacke
            // 
            dgvMacke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMacke.Location = new Point(87, 63);
            dgvMacke.Name = "dgvMacke";
            dgvMacke.Size = new Size(390, 215);
            dgvMacke.TabIndex = 0;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(191, 296);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(286, 23);
            txtNaziv.TabIndex = 1;
            // 
            // txtRasa
            // 
            txtRasa.Location = new Point(191, 337);
            txtRasa.Name = "txtRasa";
            txtRasa.Size = new Size(286, 23);
            txtRasa.TabIndex = 2;
            // 
            // txtNapomene
            // 
            txtNapomene.Location = new Point(191, 378);
            txtNapomene.Name = "txtNapomene";
            txtNapomene.Size = new Size(286, 23);
            txtNapomene.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 299);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 4;
            label1.Text = "Naziv:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 340);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 5;
            label2.Text = "Rasa:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 381);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 6;
            label3.Text = "Napomene:";
            // 
            // btnOsvezi
            // 
            btnOsvezi.Location = new Point(87, 436);
            btnOsvezi.Name = "btnOsvezi";
            btnOsvezi.Size = new Size(75, 23);
            btnOsvezi.TabIndex = 7;
            btnOsvezi.Text = "Osvezi";
            btnOsvezi.UseVisualStyleBackColor = true;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(191, 436);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(75, 23);
            btnDodaj.TabIndex = 8;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(297, 436);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(75, 23);
            btnIzmeni.TabIndex = 9;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(402, 436);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(75, 23);
            btnObrisi.TabIndex = 10;
            btnObrisi.Text = "Obrisi";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(87, 25);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(75, 23);
            btnPretrazi.TabIndex = 11;
            btnPretrazi.Text = "Pretrazi";
            btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // txtPretraga
            // 
            txtPretraga.Location = new Point(191, 26);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.Size = new Size(286, 23);
            txtPretraga.TabIndex = 12;
            // 
            // FrmMacke
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 501);
            Controls.Add(txtPretraga);
            Controls.Add(btnPretrazi);
            Controls.Add(btnObrisi);
            Controls.Add(btnIzmeni);
            Controls.Add(btnDodaj);
            Controls.Add(btnOsvezi);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNapomene);
            Controls.Add(txtRasa);
            Controls.Add(txtNaziv);
            Controls.Add(dgvMacke);
            Name = "FrmMacke";
            Text = "FrmMacke";
            ((System.ComponentModel.ISupportInitialize)dgvMacke).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMacke;
        private TextBox txtNaziv;
        private TextBox txtRasa;
        private TextBox txtNapomene;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnOsvezi;
        private Button btnDodaj;
        private Button btnIzmeni;
        private Button btnObrisi;
        private Button btnPretrazi;
        private TextBox txtPretraga;

        public DataGridView DgvMacke { get => dgvMacke; set => dgvMacke = value; }
        public TextBox TxtNaziv { get => txtNaziv; set => txtNaziv = value; }
        public TextBox TxtRasa { get => txtRasa; set => txtRasa = value; }
        public TextBox TxtNapomene { get => txtNapomene; set => txtNapomene = value; }
        public Button BtnPretrazi { get => btnPretrazi; set => btnPretrazi = value; }
        public TextBox TxtPretraga { get => txtPretraga; set => txtPretraga = value; }
    }
}