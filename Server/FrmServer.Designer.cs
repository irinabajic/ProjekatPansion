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
            SuspendLayout();
            // 
            // btnPokreni
            // 
            btnPokreni.Location = new Point(119, 77);
            btnPokreni.Name = "btnPokreni";
            btnPokreni.Size = new Size(139, 41);
            btnPokreni.TabIndex = 0;
            btnPokreni.Text = "Pokreni";
            btnPokreni.UseVisualStyleBackColor = true;
            // 
            // btnZaustavi
            // 
            btnZaustavi.Location = new Point(301, 77);
            btnZaustavi.Name = "btnZaustavi";
            btnZaustavi.Size = new Size(139, 41);
            btnZaustavi.TabIndex = 1;
            btnZaustavi.Text = "Zaustavi";
            btnZaustavi.UseVisualStyleBackColor = true;
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 224);
            Controls.Add(btnZaustavi);
            Controls.Add(btnPokreni);
            Name = "FrmServer";
            Text = "FrmServer";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPokreni;
        private Button btnZaustavi;
    }
}
