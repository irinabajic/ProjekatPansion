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
    public class KolegeKontroler
    {
        public void Osvezi(FrmMain f)
        {
            try
            {
                var lista = Komunikacija.Instance
                    .PosaljiZahtev<List<Radnik>>(Operacija.VratiSveRadnike)
                    ?? new List<Radnik>();

                int? ja = Session.Session.Instance.PrijavljeniRadnik?.IdRadnik;
                lista = lista.Where(r => r.IdRadnik != ja).ToList();

                f.DgvKolege.AutoGenerateColumns = true;
                f.DgvKolege.DataSource = new BindingList<Radnik>(lista);

                Sakrij(f.DgvKolege, "Password", "NazivTabele", "KoloneZaInsert", "UbaciVrednosti");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju kolega: " + ex.Message);
            }
        }

        public void Dodaj(FrmMain f)
        {
            using var dlg = new FrmRadnikEdit();
            dlg.InitForCreate();
            if (dlg.ShowDialog(f) != DialogResult.OK) return;

            try
            {
                var novi = dlg.ToRadnik();   // uključuje početni password
                Komunikacija.Instance.PosaljiZahtev<object>(Operacija.DodajRadnika, novi);
                Osvezi(f);
                MessageBox.Show("Radnik dodat.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dodavanje nije uspelo: " + ex.Message);
            }
        }

        public void Izmeni(FrmMain f)
        {
            if (f.DgvKolege.CurrentRow?.DataBoundItem is not Radnik sel)
            { MessageBox.Show("Izaberi kolegu u tabeli."); return; }

            using var dlg = new FrmRadnikEdit();
            dlg.InitForEdit(sel);

            if (dlg.ShowDialog(f) != DialogResult.OK) return;

            try
            {
                // 1) Sačuvaj osnovna polja (lozinka se NE dira ovde)
                var izmenjen = dlg.ToRadnik();
                Komunikacija.Instance.PosaljiZahtev<object>(Operacija.IzmeniRadnika, izmenjen);

                // 2) Ako je uneta NOVA lozinka – pošalji i verifikaciju STARE
                if (dlg.ZahtevaPromenuLozinke)
                {
                    var payload = new Dictionary<string, string>
                    {
                        ["IdRadnik"] = sel.IdRadnik.ToString(),
                        ["Stara"] = dlg.StaraLozinka,
                        ["Nova"] = dlg.NovaLozinka
                    };

                    Komunikacija.Instance.PosaljiZahtev<object>(
                        Operacija.PromeniLozinkuSaVerifikacijom, payload);

                    //MessageBox.Show("Lozinka promenjena.");
                }

                Osvezi(f);
                MessageBox.Show("Sačuvano.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Izmena nije uspela: " + ex.Message);
            }
        }

        public void Obrisi(FrmMain f)
        {
            if (f.DgvKolege.CurrentRow?.DataBoundItem is not Radnik sel)
            { MessageBox.Show("Izaberi kolegu u tabeli."); return; }

            var ja = Session.Session.Instance.PrijavljeniRadnik?.IdRadnik;
            if (sel.IdRadnik == ja) { MessageBox.Show("Ne možeš obrisati samog sebe."); return; }

            if (MessageBox.Show($"Obrisati korisnika \"{sel.Username}\"?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            if (!Komunikacija.Instance.PosaljiZahtevSafe(Operacija.ObrisiRadnika, sel.IdRadnik, out var poruka))
            {
                MessageBox.Show(poruka ?? "Radnik ne može da se obriše jer postoje povezani podaci (RSS, obrasci…).",
                                "Brisanje nije moguće", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Osvezi(f);
            MessageBox.Show("Obrisano.");
        }

        private void Sakrij(DataGridView dgv, params string[] names)
        {
            foreach (var n in names)
                if (dgv.Columns.Contains(n)) dgv.Columns[n].Visible = false;
        }
    }
}
