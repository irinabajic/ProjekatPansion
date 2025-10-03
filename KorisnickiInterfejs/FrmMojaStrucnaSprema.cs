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
            StartPosition = FormStartPosition.CenterScreen;

            // ↓↓↓ zameni naziv grida ako je drugačiji
            dgvRSS.AutoGenerateColumns = false;
            dgvRSS.ReadOnly = true;
            dgvRSS.MultiSelect = false;
            dgvRSS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRSS.AllowUserToAddRows = false;

            // početno stanje dugmadi
            BtnIzmeni.Enabled = false;
            BtnObrisi.Enabled = false;

            // učitavanje + odmah gasi auto selekciju prvog reda
            Load += (s, e) =>
            {
                kontroler.Inicijalizuj(this);
                DeferClearSelection();
            };

            // svaki rebind DataSource-a → pregazi default selekciju
            dgvRSS.DataBindingComplete += (s, e) => DeferClearSelection();

            // kad korisnik izabere red → uključi/isključi dugmad
            dgvRSS.SelectionChanged += (s, e) => UpdateButtonsState();

            // postojeći handleri + reset posle akcije
            BtnDodaj.Click += (s, e) => { kontroler.Dodaj(this); AfterCrudReset(); };
            BtnIzmeni.Click += (s, e) => { kontroler.Izmeni(this); AfterCrudReset(); };
            BtnObrisi.Click += (s, e) => { kontroler.Obrisi(this); AfterCrudReset(); };
        }

        // — helpers —

        private void DeferClearSelection()
        {
            // odloženo: posle bindovanja DGV ume da auto-selektuje 1. red
            BeginInvoke(new Action(() =>
            {
                dgvRSS.ClearSelection();
                dgvRSS.CurrentCell = null;
                BtnIzmeni.Enabled = BtnObrisi.Enabled = false;
                ClearInputs(this); // po želji očisti textbox-e/combobox-e na formi
            }));
        }

        private void UpdateButtonsState()
        {
            bool has = dgvRSS.CurrentRow != null && dgvRSS.SelectedRows.Count > 0;
            BtnIzmeni.Enabled = has;
            BtnObrisi.Enabled = has;

            // Ako želiš auto-popunu polja pri selekciji, uradi ovde:
            // if (has) kontroler.PopuniDetaljeIzSelektovanog(this);
            // else     ClearInputs(this);
        }

        private void AfterCrudReset()
        {
            kontroler.Osvezi(this);
            DeferClearSelection();
        }

        // generičko čišćenje inputa (ako želiš da se polja prazne posle akcija)
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
