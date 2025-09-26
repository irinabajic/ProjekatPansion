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
    public partial class FrmStrucneSpreme : Form
    {
        private StrucnaSpremaKontroler kontroler = new StrucnaSpremaKontroler();
        public FrmStrucneSpreme()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dgvStrucneSpreme.AutoGenerateColumns = false;
            dgvStrucneSpreme.ReadOnly = true;
            dgvStrucneSpreme.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Load += FrmStrucneSpreme_Load;
            btnOsvezi.Click += (s, e) => kontroler.Osvezi(this);
            btnDodaj.Click += (s, e) => kontroler.Dodaj(this);
            btnIzmeni.Click += (s, e) => kontroler.Izmeni(this);
            btnObrisi.Click += (s, e) => kontroler.Obrisi(this);
            btnPretrazi.Click += (s, e) => kontroler.Pretrazi(this);
            dgvStrucneSpreme.CellDoubleClick += (s, e) => kontroler.PopuniDetaljeIzSelektovanog(this);
        }

        private void FrmStrucneSpreme_Load(object sender, EventArgs e)
        {
            kontroler.Osvezi(this);
            dgvStrucneSpreme.SelectionChanged += (s, ev) => kontroler.PopuniDetaljeIzSelektovanog(this);
        }


    }
}
