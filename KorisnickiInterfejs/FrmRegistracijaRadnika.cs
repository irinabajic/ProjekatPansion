using KorisnickiInterfejs.GUIKontroler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorisnickiInterfejs
{
    public partial class FrmRegistracijaRadnika : Form
    {
        private readonly RegistracijaRadnikaKontroler _ctrl = new RegistracijaRadnikaKontroler();

        public FrmRegistracijaRadnika()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;

            txtPassword.UseSystemPasswordChar = true;
            txtPotvrda.UseSystemPasswordChar = true;

            // (opciono) probaj da se povežeš čim se forma otvori
            this.Load += (_, __) =>
            {
                try { Komunikacija.Instance.EnsureConnected(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Server nije dostupan: " + ex.Message);
                    Close();
                }
            };

            // pre registracije obavezno obezbedi konekciju
            btnRegistruj.Click += (s, e) =>
            {
                try { Komunikacija.Instance.EnsureConnected(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mogu da uspostavim vezu: " + ex.Message);
                    return;
                }

                _ctrl.Registruj(this);
            };
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
