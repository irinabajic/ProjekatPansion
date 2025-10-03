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
            StartPosition = FormStartPosition.CenterScreen;

            dgvStrucneSpreme.AutoGenerateColumns = false;
            dgvStrucneSpreme.ReadOnly = true;
            dgvStrucneSpreme.MultiSelect = false;
            dgvStrucneSpreme.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStrucneSpreme.AllowUserToAddRows = false;

            btnIzmeni.Enabled = false;
            btnObrisi.Enabled = false;

            Load += (_, __) =>
            {
                kontroler.Osvezi(this);
                DeferClearSelection_SS();
            };

            dgvStrucneSpreme.DataBindingComplete += (_, __) => DeferClearSelection_SS();
            dgvStrucneSpreme.SelectionChanged += (_, __) => OnSelectionChanged_SS();

            btnOsvezi.Click += (_, __) => { kontroler.Osvezi(this); DeferClearSelection_SS(); };
            btnPretrazi.Click += (_, __) => { kontroler.Pretrazi(this); DeferClearSelection_SS(); };

            btnDodaj.Click += (_, __) => { kontroler.Dodaj(this); AfterCrud_SS(); };
            btnIzmeni.Click += (_, __) => { kontroler.Izmeni(this); AfterCrud_SS(); };
            btnObrisi.Click += (_, __) => { kontroler.Obrisi(this); AfterCrud_SS(); };

            dgvStrucneSpreme.CellDoubleClick += (_, __) => OnSelectionChanged_SS();
        }

        private void OnSelectionChanged_SS()
        {
            bool has = dgvStrucneSpreme.CurrentRow != null && dgvStrucneSpreme.SelectedRows.Count > 0;
            btnIzmeni.Enabled = has;
            btnObrisi.Enabled = has;

            if (has) kontroler.PopuniDetaljeIzSelektovanog(this);
            else ClearInputs(this);
        }

        private void DeferClearSelection_SS()
        {
            BeginInvoke(new Action(() =>
            {
                dgvStrucneSpreme.ClearSelection();
                dgvStrucneSpreme.CurrentCell = null;
                btnIzmeni.Enabled = btnObrisi.Enabled = false;
                ClearInputs(this);
            }));
        }

        private void AfterCrud_SS()
        {
            kontroler.Osvezi(this);
            DeferClearSelection_SS();
        }

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
