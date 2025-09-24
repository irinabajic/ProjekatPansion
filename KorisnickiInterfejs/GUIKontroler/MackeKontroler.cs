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
    public class MackeKontroler
    {
        public void Osvezi(FrmMacke f)
        {
            try
            {
                var lista = Komunikacija.Instance
                    .PosaljiZahtev<List<Domen.Macka>>(Operacija.VratiSveMacke) ?? new List<Domen.Macka>();

                f.DgvMacke.AutoGenerateColumns = true;               // obavezno
                f.DgvMacke.ReadOnly = true;
                f.DgvMacke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // BindingList forsira generisanje kolona i kada je lista prazna
                f.DgvMacke.DataSource = new BindingList<Domen.Macka>(lista);

                SakrijMetaKolone(f.DgvMacke);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju mačaka: " + ex.Message);
            }
        }

        private void SakrijMetaKolone(DataGridView dgv)
        {
            foreach (var c in new[] { "UbaciVrednosti", "KoloneZaInsert", "NazivTabele" })
                if (dgv.Columns.Contains(c)) dgv.Columns[c].Visible = false;
        }

        public void Dodaj(FrmMacke f)
        {
            var m = new Macka
            {
                Naziv = f.TxtNaziv.Text?.Trim(),
                Rasa = f.TxtRasa.Text?.Trim(),
                Napomene = f.TxtNapomene.Text?.Trim()
            };
            if (string.IsNullOrWhiteSpace(m.Naziv))
            {
                MessageBox.Show("Naziv je obavezan.");
                return;
            }

            // repo.Dodaj je void => ne očekujemo povratnu vrednost
            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.DodajMacku, m);

            OcistiPolja(f);
            Osvezi(f);
        }

        public void Izmeni(FrmMacke f)
        {
            if (f.DgvMacke.CurrentRow?.DataBoundItem is not Macka sel)
            { MessageBox.Show("Izaberi mačku u tabeli."); return; }

            var m = new Macka
            {
                IdMacka = sel.IdMacka,                // bitno!
                Naziv = f.TxtNaziv.Text?.Trim(),
                Rasa = f.TxtRasa.Text?.Trim(),
                Napomene = f.TxtNapomene.Text?.Trim()
            };
            if (string.IsNullOrWhiteSpace(m.Naziv) ||
                string.IsNullOrWhiteSpace(m.Rasa) ||
                string.IsNullOrWhiteSpace(m.Napomene))
            { MessageBox.Show("Sva polja su obavezna."); return; }

            try
            {
                Komunikacija.Instance.PosaljiZahtev<object>(Operacija.IzmeniMacku, m);
                MessageBox.Show("Sačuvano.");
                OcistiPolja(f);
                Osvezi(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Izmena nije uspela: " + ex.Message);
            }
        }

        public void Obrisi(FrmMacke f)
        {
            if (f.DgvMacke.CurrentRow?.DataBoundItem is not Macka sel)
            {
                MessageBox.Show("Izaberi mačku u tabeli.");
                return;
            }

            // ako je u FK (StavkaObrasca) DB će odbiti — uhvati poruku iz servera
            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.ObrisiMacku, sel.IdMacka);

            OcistiPolja(f);
            Osvezi(f);
        }

        public void PopuniDetaljeIzSelektovanog(FrmMacke f)
        {
            if (f.DgvMacke.CurrentRow?.DataBoundItem is Macka sel)
            {
                f.TxtNaziv.Text = sel.Naziv;
                f.TxtRasa.Text = sel.Rasa;
                f.TxtNapomene.Text = sel.Napomene;
            }
        }

        private void OcistiPolja(FrmMacke f)
        {
            f.TxtNaziv.Clear();
            f.TxtRasa.Clear();
            f.TxtNapomene.Clear();
        }

        private void Sakrij(DataGridView dgv, params string[] names)
        {
            foreach (var n in names)
                if (dgv.Columns.Contains(n))
                    dgv.Columns[n].Visible = false;
        }
    }
}
