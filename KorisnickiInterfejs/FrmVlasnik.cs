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
        private readonly VlasnikKontroler kontroler = new VlasnikKontroler();

        public FrmVlasnik()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            dgvVlasnici.AutoGenerateColumns = false;
            dgvVlasnici.ReadOnly = true;
            dgvVlasnici.MultiSelect = false;
            dgvVlasnici.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVlasnici.AllowUserToAddRows = false;

            // početno stanje
            btnIzmeni.Enabled = false;
            btnObrisi.Enabled = false;

            // učitaj i odmah očisti selekciju + polja
            Load += (_, __) =>
            {
                kontroler.Osvezi(this);
                DeferClearSelection_Vlasnik();
            };

            // svaki rebind data source-a → gasi auto-selekciju 1. reda
            dgvVlasnici.DataBindingComplete += (_, __) => DeferClearSelection_Vlasnik();

            // izbor reda: popuni polja i uključi dugmad; bez izbora: očisti i disable
            dgvVlasnici.SelectionChanged += (_, __) => OnSelectionChanged_Vlasnik();

            // postojeći handleri, ali posle CRUD-a resetuj UI
            btnOsvezi.Click += (_, __) => { kontroler.Osvezi(this); DeferClearSelection_Vlasnik(); };
            btnPretrazi.Click += (_, __) => { kontroler.Pretrazi(this); DeferClearSelection_Vlasnik(); };

            btnDodaj.Click += (_, __) => { kontroler.Dodaj(this); AfterCrud_Vlasnik(); };
            btnIzmeni.Click += (_, __) => { kontroler.Izmeni(this); AfterCrud_Vlasnik(); };
            btnObrisi.Click += (_, __) => { kontroler.Obrisi(this); AfterCrud_Vlasnik(); };

            // dvoklik – samo popuni polja (ne otvaramo ništa dodatno)
            dgvVlasnici.CellDoubleClick += (_, __) => OnSelectionChanged_Vlasnik();
        }

        private void OnSelectionChanged_Vlasnik()
        {
            bool has = dgvVlasnici.CurrentRow != null && dgvVlasnici.SelectedRows.Count > 0;
            btnIzmeni.Enabled = has;
            btnObrisi.Enabled = has;

            if (has) kontroler.PopuniDetaljeIzSelektovanog(this);
            else ClearInputs(this);
        }

        private void DeferClearSelection_Vlasnik()
        {
            BeginInvoke(new Action(() =>
            {
                dgvVlasnici.ClearSelection();
                dgvVlasnici.CurrentCell = null;
                btnIzmeni.Enabled = btnObrisi.Enabled = false;
                ClearInputs(this);
            }));
        }

        private void AfterCrud_Vlasnik()
        {
            kontroler.Osvezi(this);
            DeferClearSelection_Vlasnik();
        }

        // generički čistac – ne moraš da znaš imena polja
        private void ClearInputs(Control root)
        {
            foreach (Control c in root.Controls)
            {
                if (c is TextBox tb) tb.Clear();
                else if (c is ComboBox cb) cb.SelectedIndex = -1;
                else if (c.HasChildren) ClearInputs(c);
            }
        }
    }
}
