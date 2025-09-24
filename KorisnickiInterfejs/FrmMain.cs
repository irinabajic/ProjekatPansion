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
    public partial class FrmMain : Form
    {
        private GUIKontroler.MainKontroler kontroler = new GUIKontroler.MainKontroler();

        public FrmMain()
        {
            InitializeComponent();
            dgvKolege.ReadOnly = true;
            dgvKolege.AutoGenerateColumns = true;
            dgvKolege.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            kontroler.Init(this);         // popuni levo
            kontroler.UcitajKolege(this); // napuni grid desno
        }
    }
}
