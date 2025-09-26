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
    public partial class FrmPrijemniObrasci : Form
    {
        private GUIKontroler.PrijemniObrasciKontroler kontroler =
        new GUIKontroler.PrijemniObrasciKontroler();
        public FrmPrijemniObrasci()
        {
            InitializeComponent();

            dgvPrijemniObrasci.AutoGenerateColumns = false;
            dgvPrijemniObrasci.ReadOnly = true;
            dgvPrijemniObrasci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Load += FrmPrijemniObrasci_Load;
            btnOsvezi.Click += (s, e) => kontroler.Osvezi(this);
            btnDodaj.Click += (s, e) => kontroler.Dodaj(this);
            btnIzmeni.Click += (s, e) => kontroler.Izmeni(this);
            btnObrisi.Click += (s, e) => kontroler.Obrisi(this);
            btnPretrazi.Click += (s, e) => kontroler.Pretrazi(this);
            dgvPrijemniObrasci.CellDoubleClick += (s, e) => kontroler.PopuniDetaljeIzSelektovanog(this);
            btnPrikaziDetalje.Click += (s, e) =>
            {
                if (DgvPrijemniObrasci.CurrentRow?.DataBoundItem is Domen.PrijemniObrazac sel)
                {
                    using var frm = new FrmPrijemniDetalji(sel.IdPrijemniObrazac);
                    frm.ShowDialog(this);
                }
                else MessageBox.Show("Izaberi prijemni obrazac u tabeli.");
            };
            //dvoklik
            DgvPrijemniObrasci.CellDoubleClick += (s, e) => btnPrikaziDetalje.PerformClick();
        }



        private void FrmPrijemniObrasci_Load(object sender, EventArgs e)
        {
            kontroler.Osvezi(this);
            dgvPrijemniObrasci.SelectionChanged += (s, ev) => kontroler.PopuniDetaljeIzSelektovanog(this);
        }

        // public wrappere:
        public DataGridView DgvPrijemni { get => dgvPrijemniObrasci; set => dgvPrijemniObrasci = value; }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
