using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmDbUrl : Form
    {
        public FrmDbUrl()
        {
            InitializeComponent();
            Load += (_, __) => txtUrl.Text = DbUrl.Current;

            btnTest.Click += (_, __) =>
            {
                try
                {
                    using var c = new SqlConnection(txtUrl.Text);
                    c.Open();
                    MessageBox.Show("Konekcija uspešna.", "Test");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspešno: " + ex.Message, "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnSacuvaj.Click += (_, __) =>
            {
                DbUrl.Save(txtUrl.Text);
                MessageBox.Show("Sačuvano. Nova podešavanja važe pri sledećem otvaranju konekcije.", "OK");
                Close();
            };
        }
    }
}
