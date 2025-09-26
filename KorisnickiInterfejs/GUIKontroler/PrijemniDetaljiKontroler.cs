using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace KorisnickiInterfejs.GUIKontroler
{
    public class PrijemniDetaljiKontroler
    {
        public void Ucitaj(FrmPrijemniDetalji f, int idPrijemni)
        {
            var dto = Komunikacija.Instance
                .PosaljiZahtev<PrijemniDetaljiDTO>(Operacija.VratiDetaljePrijemnogObrasca, idPrijemni);

            if (dto == null)
            {
                MessageBox.Show("Nije moguće učitati detalje prijemnog obrasca.");
                f.Close();
                return;
            }

            // naslov / datum
            f.LblBroj.Text = dto.Header.IdPrijemniObrazac.ToString();
            f.LblDatum.Text = dto.Header.Datum.ToString("dd.MM.yyyy");

            // vlasnik
            f.LblVlasnikIme.Text = dto.Header.VlasnikIme;
            f.LblVlasnikAdresa.Text = dto.Header.VlasnikAdresa;
            f.LblVlasnikTelefon.Text = dto.Header.VlasnikTelefon;
            f.LblVlasnikEmail.Text = dto.Header.VlasnikEmail;
            f.LblVlasnikMesto.Text = dto.Header.VlasnikMesto;

            // radnik
            f.LblRadnikIme.Text = dto.Header.RadnikIme;
            f.LblRadnikUsername.Text = dto.Header.RadnikUsername;
            f.LblRadnikTelefon.Text = dto.Header.RadnikTelefon;

            // stavke
            f.DgvStavke.AutoGenerateColumns = true;
            f.DgvStavke.ReadOnly = true;
            f.DgvStavke.AllowUserToAddRows = false;
            f.DgvStavke.AllowUserToDeleteRows = false;
            f.DgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            f.DgvStavke.DataSource = new BindingList<StavkaPrijemnogView>(dto.Stavke);
            SakrijMetaKolone(f.DgvStavke);

            // lepši naslovi kolona
            SetHeader(f.DgvStavke, nameof(StavkaPrijemnogView.Rb), "Redni broj");
            SetHeader(f.DgvStavke, nameof(StavkaPrijemnogView.StavkaNaziv), "Naziv stavke");
            SetHeader(f.DgvStavke, nameof(StavkaPrijemnogView.StavkaOpis), "Opis");
            SetHeader(f.DgvStavke, nameof(StavkaPrijemnogView.MackaNaziv), "Mačka");
            SetHeader(f.DgvStavke, nameof(StavkaPrijemnogView.MackaRasa), "Rasa");
            SetHeader(f.DgvStavke, nameof(StavkaPrijemnogView.MackaNapomene), "Napomene");
        }

        private static void SetHeader(DataGridView dgv, string name, string header)
        {
            if (dgv.Columns.Contains(name)) dgv.Columns[name].HeaderText = header;
        }

        private static void SakrijMetaKolone(DataGridView dgv)
        {
            foreach (var c in new[] { "NazivTabele", "KoloneZaInsert", "UbaciVrednosti" })
                if (dgv.Columns.Contains(c)) dgv.Columns[c].Visible = false;
        }
    }
}
