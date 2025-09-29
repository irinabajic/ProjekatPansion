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
            StartPosition = FormStartPosition.CenterScreen;

            dgvPrijemniObrasci.AutoGenerateColumns = false;
            dgvPrijemniObrasci.ReadOnly = true;
            dgvPrijemniObrasci.MultiSelect = false;
            dgvPrijemniObrasci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Load += (s, e) =>
            {
                kontroler.Osvezi(this);
                // opciono: svaki put kad promeniš selekciju možeš pokazati preview, ali nije obavezno
                // dgvPrijemniObrasci.SelectionChanged += (s2, e2) => kontroler.PopuniDetaljeIzSelektovanog(this);
            };

            btnOsvezi.Click += (s, e) => kontroler.Osvezi(this);
            btnPretrazi.Click += (s, e) => kontroler.PretraziGrid(this);

            // NOVO: sva logika ide u kontroler
            btnDodaj.CausesValidation = false;
            btnDodaj.Click += (s, e) => kontroler.Dodaj(this);

            btnIzmeni.Click += (s, e) => kontroler.Izmeni(this);

            btnObrisi.Click += (s, e) => kontroler.Obrisi(this);
            btnPrikaziDetalje.Click += (s, e) => kontroler.PrikaziDetalje(this);

            // NOVO: dvoklik u gridu otvara detalje (ne izmene)
            dgvPrijemniObrasci.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) // ignoriši header
                    kontroler.PrikaziDetalje(this);
            };

        }



        private void FrmPrijemniObrasci_Load(object sender, EventArgs e)
        {
            kontroler.Osvezi(this);
            
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
