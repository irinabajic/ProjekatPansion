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

            this.StartPosition = FormStartPosition.CenterParent; // da se otvori po sredini
            btnRegistruj.Click += (s, e) => _ctrl.Registruj(this);
            txtPassword.UseSystemPasswordChar = true;
            txtPotvrda.UseSystemPasswordChar = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
