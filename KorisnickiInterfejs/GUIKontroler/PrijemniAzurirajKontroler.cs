using Domen;
using Domen.Dodatno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace KorisnickiInterfejs.GUIKontroler
{
    public class PrijemniAzurirajKontroler
    {
        private int _idPO;
        private PrijemniDetaljiDTO _dto = new();

        public void Init(FrmPrijemniAzuriraj f, int idPO)
        {
            _idPO = idPO;

            _dto = Komunikacija.Instance
                   .PosaljiZahtev<PrijemniDetaljiDTO>(Operacija.VratiDetaljePrijemnogObrasca, _idPO)
                   ?? new PrijemniDetaljiDTO(); //vraca

            var h = _dto.Header;
            f.LblBroj.Text = h.IdPrijemniObrazac.ToString();
            f.LblDatum.Text = h.Datum.ToString("dd.MM.yyyy.");
            f.LblRadnikIme.Text = h.RadnikIme;
            f.LblRadnikUsername.Text = h.RadnikUsername;
            f.LblRadnikTelefon.Text = h.RadnikTelefon;
            f.LblVlasnikIme.Text = h.VlasnikIme;
            f.LblVlasnikAdresa.Text = h.VlasnikAdresa;
            f.LblVlasnikEmail.Text = h.VlasnikEmail;
            f.LblVlasnikTelefon.Text = h.VlasnikTelefon;
            f.LblVlasnikMesto.Text = h.VlasnikMesto;

            var macke = Komunikacija.Instance
                        .PosaljiZahtev<List<Macka>>(Operacija.VratiSveMacke) ?? new List<Macka>();
            f.CmbMacka.DropDownStyle = ComboBoxStyle.DropDownList;
            f.CmbMacka.DisplayMember = "Naziv";
            f.CmbMacka.ValueMember = "IdMacka";
            f.CmbMacka.DataSource = macke;

            // GRID tek sada:
            f.DgvStavke.Columns.Clear();
            f.DgvStavke.AutoGenerateColumns = true;
            f.DgvStavke.DataSource = new BindingList<StavkaPrijemnogView>(_dto.Stavke ?? new List<StavkaPrijemnogView>());
            PodesiGrid(f);
        }

        private void RefreshGrid(FrmPrijemniAzuriraj f)
        {
            _dto = Komunikacija.Instance
                   .PosaljiZahtev<PrijemniDetaljiDTO>(Operacija.VratiDetaljePrijemnogObrasca, _idPO)
                   ?? new PrijemniDetaljiDTO();

            f.DgvStavke.AutoGenerateColumns = true;
            f.DgvStavke.Columns.Clear();
            f.DgvStavke.DataSource = new BindingList<StavkaPrijemnogView>(_dto.Stavke ?? new List<StavkaPrijemnogView>());
            PodesiGrid(f);
        }

        public void DodajStavku(FrmPrijemniAzuriraj f)
        {
            if (f.CmbMacka.SelectedValue == null ||
        !int.TryParse(f.CmbMacka.SelectedValue.ToString(), out var idMacka))
            { MessageBox.Show("Izaberi mačku."); return; }

            var nova = new StavkaObrasca
            {
                // IdPrijemniObrazac i Rb popunjava server
                Naziv = "Stavka",
                Opis = f.TxtNapomena.Text?.Trim() ?? "",
                IdMacka = idMacka
            };

            var cmd = new Domen.Dodatno.PrijemniUpdateDTO
            {
                IdPrijemniObrazac = _idPO,
                StavkeZaDodavanje = new List<StavkaObrasca> { nova }
            };

            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.IzmeniPrijemniObrazac, cmd);
            RefreshGrid(f);
            f.TxtNapomena.Clear();
        }

        public void ObrisiStavku(FrmPrijemniAzuriraj f)
        {
            if (f.DgvStavke.CurrentRow?.DataBoundItem is not StavkaPrijemnogView sel)
            { MessageBox.Show("Izaberi stavku."); return; }

            var cmd = new Domen.Dodatno.PrijemniUpdateDTO
            {
                IdPrijemniObrazac = _idPO,
                RedniBrojeviZaBrisanje = new List<int> { sel.Rb }
            };

            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.IzmeniPrijemniObrazac, cmd);
            RefreshGrid(f);
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

        private void PodesiGrid(FrmPrijemniAzuriraj f)
        {
            var dgv = f.DgvStavke;

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            void Hide(string name)
            {
                if (dgv.Columns.Contains(name)) dgv.Columns[name].Visible = false;
            }
            void Header(string name, string text)
            {
                if (dgv.Columns.Contains(name)) dgv.Columns[name].HeaderText = text;
            }

            // sakrij tražene kolone
            Hide(nameof(StavkaPrijemnogView.IdPrijemniObrazac));
            Hide(nameof(StavkaPrijemnogView.IdMacka));
            // sakrij meta kolone
            SakrijMetaKolone(dgv);

            // naslovi kolona (isti kao u Detalji)
            SetHeader(dgv, nameof(StavkaPrijemnogView.Rb), "Redni broj");

            SetHeader(dgv, nameof(StavkaPrijemnogView.StavkaOpis), "Opis");
            SetHeader(dgv, nameof(StavkaPrijemnogView.MackaNaziv), "Mačka");
            SetHeader(dgv, nameof(StavkaPrijemnogView.MackaRasa), "Rasa");
            SetHeader(dgv, nameof(StavkaPrijemnogView.MackaNapomene), "Napomene");
        }
    }
}

