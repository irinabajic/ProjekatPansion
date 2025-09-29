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
using Zajednicki;

namespace KorisnickiInterfejs
{
    public partial class FrmPrijemniKreiraj : Form
    {
        private readonly PrijemniKreirajKontroler _ki = new();
        public int NoviIdPrijemnog { get; private set; }

        public FrmPrijemniKreiraj()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            Load += (_, __) => _ki.Init(this);
            cmbVlasnik.SelectedIndexChanged += (_, __) => _ki.OsveziVlasnikInfo(this);

            btnSacuvaj.Click += (_, __) =>
            {
                int id = _ki.Sacuvaj(this);
                if (id <= 0) return;
                NoviIdPrijemnog = id;
                DialogResult = DialogResult.OK;
                Close();
            };
        }
    }
}
