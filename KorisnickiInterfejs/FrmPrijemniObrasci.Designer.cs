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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtDatum = new TextBox();
            txtIdVlasnik = new TextBox();
            txtIdRadnik = new TextBox();
            btnOsvezi = new Button();
            btnDodaj = new Button();
            btnIzmeni = new Button();
            btnObrisi = new Button();
            btnPretrazi = new Button();
            txtPretraga = new TextBox();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 307);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 1;
            label1.Text = "Datum:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 343);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Radnik ID:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 377);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 3;
            label3.Text = "Vlasnik ID:";
            // 
            // txtDatum
            // 
            txtDatum.Location = new Point(170, 304);
            txtDatum.Name = "txtDatum";
            txtDatum.Size = new Size(326, 23);
            txtDatum.TabIndex = 4;
            // 
            // txtIdVlasnik
            // 
            txtIdVlasnik.Location = new Point(170, 374);
            txtIdVlasnik.Name = "txtIdVlasnik";
            txtIdVlasnik.Size = new Size(326, 23);
            txtIdVlasnik.TabIndex = 5;
            // 
            // txtIdRadnik
            // 
            txtIdRadnik.Location = new Point(170, 340);
            txtIdRadnik.Name = "txtIdRadnik";
            txtIdRadnik.Size = new Size(326, 23);
            txtIdRadnik.TabIndex = 6;
            // 
            // btnOsvezi
            // 
            btnOsvezi.Location = new Point(56, 422);
            btnOsvezi.Name = "btnOsvezi";
            btnOsvezi.Size = new Size(75, 23);
            btnOsvezi.TabIndex = 7;
            btnOsvezi.Text = "Osvezi";
            btnOsvezi.UseVisualStyleBackColor = true;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(174, 422);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(75, 23);
            btnDodaj.TabIndex = 8;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(299, 422);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(75, 23);
            btnIzmeni.TabIndex = 9;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(421, 422);
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
            // FrmPrijemniObrasci
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 496);
            Controls.Add(txtPretraga);
            Controls.Add(btnPretrazi);
            Controls.Add(btnObrisi);
            Controls.Add(btnIzmeni);
            Controls.Add(btnDodaj);
            Controls.Add(btnOsvezi);
            Controls.Add(txtIdRadnik);
            Controls.Add(txtIdVlasnik);
            Controls.Add(txtDatum);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvPrijemniObrasci);
            Name = "FrmPrijemniObrasci";
            Text = "FrmPrijemniObrasci";
            ((System.ComponentModel.ISupportInitialize)dgvPrijemniObrasci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPrijemniObrasci;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtDatum;
        private TextBox txtIdVlasnik;
        private TextBox txtIdRadnik;
        private Button btnOsvezi;
        private Button btnDodaj;
        private Button btnIzmeni;
        private Button btnObrisi;
        private Button btnPretrazi;
        private TextBox txtPretraga;

        public TextBox TxtDatum { get => txtDatum; set => txtDatum = value; }
        public TextBox TxtIdVlasnik { get => txtIdVlasnik; set => txtIdVlasnik = value; }
        public TextBox TxtIdRadnik { get => txtIdRadnik; set => txtIdRadnik = value; }
        public Button BtnOsvezi { get => btnOsvezi; set => btnOsvezi = value; }
        public Button BtnDodaj { get => btnDodaj; set => btnDodaj = value; }
        public Button BtnIzmeni { get => btnIzmeni; set => btnIzmeni = value; }
        public Button BtnObrisi { get => btnObrisi; set => btnObrisi = value; }
        public Button BtnPretrazi { get => btnPretrazi; set => btnPretrazi = value; }
        public DataGridView DgvPrijemniObrasci { get => dgvPrijemniObrasci; set => dgvPrijemniObrasci = value; }
        public TextBox TxtPretraga { get => txtPretraga; set => txtPretraga = value; }
    }
}