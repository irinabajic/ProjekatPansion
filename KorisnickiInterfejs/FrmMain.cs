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
        private bool _kolegaRowClicked = false;
        private readonly GUIKontroler.KolegeKontroler _kolegeK = new GUIKontroler.KolegeKontroler();
        public FrmMain()
        {
            InitializeComponent();

  
            this.StartPosition = FormStartPosition.CenterScreen;
           // this.WindowState   = FormWindowState.Maximized;   // zauzmi ceo ekran (taskbar ostaje)
            dgvKolege.ReadOnly = true;
            dgvKolege.AutoGenerateColumns = true;
            dgvKolege.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKolege.MultiSelect = false;

            this.Load += (s, e) =>
            {
                _kolegeK.Osvezi(this);
                _kolegaRowClicked = false;
            };
            dgvKolege.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0) _kolegaRowClicked = true;
            };

            // Dvoklik = direktno Izmeni
            dgvKolege.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                _kolegaRowClicked = true;
                _kolegeK.Izmeni(this);
                _kolegaRowClicked = false;
            };

            // DODAJ (samo klik na dugme)
            btnDodajKolegu.Click += (s, e) => _kolegeK.Dodaj(this);

            // IZMENI (mora single-click na red + klik na dugme)
            btnIzmeniKolegu.Click += (s, e) =>
            {
                if (!_kolegaRowClicked || dgvKolege.CurrentRow?.DataBoundItem == null)
                {
                    MessageBox.Show("Najpre klikni na kolegu u tabeli, pa 'Izmeni'.");
                    return;
                }
                _kolegeK.Izmeni(this);
                _kolegaRowClicked = false;
            };

            // OBRIŠI (mora single-click na red + klik na dugme)
            btnObrisiKolegu.Click += (s, e) =>
            {
                if (!_kolegaRowClicked || dgvKolege.CurrentRow?.DataBoundItem == null)
                {
                    MessageBox.Show("Najpre klikni na kolegu u tabeli, pa 'Obriši'.");
                    return;
                }
                _kolegeK.Obrisi(this);
                _kolegaRowClicked = false;
            };


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
