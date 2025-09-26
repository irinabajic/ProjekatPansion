using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace KorisnickiInterfejs
{
    public partial class FrmMojProfil : Form
    {
        private readonly MojProfilKontroler _ctrl = new MojProfilKontroler();
        private Radnik? _ulogovan; // prosleđuje se preko overload konstruktora

        // VAŽNO: ostavi i prazan konstruktor zbog WinForms dizajnera
        public FrmMojProfil()
        {
            InitializeComponent();
            WireUpUi();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Overload koji koristiš iz glavne forme: new FrmMojProfil(Session.TrenutniRadnik)
        public FrmMojProfil(Radnik ulogovan) : this()
        {
            _ulogovan = ulogovan ?? throw new ArgumentNullException(nameof(ulogovan));
        }

        private void WireUpUi()
        {
            // UX sitnice
            this.AcceptButton = btnSacuvaj;
            this.CancelButton = btnOdustani;
            this.StartPosition = FormStartPosition.CenterParent;

            txtPassword.UseSystemPasswordChar = true;

            // eventi
            this.Load += FrmMojProfil_Load;
            btnSacuvaj.Click += (s, e) => Sacuvaj();
            btnOdustani.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private void FrmMojProfil_Load(object? sender, EventArgs e)
        {
            if (_ulogovan == null) return;

            // popuna polja
            txtIme.Text = _ulogovan.Ime;
            txtTelefon.Text = _ulogovan.BrojTelefona;
            txtUsername.Text = _ulogovan.Username;
            txtPassword.Text = _ulogovan.Password;
        }

        private void Sacuvaj()
        {
            if (_ulogovan == null)
            {
                MessageBox.Show("Nije prosleđen ulogovani radnik.");
                return;
            }

            // brza validacija pre slanja
            if (string.IsNullOrWhiteSpace(txtIme.Text) ||
                string.IsNullOrWhiteSpace(txtTelefon.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Sva polja su obavezna.");
                return;
            }

            try
            {
                var ok = _ctrl.Sacuvaj(this, _ulogovan);
                if (ok)
                {
                    MessageBox.Show("Podaci su sačuvani.", "Moj profil",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }

    }
}

