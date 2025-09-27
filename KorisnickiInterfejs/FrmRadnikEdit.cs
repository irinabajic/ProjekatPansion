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

namespace KorisnickiInterfejs.GUIKontroler
{
    public partial class FrmRadnikEdit : Form
    {
        private Radnik _model = new Radnik();
        private bool _createMode;

        // Edit: korisnik menja lozinku ako je popunio NOVU lozinku
        public bool ZahtevaPromenuLozinke => !_createMode && !string.IsNullOrWhiteSpace(txtNoviPassword.Text);
        public string StaraLozinka => txtPassword.Text?.Trim() ?? "";
        public string NovaLozinka => txtNoviPassword.Text?.Trim() ?? "";

        public FrmRadnikEdit()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;

            txtPassword.UseSystemPasswordChar = true;
            txtNoviPassword.UseSystemPasswordChar = true;

            this.AcceptButton = btnOK;
            btnOK.Click += (s, e) =>
            {
                if (ValidateInputs()) this.DialogResult = DialogResult.OK;
            };
        }
        public void InitForCreate()
        {
            _createMode = true;
            _model = new Radnik();

            Text = "Novi radnik";
            txtIme.Text = txtUser.Text = txtTelefon.Text = "";
            txtPassword.Text = txtNoviPassword.Text = "";

            txtUser.Enabled = true;

            // Create: koristi se samo početna lozinka (txtPassword)
            txtPassword.Visible = true;
            if (lblNoviPassword != null) lblNoviPassword.Visible = false;
            txtNoviPassword.Visible = false;
        }

        public void InitForEdit(Radnik r)
        {
            _createMode = false;
            _model = r ?? new Radnik();

            Text = "Izmena radnika";
            txtIme.Text = _model.Ime ?? "";
            txtUser.Text = _model.Username ?? "";
            txtTelefon.Text = _model.BrojTelefona ?? "";

            txtUser.Enabled = true; // dozvoli izmenu username-a

            // EDIT: Prikaži OBA polja – Password = TRENUTNA, Novi password = NOVA
            txtPassword.Text = "";
            txtPassword.Visible = true;

            if (lblNoviPassword != null) lblNoviPassword.Visible = true;
            txtNoviPassword.Visible = true;
            txtNoviPassword.Text = "";
        }

        public Radnik ToRadnik()
        {
            return new Radnik
            {
                IdRadnik = _model.IdRadnik,
                Ime = txtIme.Text?.Trim() ?? "",
                Username = txtUser.Text?.Trim() ?? "",
                BrojTelefona = txtTelefon.Text?.Trim() ?? "",
                // U EDIT mod-u lozinka se NE šalje ovde (ide posebnom operacijom)
                Password = _createMode ? (txtPassword.Text?.Trim() ?? "") : "",
                Prijavljen = _model.Prijavljen
            };
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            { MessageBox.Show("Ime je obavezno."); return false; }

            if (string.IsNullOrWhiteSpace(txtUser.Text))
            { MessageBox.Show("Username je obavezan."); return false; }

            if (_createMode)
            {
                var p = txtPassword.Text?.Trim() ?? "";
                if (p.Length < 4) { MessageBox.Show("Lozinka mora imati najmanje 4 znaka."); return false; }
            }
            else
            {
                // Ako menjamo lozinku – obavezna je trenutna + minimalna dužina nove
                if (ZahtevaPromenuLozinke)
                {
                    if (string.IsNullOrWhiteSpace(StaraLozinka))
                    { MessageBox.Show("Unesi trenutnu lozinku."); return false; }
                    if (NovaLozinka.Length < 4)
                    { MessageBox.Show("Nova lozinka mora imati najmanje 4 znaka."); return false; }
                }
            }

            return true;


        }
     }
}
