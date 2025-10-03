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
        private readonly GUIKontroler.KolegeKontroler _kolegeK = new GUIKontroler.KolegeKontroler();
        public FrmMain()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            dgvKolege.ReadOnly = true;
            dgvKolege.AutoGenerateColumns = true;
            dgvKolege.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKolege.MultiSelect = false;
            dgvKolege.AllowUserToAddRows = false;

            OsveziMojePodatkeNaEkranu();

            // 🔒 početno stanje
            btnIzmeniKolegu.Enabled = false;
            btnObrisiKolegu.Enabled = false;

            // učitaj i očisti selekciju
            Load += (s, e) =>
            {
                _kolegeK.Osvezi(this);
                DeferClearSelection();
            };

            // svaki rebind DataSource-a → SSMS auto-selektuje 1. red, pa gasimo
            dgvKolege.DataBindingComplete += (s, e) => DeferClearSelection();

            // izbor reda → uključi/isključi dugmad
            dgvKolege.SelectionChanged += (s, e) => UpdateButtonsState();

            // Dvoklik = Izmeni + reset posle
            dgvKolege.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                _kolegeK.Izmeni(this);
                AfterCrudReset();
            };

            // DODAJ → posle dodavanja reset
            btnDodajKolegu.Click += (s, e) =>
            {
                _kolegeK.Dodaj(this);
                AfterCrudReset();
            };

            // IZMENI → nema više ručnih provera, dugme je disabled dok nema selekcije
            btnIzmeniKolegu.Click += (s, e) =>
            {
                _kolegeK.Izmeni(this);
                AfterCrudReset();
            };

            // OBRIŠI → reset posle
            btnObrisiKolegu.Click += (s, e) =>
            {
                _kolegeK.Obrisi(this);
                AfterCrudReset();
            };

            // ostalo ostaje kako je
            btnIzmeni.Click += (s, e) =>
            {
                using var frm = new FrmMojProfil(Session.Session.Instance.PrijavljeniRadnik);
                if (frm.ShowDialog() == DialogResult.OK) OsveziMojePodatkeNaEkranu();
            };

            btnMojaStrucnaSprema.Click += (s, e) =>
            {
                if (!Session.Session.Instance.JePrijavljen)
                { MessageBox.Show("Prijavi se prvo."); return; }

                using var frm = new FrmMojaStrucnaSprema { StartPosition = FormStartPosition.CenterParent };
                frm.ShowDialog(this);
            };
        }

        private void DeferClearSelection()
        {
            // odloženo da pregazimo default selekciju posle bindovanja
            BeginInvoke(new Action(() =>
            {
                dgvKolege.ClearSelection();
                dgvKolege.CurrentCell = null;
                btnIzmeniKolegu.Enabled = false;
                btnObrisiKolegu.Enabled = false;
            }));
        }

        private void UpdateButtonsState()
        {
            bool has = dgvKolege.CurrentRow != null && dgvKolege.SelectedRows.Count > 0;
            btnIzmeniKolegu.Enabled = has;
            btnObrisiKolegu.Enabled = has;
        }

        private void AfterCrudReset()
        {
            _kolegeK.Osvezi(this);
            DeferClearSelection();
        }

        // (tvoja postojeća metoda ostaje)
        private void OsveziMojePodatkeNaEkranu()
        {
            lblImeIPrezime.Text = Session.Session.Instance.PrijavljeniRadnik.Ime;
            lblUsername.Text = Session.Session.Instance.PrijavljeniRadnik.Username;
            lblTelefon.Text = Session.Session.Instance.PrijavljeniRadnik.BrojTelefona;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            kontroler.Init(this);
            kontroler.UcitajKolege(this);
            DeferClearSelection(); // sigurnosti radi
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
