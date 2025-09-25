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
    public class PrijemniObrasciKontroler
    {
        public void Osvezi(FrmPrijemniObrasci f)
        {
            try
            {
                var lista = Komunikacija.Instance
                    .PosaljiZahtev<List<Domen.PrijemniObrazac>>(Operacija.VratiSvePrijemneObrasce)
                    ?? new List<Domen.PrijemniObrazac>();

                f.DgvPrijemniObrasci.AutoGenerateColumns = true;
                f.DgvPrijemniObrasci.ReadOnly = true;
                f.DgvPrijemniObrasci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                f.DgvPrijemniObrasci.DataSource = new BindingList<Domen.PrijemniObrazac>(lista);
                SakrijMetaKolone(f.DgvPrijemniObrasci);
            }
            catch (Exception ex) { MessageBox.Show("Greška pri učitavanju: " + ex.Message); }
        }

        private void SakrijMetaKolone(DataGridView dgv)
        {
            foreach (var c in new[] { "UbaciVrednosti", "KoloneZaInsert", "NazivTabele" })
                if (dgv.Columns.Contains(c)) dgv.Columns[c].Visible = false;
        }

        public void Dodaj(FrmPrijemniObrasci f)
        {
            if (!DateTime.TryParse(f.TxtDatum.Text?.Trim(), out var datum))
            { MessageBox.Show("Datum nije validan."); return; }
            if (!int.TryParse(f.TxtIdRadnik.Text?.Trim(), out var idR) || idR <= 0)
            { MessageBox.Show("IdRadnik mora biti broj > 0."); return; }
            if (!int.TryParse(f.TxtIdVlasnik.Text?.Trim(), out var idV) || idV <= 0)
            { MessageBox.Show("IdVlasnik mora biti broj > 0."); return; }

            var p = new PrijemniObrazac { Datum = datum, IdRadnik = idR, IdVlasnik = idV };

            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.DodajPrijemniObrazac, p);
            OcistiPolja(f); Osvezi(f);
        }

        public void Izmeni(FrmPrijemniObrasci f)
        {
            if (f.DgvPrijemniObrasci.CurrentRow?.DataBoundItem is not PrijemniObrazac sel)
            { MessageBox.Show("Izaberi prijemni obrazac."); return; }

            if (!DateTime.TryParse(f.TxtDatum.Text?.Trim(), out var datum))
            { MessageBox.Show("Datum nije validan."); return; }
            if (!int.TryParse(f.TxtIdRadnik.Text?.Trim(), out var idR) || idR <= 0)
            { MessageBox.Show("IdRadnik mora biti broj > 0."); return; }
            if (!int.TryParse(f.TxtIdVlasnik.Text?.Trim(), out var idV) || idV <= 0)
            { MessageBox.Show("IdVlasnik mora biti broj > 0."); return; }

            var p = new PrijemniObrazac
            {
                IdPrijemniObrazac = sel.IdPrijemniObrazac,
                Datum = datum,
                IdRadnik = idR,
                IdVlasnik = idV
            };

            try
            {
                Komunikacija.Instance.PosaljiZahtev<object>(Operacija.IzmeniPrijemniObrazac, p);
                MessageBox.Show("Sačuvano.");
                OcistiPolja(f); Osvezi(f);
            }
            catch (Exception ex) { MessageBox.Show("Izmena nije uspela: " + ex.Message); }
        }

        public void Obrisi(FrmPrijemniObrasci f)
        {
            if (f.DgvPrijemniObrasci.CurrentRow?.DataBoundItem is not PrijemniObrazac sel)
            { MessageBox.Show("Izaberi prijemni obrazac."); return; }

            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.ObrisiPrijemniObrazac, sel.IdPrijemniObrazac);
            OcistiPolja(f); Osvezi(f);
        }

        public void Pretrazi(FrmPrijemniObrasci f)
        {
            var kljuc = f.TxtPretraga.Text?.Trim() ?? "";
            var lista = Komunikacija.Instance
                .PosaljiZahtev<List<Domen.PrijemniObrazac>>(Operacija.PretraziPrijemneObrasce, kljuc)
                ?? new List<Domen.PrijemniObrazac>();

            f.DgvPrijemniObrasci.DataSource = new BindingList<Domen.PrijemniObrazac>(lista);
            SakrijMetaKolone(f.DgvPrijemniObrasci);
        }

        public void PopuniDetaljeIzSelektovanog(FrmPrijemniObrasci f)
        {
            if (f.DgvPrijemniObrasci.CurrentRow?.DataBoundItem is PrijemniObrazac sel)
            {
                f.TxtDatum.Text = sel.Datum.ToString("yyyy-MM-dd");
                f.TxtIdRadnik.Text = sel.IdRadnik.ToString();
                f.TxtIdVlasnik.Text = sel.IdVlasnik.ToString();
            }
        }

        private void OcistiPolja(FrmPrijemniObrasci f)
        {
            f.TxtDatum.Clear();
            f.TxtIdRadnik.Clear();
            f.TxtIdVlasnik.Clear();
            f.TxtPretraga?.Clear();
        }
    }
}
