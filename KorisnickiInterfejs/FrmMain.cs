using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicki;

namespace KorisnickiInterfejs
{
    public partial class FrmMain : Form
    {
        private GUIKontroler.MainKontroler kontroler = new GUIKontroler.MainKontroler();

        public FrmMain()
        {
            InitializeComponent();
            dgvKolege.ReadOnly = true;
            dgvKolege.AutoGenerateColumns = true;
            dgvKolege.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            kontroler.Init(this);         // popuni levo
            kontroler.UcitajKolege(this); // napuni grid desno
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                var r = Session.Session.Instance.PrijavljeniRadnik;
                if (r != null)
                    Komunikacija.Instance.PosaljiZahtev<object>(Operacija.Logout, r.IdRadnik);

                Session.Session.Instance.PrijavljeniRadnik = null; // ili .Logout()
                                                                   // vrati se na login
                Hide();
                using (var f = new FrmLogin())
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        // učitaj nove podatke za novog korisnika
                        Show();
                        new GUIKontroler.MainKontroler().Init(this);
                        new GUIKontroler.MainKontroler().UcitajKolege(this);
                    }
                    else
                    {
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
