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
        private readonly GUIKontroler.MackeKontroler kontroler =
        new GUIKontroler.MackeKontroler();

        public FrmMacke()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            dgvMacke.AutoGenerateColumns = false;
            dgvMacke.ReadOnly = true;
            dgvMacke.MultiSelect = false;
            dgvMacke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMacke.AllowUserToAddRows = false;

            // početno stanje
            btnIzmeni.Enabled = false;
            btnObrisi.Enabled = false;

            // 1) učitaj i odmah očisti selekciju
            Load += (s, e) =>
            {
                kontroler.Osvezi(this);
                DeferClearSelection();
            };

            // 2) svaki refresh DataSource-a → očisti selekciju
            dgvMacke.DataBindingComplete += (s, e) => DeferClearSelection();

            // 3) kad korisnik izabere red → popuni polja + uključi dugmad
            dgvMacke.SelectionChanged += (s, e) => OnSelectionChanged();

            // tvoji postojeći handleri
            btnOsvezi.Click += (s, e) => kontroler.Osvezi(this);
            btnDodaj.Click += (s, e) => kontroler.Dodaj(this);
            btnIzmeni.Click += (s, e) => kontroler.Izmeni(this);
            btnObrisi.Click += (s, e) => kontroler.Obrisi(this);
            btnPretrazi.Click += (s, e) => kontroler.Pretrazi(this);
        }

        // — helpers —

        private void DeferClearSelection()
        {
            // posle što DataGridView interno selektuje 1. red
            BeginInvoke(new Action(() =>
            {
                dgvMacke.ClearSelection();
                dgvMacke.CurrentCell = null;
                btnIzmeni.Enabled = btnObrisi.Enabled = false;
                txtNaziv.Clear(); txtRasa.Clear(); txtNapomene.Clear();
            }));
        }

        private void OnSelectionChanged()
        {
            var has = dgvMacke.CurrentRow != null && dgvMacke.SelectedRows.Count > 0;

            btnIzmeni.Enabled = has;
            btnObrisi.Enabled = has;

            if (has && dgvMacke.CurrentRow.DataBoundItem is Domen.Macka m)
            {
                // auto-popuna polja
                txtNaziv.Text = m.Naziv;
                txtRasa.Text = m.Rasa;
                txtNapomene.Text = m.Napomene;
            }
            else
            {
                txtNaziv.Clear(); txtRasa.Clear(); txtNapomene.Clear();
            }

        }
    }
}
