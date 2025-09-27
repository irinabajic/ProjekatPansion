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
    public class MojeRSSKontroler
    {
        public void Inicijalizuj(FrmMojaStrucnaSprema f)
        {
            f.DgvRSS.AutoGenerateColumns = true;
            f.DgvRSS.ReadOnly = true;
            f.DgvRSS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            UcitajSveStrucneSpreme(f);
            Osvezi(f);

            f.DgvRSS.SelectionChanged += (s, e) =>
            {
                if (f.DgvRSS.CurrentRow?.DataBoundItem is RSSView sel)
                    f.TxtBrojSertifikata.Text = sel.BrojSertifikata ?? "";
            };
            Sakrij(f.DgvRSS, "IdRadnik", "IdStrucnaSprema");
        }

        public void Osvezi(FrmMojaStrucnaSprema f)
        {
            int id = Session.Session.Instance.PrijavljeniRadnik?.IdRadnik ?? 0;
            var lista = Komunikacija.Instance
                .PosaljiZahtev<List<RSSView>>(Operacija.VratiMojeRSS, id)
                ?? new List<RSSView>();
            f.DgvRSS.DataSource = new BindingList<RSSView>(lista);
            SakrijMetaKolone(f.DgvRSS);
        }

        public void Dodaj(FrmMojaStrucnaSprema f)
        {
            if (f.CboStrucnaSprema.SelectedValue == null) { MessageBox.Show("Izaberi stručnu spremu."); return; }
            var broj = (f.TxtBrojSertifikataNovo.Text ?? "").Trim();
            if (string.IsNullOrEmpty(broj)) { MessageBox.Show("Unesi broj sertifikata."); return; }

            var rss = new RSS
            {
                IdRadnik = Session.Session.Instance.PrijavljeniRadnik.IdRadnik,
                IdStrucnaSprema = (int)f.CboStrucnaSprema.SelectedValue,
                BrojSertifikata = broj
            };

            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.DodajRSS, rss);
            f.TxtBrojSertifikataNovo.Clear();
            f.CboStrucnaSprema.SelectedIndex = -1;
            Osvezi(f);
        }

        public void Izmeni(FrmMojaStrucnaSprema f)
        {
            if (f.DgvRSS.CurrentRow?.DataBoundItem is not RSSView sel)
            { MessageBox.Show("Izaberi stavku."); return; }

            var broj = (f.TxtBrojSertifikata.Text ?? "").Trim();
            if (string.IsNullOrEmpty(broj)) { MessageBox.Show("Unesi broj sertifikata."); return; }

            var rss = new RSS
            {
                IdRadnik = Session.Session.Instance.PrijavljeniRadnik.IdRadnik,
                IdStrucnaSprema = sel.IdStrucnaSprema,
                BrojSertifikata = broj
            };

            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.IzmeniRSS, rss);
            Osvezi(f);
            MessageBox.Show("Sačuvano.");
        }

        public void Obrisi(FrmMojaStrucnaSprema f)
        {
            if (f.DgvRSS.CurrentRow?.DataBoundItem is not RSSView sel)
            { MessageBox.Show("Izaberi stavku."); return; }

            if (MessageBox.Show($"Obrisati vezu za \"{sel.Naziv}\"?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            var rss = new RSS
            {
                IdRadnik = Session.Session.Instance.PrijavljeniRadnik.IdRadnik,
                IdStrucnaSprema = sel.IdStrucnaSprema
            };

            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.ObrisiRSS, rss);
            Osvezi(f);
            f.TxtBrojSertifikata.Clear();
        }

        private void UcitajSveStrucneSpreme(FrmMojaStrucnaSprema f)
        {
            var ss = Komunikacija.Instance
                .PosaljiZahtev<List<StrucnaSprema>>(Operacija.VratiSveStrucneSpreme)
                ?? new List<StrucnaSprema>();

            f.CboStrucnaSprema.DisplayMember = nameof(StrucnaSprema.Naziv);
            f.CboStrucnaSprema.ValueMember = nameof(StrucnaSprema.IdStrucnaSprema);
            f.CboStrucnaSprema.DataSource = ss;
            f.CboStrucnaSprema.SelectedIndex = -1;
        }

        private void SakrijMetaKolone(DataGridView dgv)
        {
            foreach (var c in new[] { "UbaciVrednosti", "KoloneZaInsert", "NazivTabele" })
                if (dgv.Columns.Contains(c)) dgv.Columns[c].Visible = false;
        }

        private void Sakrij(DataGridView dgv, params string[] names)
        {
            foreach (var n in names)
                if (dgv.Columns.Contains(n))
                    dgv.Columns[n].Visible = false;
        }

    }
}
