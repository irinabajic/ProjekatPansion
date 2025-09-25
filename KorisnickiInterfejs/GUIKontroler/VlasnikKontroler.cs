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
    public class VlasnikKontroler
    {
        public void Osvezi(FrmVlasnik f)
        {
            try
            {
                var lista = Komunikacija.Instance
                    .PosaljiZahtev<List<Domen.Vlasnik>>(Operacija.VratiSveVlasnike)
                    ?? new List<Domen.Vlasnik>();

                f.DgvVlasnici.AutoGenerateColumns = true;
                f.DgvVlasnici.ReadOnly = true;
                f.DgvVlasnici.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // BindingList forsira kolone i kada je lista prazna
                f.DgvVlasnici.DataSource = new BindingList<Domen.Vlasnik>(lista);

                SakrijMetaKolone(f.DgvVlasnici);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju vlasnika: " + ex.Message);
            }
        }

        private void SakrijMetaKolone(DataGridView dgv)
        {
            foreach (var c in new[] { "UbaciVrednosti", "KoloneZaInsert", "NazivTabele" })
                if (dgv.Columns.Contains(c)) dgv.Columns[c].Visible = false;
        }

        public void Dodaj(FrmVlasnik f)
        {
            if (!int.TryParse(f.TxtIdMesto.Text?.Trim(), out var idMesto) || idMesto <= 0)
            { MessageBox.Show("IdMesto mora biti ceo broj > 0."); return; }

            var v = new Vlasnik
            {
                Ime = f.TxtIme.Text?.Trim() ?? "",
                BrojTelefona = f.TxtTelefon.Text?.Trim() ?? "",
                Adresa = f.TxtAdresa.Text?.Trim() ?? "",
                Email = f.TxtEmail.Text?.Trim() ?? "",
                IdMesto = idMesto
            };

            if (string.IsNullOrWhiteSpace(v.Ime) ||
                string.IsNullOrWhiteSpace(v.BrojTelefona) ||
                string.IsNullOrWhiteSpace(v.Adresa) ||
                string.IsNullOrWhiteSpace(v.Email))
            { MessageBox.Show("Sva polja osim IdMesto već su popunjena? Proveri unos."); return; }

            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.DodajVlasnika, v);

            OcistiPolja(f);
            Osvezi(f);
        }

        public void Izmeni(FrmVlasnik f)
        {
            if (f.DgvVlasnici.CurrentRow?.DataBoundItem is not Vlasnik sel)
            { MessageBox.Show("Izaberi vlasnika u tabeli."); return; }

            if (!int.TryParse(f.TxtIdMesto.Text?.Trim(), out var idMesto) || idMesto <= 0)
            { MessageBox.Show("IdMesto mora biti ceo broj > 0."); return; }

            var v = new Vlasnik
            {
                IdVlasnik = sel.IdVlasnik,            // bitno!
                Ime = f.TxtIme.Text?.Trim() ?? "",
                BrojTelefona = f.TxtTelefon.Text?.Trim() ?? "",
                Adresa = f.TxtAdresa.Text?.Trim() ?? "",
                Email = f.TxtEmail.Text?.Trim() ?? "",
                IdMesto = idMesto
            };

            if (string.IsNullOrWhiteSpace(v.Ime) ||
                string.IsNullOrWhiteSpace(v.BrojTelefona) ||
                string.IsNullOrWhiteSpace(v.Adresa) ||
                string.IsNullOrWhiteSpace(v.Email))
            { MessageBox.Show("Sva polja su obavezna."); return; }

            try
            {
                Komunikacija.Instance.PosaljiZahtev<object>(Operacija.IzmeniVlasnika, v);
                MessageBox.Show("Sačuvano.");
                OcistiPolja(f);
                Osvezi(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Izmena nije uspela: " + ex.Message);
            }
        }

        public void Obrisi(FrmVlasnik f)
        {
            if (f.DgvVlasnici.CurrentRow?.DataBoundItem is not Vlasnik sel)
            { MessageBox.Show("Izaberi vlasnika u tabeli."); return; }

            // ako postoje FK (npr. Macka.IdVlasnik), DB može odbiti — poruka dolazi sa servera
            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.ObrisiVlasnika, sel.IdVlasnik);

            OcistiPolja(f);
            Osvezi(f);
        }

        //public void Pretrazi(FrmVlasnik f)
        //{
        //    //var kljuc = f.TxtPretraga.Text?.Trim() ?? "";
        //    var lista = Komunikacija.Instance
        //        .PosaljiZahtev<List<Domen.Vlasnik>>(Operacija.PretraziVlasnike, kljuc)
        //        ?? new List<Domen.Vlasnik>();

        //    f.DgvVlasnici.DataSource = new BindingList<Domen.Vlasnik>(lista);
        //    SakrijMetaKolone(f.DgvVlasnici);
        //}

        public void PopuniDetaljeIzSelektovanog(FrmVlasnik f)
        {
            if (f.DgvVlasnici.CurrentRow?.DataBoundItem is Vlasnik sel)
            {
                f.TxtIme.Text = sel.Ime;
                f.TxtTelefon.Text = sel.BrojTelefona;           // string
                f.TxtAdresa.Text = sel.Adresa;
                f.TxtEmail.Text = sel.Email;
                f.TxtIdMesto.Text = sel.IdMesto.ToString();
            }
        }

        private void OcistiPolja(FrmVlasnik f)
        {
            f.TxtIme.Clear();
            f.TxtTelefon.Clear();
            f.TxtAdresa.Clear();
            f.TxtEmail.Clear();
            f.TxtIdMesto.Clear();
            //f.TxtPretraga?.Clear();
        }

        private void Sakrij(DataGridView dgv, params string[] names)
        {
            foreach (var n in names)
                if (dgv.Columns.Contains(n))
                    dgv.Columns[n].Visible = false;
        }
    }
}

