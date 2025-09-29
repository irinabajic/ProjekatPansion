using Domen.Dodatno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicki;

namespace KorisnickiInterfejs.GUIKontroler
{
    public partial class FrmPrijemniAzuriraj : Form
    {
        private readonly GUIKontroler.PrijemniAzurirajKontroler _ki = new();
        private readonly int _idPO;

        public FrmPrijemniAzuriraj(int idPrijemni)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            _idPO = idPrijemni;

            Load += (_, __) => _ki.Init(this, _idPO);
            btnDodaj.Click += (_, __) => _ki.DodajStavku(this);
            btnObrisi.Click += (_, __) => _ki.ObrisiStavku(this);

            dgvStavke.ReadOnly = true;
            dgvStavke.MultiSelect = false;
            dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStavke.AutoGenerateColumns = true;   // ali DataSource postavlja KI u Init/Refresh
        }
    }
}
