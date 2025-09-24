namespace Server
{
    partial class FrmServer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPokreni = new Button();
            btnZaustavi = new Button();
            dgvRadnici = new DataGridView();
            lblRadnici = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRadnici).BeginInit();
            SuspendLayout();
            // 
            // btnPokreni
            // 
            btnPokreni.Location = new Point(118, 255);
            btnPokreni.Name = "btnPokreni";
            btnPokreni.Size = new Size(139, 41);
            btnPokreni.TabIndex = 0;
            btnPokreni.Text = "Pokreni";
            btnPokreni.UseVisualStyleBackColor = true;
            btnPokreni.Click += btnPokreni_Click;
            // 
            // btnZaustavi
            // 
            btnZaustavi.Location = new Point(317, 255);
            btnZaustavi.Name = "btnZaustavi";
            btnZaustavi.Size = new Size(139, 41);
            btnZaustavi.TabIndex = 1;
            btnZaustavi.Text = "Zaustavi";
            btnZaustavi.UseVisualStyleBackColor = true;
            btnZaustavi.Click += btnZaustavi_Click;
            // 
            // dgvRadnici
            // 
            dgvRadnici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRadnici.Location = new Point(28, 55);
            dgvRadnici.Name = "dgvRadnici";
            dgvRadnici.Size = new Size(517, 171);
            dgvRadnici.TabIndex = 2;
            // 
            // lblRadnici
            // 
            lblRadnici.AutoSize = true;
            lblRadnici.Location = new Point(25, 28);
            lblRadnici.Name = "lblRadnici";
            lblRadnici.Size = new Size(100, 15);
            lblRadnici.TabIndex = 3;
            lblRadnici.Text = "Prijavljeni radnici:";
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 359);
            Controls.Add(lblRadnici);
            Controls.Add(dgvRadnici);
            Controls.Add(btnZaustavi);
            Controls.Add(btnPokreni);
            Name = "FrmServer";
            Text = "FrmServer";
            Load += FrmServer_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRadnici).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPokreni;
        private Button btnZaustavi;
        private DataGridView dgvRadnici;
        private Label lblRadnici;
    }
}
