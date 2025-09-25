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
    public class StrucnaSpremaKontroler
    {
        public void Osvezi(FrmStrucneSpreme f)
        {
            try
            {
                var lista = Komunikacija.Instance
                    .PosaljiZahtev<List<Domen.StrucnaSprema>>(Operacija.VratiSveStrucneSpreme)
                    ?? new List<Domen.StrucnaSprema>();

                f.DgvStrucneSpreme.AutoGenerateColumns = true;
                f.DgvStrucneSpreme.ReadOnly = true;
                f.DgvStrucneSpreme.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                f.DgvStrucneSpreme.DataSource = new BindingList<Domen.StrucnaSprema>(lista);

                SakrijMetaKolone(f.DgvStrucneSpreme);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju stručnih sprema: " + ex.Message);
            }
        }

        private void SakrijMetaKolone(DataGridView dgv)
        {
            foreach (var c in new[] { "UbaciVrednosti", "KoloneZaInsert", "NazivTabele" })
                if (dgv.Columns.Contains(c)) dgv.Columns[c].Visible = false;
        }

        public void Dodaj(FrmStrucneSpreme f)
        {
            if (!int.TryParse(f.TxtStepenObr.Text?.Trim(), out var stepen) || stepen < 0)
            { MessageBox.Show("Stepen obrazovanja mora biti ceo broj ≥ 0."); return; }

            var s = new StrucnaSprema
            {
                Naziv = f.TxtNaziv.Text?.Trim() ?? "",
                StepenObrazovanja = stepen,
                Ustanova = f.TxtUstanova.Text?.Trim() ?? ""
            };

            if (string.IsNullOrWhiteSpace(s.Naziv) || string.IsNullOrWhiteSpace(s.Ustanova))
            { MessageBox.Show("Naziv i Ustanova su obavezni."); return; }

            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.DodajStrucnuSpremu, s);

            OcistiPolja(f);
            Osvezi(f);
        }

        public void Izmeni(FrmStrucneSpreme f)
        {
            if (f.DgvStrucneSpreme.CurrentRow?.DataBoundItem is not StrucnaSprema sel)
            { MessageBox.Show("Izaberi stavku u tabeli."); return; }

            if (!int.TryParse(f.TxtStepenObr.Text?.Trim(), out var stepen) || stepen < 0)
            { MessageBox.Show("Stepen obrazovanja mora biti ceo broj ≥ 0."); return; }

            var s = new StrucnaSprema
            {
                IdStrucnaSprema = sel.IdStrucnaSprema, // bitno!
                Naziv = f.TxtNaziv.Text?.Trim() ?? "",
                StepenObrazovanja = stepen,
                Ustanova = f.TxtUstanova.Text?.Trim() ?? ""
            };

            if (string.IsNullOrWhiteSpace(s.Naziv) || string.IsNullOrWhiteSpace(s.Ustanova))
            { MessageBox.Show("Naziv i Ustanova su obavezni."); return; }

            try
            {
                Komunikacija.Instance.PosaljiZahtev<object>(Operacija.IzmeniStrucnuSpremu, s);
                MessageBox.Show("Sačuvano.");
                OcistiPolja(f);
                Osvezi(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Izmena nije uspela: " + ex.Message);
            }
        }

        public void Obrisi(FrmStrucneSpreme f)
        {
            if (f.DgvStrucneSpreme.CurrentRow?.DataBoundItem is not StrucnaSprema sel)
            { MessageBox.Show("Izaberi stavku u tabeli."); return; }

            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.ObrisiStrucnuSpremu, sel.IdStrucnaSprema);

            OcistiPolja(f);
            Osvezi(f);
        }

        public void Pretrazi(FrmStrucneSpreme f)
        {
            var kljuc = f.TxtPretraga.Text?.Trim() ?? "";

            var lista = Komunikacija.Instance
                .PosaljiZahtev<List<Domen.StrucnaSprema>>(Operacija.PretraziStrucneSpreme, kljuc)
                ?? new List<Domen.StrucnaSprema>();

            f.DgvStrucneSpreme.DataSource = new BindingList<Domen.StrucnaSprema>(lista);
            SakrijMetaKolone(f.DgvStrucneSpreme);
        }

        public void PopuniDetaljeIzSelektovanog(FrmStrucneSpreme f)
        {
            if (f.DgvStrucneSpreme.CurrentRow?.DataBoundItem is StrucnaSprema sel)
            {
                f.TxtNaziv.Text = sel.Naziv;
                f.TxtStepenObr.Text = sel.StepenObrazovanja.ToString();
                f.TxtUstanova.Text = sel.Ustanova;
            }
        }

        private void OcistiPolja(FrmStrucneSpreme f)
        {
            f.TxtNaziv.Clear();
            f.TxtStepenObr.Clear();
            f.TxtUstanova.Clear();
            // f.TxtPretraga?.Clear();
        }

        private void Sakrij(DataGridView dgv, params string[] names)
        {
            foreach (var n in names)
                if (dgv.Columns.Contains(n))
                    dgv.Columns[n].Visible = false;
        }
    }
}
