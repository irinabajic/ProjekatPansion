using Domen;
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

    public partial class FrmPrijemniDetalji : Form
    {
        private readonly int _id;
        public FrmPrijemniDetalji(int id)
        {
            InitializeComponent();
            _id = id;

            this.Load += FrmPrijemniDetalji_Load;

            dgvStavke.AutoGenerateColumns = true;
            dgvStavke.ReadOnly = true;
            dgvStavke.AllowUserToAddRows = false;
            dgvStavke.AllowUserToDeleteRows = false;
            dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FrmPrijemniDetalji_Load(object? sender, EventArgs e)
        {
            var dto = Komunikacija.Instance
                .PosaljiZahtev<PrijemniDetaljiDTO>(Operacija.VratiDetaljePrijemnogObrasca, _id);

            if (dto == null) { MessageBox.Show("Nije moguće učitati detalje."); Close(); return; }

            // Naslov
            lblBroj.Text = dto.Header.IdPrijemniObrazac.ToString();
            lblDatum.Text = dto.Header.Datum.ToString("dd.MM.yyyy");

            // Vlasnik
            lblVlasnikIme.Text = dto.Header.VlasnikIme;
            lblVlasnikAdresa.Text = dto.Header.VlasnikAdresa;
            lblVlasnikTelefon.Text = dto.Header.VlasnikTelefon;
            lblVlasnikEmail.Text = dto.Header.VlasnikEmail;
            lblVlasnikMesto.Text = dto.Header.VlasnikMesto;

            // Radnik
            lblRadnikIme.Text = dto.Header.RadnikIme;
            lblRadnikUsername.Text = dto.Header.RadnikUsername;
            lblRadnikTelefon.Text = dto.Header.RadnikTelefon;

            // Stavke
            dgvStavke.DataSource = new BindingList<StavkaPrijemnogView>(dto.Stavke);
            SakrijKoloneStavke(DgvStavke);

            // (opciono) lepši nazivi kolona
            void SetHeader(string name, string header)
            {
                if (dgvStavke.Columns.Contains(name)) dgvStavke.Columns[name].HeaderText = header;
            }
            SetHeader(nameof(StavkaPrijemnogView.Rb), "Redni broj");
            SetHeader(nameof(StavkaPrijemnogView.StavkaNaziv), "Naziv stavke");
            SetHeader(nameof(StavkaPrijemnogView.StavkaOpis), "Opis");
            SetHeader(nameof(StavkaPrijemnogView.MackaNaziv), "Mačka");
            SetHeader(nameof(StavkaPrijemnogView.MackaRasa), "Rasa");
            SetHeader(nameof(StavkaPrijemnogView.MackaNapomene), "Napomene");
        }

        private static void SakrijKoloneStavke(DataGridView dgv)
        {
            foreach (var c in new[] { "NazivTabele", "KoloneZaInsert", "UbaciVrednosti", "IdPrijemniObrazac", "IdMacka" })
                if (dgv.Columns.Contains(c)) dgv.Columns[c].Visible = false;
        }
    }
}
