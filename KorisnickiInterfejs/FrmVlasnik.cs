using AplikacionaLogika;
using Domen;
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
    public partial class FrmVlasnik : Form
    {
        private VlasnikKontroler kontroler = new VlasnikKontroler();

        public FrmVlasnik()
        {
            InitializeComponent();

            dgvVlasnici.AutoGenerateColumns = false;
            dgvVlasnici.ReadOnly = true;
            dgvVlasnici.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Load += FrmVlasnik_Load;
            btnOsvezi.Click += (s, e) => kontroler.Osvezi(this);
            btnDodaj.Click += (s, e) => kontroler.Dodaj(this);
            btnIzmeni.Click += (s, e) => kontroler.Izmeni(this);
            btnObrisi.Click += (s, e) => kontroler.Obrisi(this);
            btnPretrazi.Click += (s, e) => kontroler.Pretrazi(this);
            dgvVlasnici.CellDoubleClick += (s, e) => kontroler.PopuniDetaljeIzSelektovanog(this);
        }

        private void FrmVlasnik_Load(object sender, EventArgs e)
        {
            kontroler.Osvezi(this);
            dgvVlasnici.SelectionChanged += (s, ev) => kontroler.PopuniDetaljeIzSelektovanog(this);
        }
    }
}
