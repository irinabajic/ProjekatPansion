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

  
            this.StartPosition = FormStartPosition.CenterScreen;
           // this.WindowState   = FormWindowState.Maximized;   // zauzmi ceo ekran (taskbar ostaje)
            dgvKolege.ReadOnly = true;
            dgvKolege.AutoGenerateColumns = true;
            dgvKolege.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnIzmeni.Click += (s, e) =>
            {
                using var frm = new FrmMojProfil(Session.Session.Instance.PrijavljeniRadnik);
                if (frm.ShowDialog() == DialogResult.OK)
                    OsveziMojePodatkeNaEkranu();
            };
            btnMojaStrucnaSprema.Click += (s, e) =>
            {
                if (!Session.Session.Instance.JePrijavljen)
                {
                    MessageBox.Show("Prijavi se prvo.");
                    return;
                }

                using var frm = new FrmMojaStrucnaSprema();
                frm.StartPosition = FormStartPosition.CenterParent; // kao i kod profila
                frm.ShowDialog(this);
            };
        }

        private void OsveziMojePodatkeNaEkranu()
        {
            // prilagodi imenima svojih labela:
            lblImeIPrezime.Text = $"{Session.Session.Instance.PrijavljeniRadnik.Ime}";
            lblUsername.Text = $"{Session.Session.Instance.PrijavljeniRadnik.Username}";
            lblTelefon.Text = Session.Session.Instance.PrijavljeniRadnik.BrojTelefona;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            kontroler.Init(this);
            kontroler.UcitajKolege(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                var r = Session.Session.Instance.PrijavljeniRadnik;
                if (r != null)
                    Komunikacija.Instance.PosaljiZahtev<object>(Operacija.Logout, r.IdRadnik);

                Session.Session.Instance.PrijavljeniRadnik = null;

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

        private void btnPrikaziMacke_Click(object sender, EventArgs e)
        {
            using (var f = new FrmMacke())
                f.ShowDialog();
        }

        private void btnPrikaziVlasnike_Click(object sender, EventArgs e)
        {
            using (var f = new FrmVlasnik())
                f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var f = new FrmPrijemniObrasci())
                f.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrikaziStrucne_Click(object sender, EventArgs e)
        {
            using (var f = new FrmStrucneSpreme())
                f.ShowDialog();
        }
    }
}
