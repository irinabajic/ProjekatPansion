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
    public partial class FrmMacke : Form
    {
        private GUIKontroler.MackeKontroler kontroler = new GUIKontroler.MackeKontroler();

        public FrmMacke()
        {
            InitializeComponent();

            dgvMacke.AutoGenerateColumns = false;
            dgvMacke.ReadOnly = true;
            dgvMacke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
            this.Load += FrmMacke_Load;
            btnOsvezi.Click += (s, e) => kontroler.Osvezi(this);
            btnDodaj.Click += (s, e) => kontroler.Dodaj(this);
            btnIzmeni.Click += (s, e) => kontroler.Izmeni(this);
            btnObrisi.Click += (s, e) => kontroler.Obrisi(this);
            btnPretrazi.Click += (s, e) => kontroler.Pretrazi(this);
            dgvMacke.CellDoubleClick += (s, e) => kontroler.PopuniDetaljeIzSelektovanog(this);
        }

        private void FrmMacke_Load(object sender, EventArgs e)
        {
            kontroler.Osvezi(this);
            dgvMacke.SelectionChanged += (s, ev) => kontroler.PopuniDetaljeIzSelektovanog(this);
        }

        
    }
}
