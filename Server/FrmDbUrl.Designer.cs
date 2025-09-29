namespace Server
{
    partial class FrmDbUrl
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
            txtUrl = new TextBox();
            btnTest = new Button();
            btnSacuvaj = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 79);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "URL:";
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(110, 76);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(214, 23);
            txtUrl.TabIndex = 1;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(73, 111);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(110, 23);
            btnTest.TabIndex = 2;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(214, 111);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(110, 23);
            btnSacuvaj.TabIndex = 3;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(73, 24);
            label2.Name = "label2";
            label2.Size = new Size(137, 21);
            label2.TabIndex = 4;
            label2.Text = "Konfiguracija baze";
            // 
            // FrmDbUrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 180);
            Controls.Add(label2);
            Controls.Add(btnSacuvaj);
            Controls.Add(btnTest);
            Controls.Add(txtUrl);
            Controls.Add(label1);
            Name = "FrmDbUrl";
            Text = "FrmDbUrl";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUrl;
        private Button btnTest;
        private Button btnSacuvaj;
        private Label label2;

        public Label Label1 { get => label1; set => label1 = value; }
        public TextBox TxtUrl { get => txtUrl; set => txtUrl = value; }
        public Button BtnTest { get => btnTest; set => btnTest = value; }
        public Button BtnSacuvaj { get => btnSacuvaj; set => btnSacuvaj = value; }
        public Label Label2 { get => label2; set => label2 = value; }
    }
}