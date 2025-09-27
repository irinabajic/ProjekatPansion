using AplikacionaLogika;
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
    public partial class FrmMojaStrucnaSprema : Form
    {
        private readonly MojeRSSKontroler kontroler = new MojeRSSKontroler();
        public FrmMojaStrucnaSprema()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.Load += (s, e) => kontroler.Inicijalizuj(this);
            BtnOsvezi.Click += (s, e) => kontroler.Osvezi(this);
            BtnDodaj.Click += (s, e) => kontroler.Dodaj(this);
            BtnIzmeni.Click += (s, e) => kontroler.Izmeni(this);
            BtnObrisi.Click += (s, e) => kontroler.Obrisi(this);
        }
    }
}
