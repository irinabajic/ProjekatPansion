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
            dgvPrijemniObrasci.AllowUserToAddRows = false;

            // početno stanje dugmadi
            btnIzmeni.Enabled = false;
            btnObrisi.Enabled = false;

            // učitaj listu i odmah očisti selekciju
            Load += (s, e) =>
            {
                kontroler.Osvezi(this);
                DeferClearSelection();
            };

            // svaki put kad se DataSource rebajnduje – gasi auto-selekciju 1. reda
            dgvPrijemniObrasci.DataBindingComplete += (s, e) => DeferClearSelection();

            // promene selekcije: uključi/isključi dugmad
            dgvPrijemniObrasci.SelectionChanged += (s, e) => UpdateButtonsState();

            // standardne akcije, uz reset UI posle
            btnOsvezi.Click += (s, e) => { kontroler.Osvezi(this); DeferClearSelection(); };
            btnPretrazi.Click += (s, e) => { kontroler.PretraziGrid(this); DeferClearSelection(); };
            btnDodaj.CausesValidation = false;
            btnDodaj.Click += (s, e) => { kontroler.Dodaj(this); AfterCrudReset(); };
            btnIzmeni.Click += (s, e) => { kontroler.Izmeni(this); AfterCrudReset(); };
            btnObrisi.Click += (s, e) => { kontroler.Obrisi(this); AfterCrudReset(); };
            btnPrikaziDetalje.Click += (s, e) => kontroler.PrikaziDetalje(this);

            // dvoklik otvara DETALJE (ne izmene)
            dgvPrijemniObrasci.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) kontroler.PrikaziDetalje(this);
            };
        }

        // — helpers —

        private void DeferClearSelection()
        {
            // odloženo, da pregazimo default selekciju prvog reda
            BeginInvoke(new Action(() =>
            {
                dgvPrijemniObrasci.ClearSelection();
                dgvPrijemniObrasci.CurrentCell = null;
                btnIzmeni.Enabled = btnObrisi.Enabled = false;
            }));
        }

        private void UpdateButtonsState()
        {
            bool has = dgvPrijemniObrasci.CurrentRow != null &&
                       dgvPrijemniObrasci.SelectedRows.Count > 0;
            btnIzmeni.Enabled = has;
            btnObrisi.Enabled = has;
        }

        private void AfterCrudReset()
        {
            kontroler.Osvezi(this);
            DeferClearSelection();
        }
    }
}
