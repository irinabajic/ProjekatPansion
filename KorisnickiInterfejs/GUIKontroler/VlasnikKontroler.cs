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
        private List<Mesto> _mesta;
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
                Sakrij(f.DgvVlasnici, "IdMesto","IdVlasnik");
                SakrijMetaKolone(f.DgvVlasnici);
                EnsureMestaLoaded();
                ApplyMestoColumn(f);
                BindMestoCombo(f);
                RasporediKolone(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju vlasnika: " + ex.Message);
            }
        }

        private DataGridViewColumn FindCol(DataGridView dgv, string propOrName)
        {
            // prvo po Name, pa po DataPropertyName (case-insensitive)
            if (dgv.Columns.Contains(propOrName)) return dgv.Columns[propOrName];
            return dgv.Columns
                      .Cast<DataGridViewColumn>()
                      .FirstOrDefault(c => string.Equals(c.DataPropertyName,
                                                         propOrName,
                                                         StringComparison.OrdinalIgnoreCase));
        }

        private void RasporediKolone(FrmVlasnik f)
        {
            var dgv = f.DgvVlasnici;

            // željeni redosled:
            var order = new[] { "Ime", "BrojTelefona", "Email", "Adresa", "colMesto" };

            int i = 0;
            foreach (var key in order)
            {
                var col = key == "colMesto"
                    ? dgv.Columns["colMesto"]              // naša ComboBox kolona
                    : FindCol(dgv, key);                   // auto-generisana (po propertyju)

                if (col != null) col.DisplayIndex = i++;
            }
        }

        private void SakrijMetaKolone(DataGridView dgv)
        {
            foreach (var c in new[] { "UbaciVrednosti", "KoloneZaInsert", "NazivTabele" })
                if (dgv.Columns.Contains(c)) dgv.Columns[c].Visible = false;
        }

        public void Dodaj(FrmVlasnik f)
        {

            var v = new Vlasnik
            {
                Ime = f.TxtIme.Text?.Trim() ?? "",
                BrojTelefona = f.TxtTelefon.Text?.Trim() ?? "",
                Adresa = f.TxtAdresa.Text?.Trim() ?? "",
                Email = f.TxtEmail.Text?.Trim() ?? "",
                IdMesto = (int)f.CboMesto.SelectedValue
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


            var v = new Vlasnik
            {
                IdVlasnik = sel.IdVlasnik,            // bitno!
                Ime = f.TxtIme.Text?.Trim() ?? "",
                BrojTelefona = f.TxtTelefon.Text?.Trim() ?? "",
                Adresa = f.TxtAdresa.Text?.Trim() ?? "",
                Email = f.TxtEmail.Text?.Trim() ?? "",
                IdMesto = (int)f.CboMesto.SelectedValue
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

            if (MessageBox.Show($"Obrisati vlasnika \"{sel.Ime}\"?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            if (!Komunikacija.Instance.PosaljiZahtevSafe(
                    Operacija.ObrisiVlasnika, sel.IdVlasnik, out var poruka))
            {
                // prijateljska poruka umesto Exception-a
                MessageBox.Show(poruka ?? "Vlasnik ne može da se obriše jer je povezan sa drugim podacima (npr. prijemni obrazac ili mačka).",
                                "Brisanje nije moguće", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Osvezi(f);
            MessageBox.Show("Obrisano.");
        }

        public void Pretrazi(FrmVlasnik f)
        {
            var kljuc = f.TxtPretraga.Text?.Trim() ?? "";
            var lista = Komunikacija.Instance
                .PosaljiZahtev<List<Domen.Vlasnik>>(Operacija.PretraziVlasnike, kljuc)
                ?? new List<Domen.Vlasnik>();

            f.DgvVlasnici.DataSource = new BindingList<Domen.Vlasnik>(lista);
            SakrijMetaKolone(f.DgvVlasnici);
        }

        public void PopuniDetaljeIzSelektovanog(FrmVlasnik f)
        {
            if (f.DgvVlasnici.CurrentRow?.DataBoundItem is Vlasnik sel)
            {
                f.TxtIme.Text = sel.Ime;
                f.TxtTelefon.Text = sel.BrojTelefona;           // string
                f.TxtAdresa.Text = sel.Adresa;
                f.TxtEmail.Text = sel.Email;
                BindMestoCombo(f); // sigurica da je DataSource postavljen
                f.CboMesto.SelectedValue = sel.IdMesto;
            }
        }

        private void OcistiPolja(FrmVlasnik f)
        {
            f.TxtIme.Clear();
            f.TxtTelefon.Clear();
            f.TxtAdresa.Clear();
            f.TxtEmail.Clear();
            //f.TxtPretraga?.Clear();
            if (f.CboMesto.DataSource != null) f.CboMesto.SelectedIndex = -1;
        }

        private void EnsureMestaLoaded()
        {
            if (_mesta == null)
                _mesta = Komunikacija.Instance
                         .PosaljiZahtev<List<Mesto>>(Operacija.VratiSvaMesta)
                         ?? new List<Mesto>();
        }
        private void BindMestoCombo(FrmVlasnik f)
        {
            EnsureMestaLoaded();
            f.CboMesto.DisplayMember = nameof(Mesto.Naziv);
            f.CboMesto.ValueMember = nameof(Mesto.IdMesto);
            f.CboMesto.DataSource = _mesta;
        }

        private void ApplyMestoColumn(FrmVlasnik f)
        {
            EnsureMestaLoaded();

            // ukloni stari "IdMesto" iz prikaza
            if (f.DgvVlasnici.Columns.Contains("IdMesto"))
                f.DgvVlasnici.Columns["IdMesto"].Visible = false;

            // ako već postoji naša kolona, ništa
            if (f.DgvVlasnici.Columns.Contains("colMesto")) return;

            // dodaćemo kolonu koja prikazuje Naziv umesto Id
            var col = new DataGridViewComboBoxColumn
            {
                Name = "colMesto",
                HeaderText = "Mesto",
                DataPropertyName = "IdMesto",   // vezana na Id iz Vlasnik
                DataSource = _mesta,
                ValueMember = nameof(Mesto.IdMesto),
                DisplayMember = nameof(Mesto.Naziv),
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                FlatStyle = FlatStyle.Standard,
                ReadOnly = true
            };

            // ubaci odmah posle kolone Ime (po želji)
            int insertAt = f.DgvVlasnici.Columns.Contains("Ime")
                ? f.DgvVlasnici.Columns["Ime"].Index + 1
                : f.DgvVlasnici.Columns.Count;

            f.DgvVlasnici.Columns.Insert(insertAt, col);
        }


        private void Sakrij(DataGridView dgv, params string[] names)
        {
            foreach (var n in names)
                if (dgv.Columns.Contains(n))
                    dgv.Columns[n].Visible = false;
        }
    }
}

