using AplikacionaLogika;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zajednicki;

namespace KorisnickiInterfejs.GUIKontroler
{
    public class PrijemniKreirajKontroler
    {
        private Dictionary<int, string> _mestoById = new();
        private List<Vlasnik> _vlasnici = new();

        public void Init(FrmPrijemniKreiraj f)
        {
            // datum
            f.LblDatum.Text = DateTime.Today.ToString("dd.MM.yyyy.");

            // radnik iz sesije (read-only labele)
            var r = Session.Session.Instance.PrijavljeniRadnik;
            f.LblRadnikIme.Text = r.Ime;
            f.LblRadnikUsername.Text = r.Username;
            f.LblRadnikTelefon.Text = r.BrojTelefona;

            // vlasnici
            _vlasnici = Komunikacija.Instance
                         .PosaljiZahtev<List<Vlasnik>>(Operacija.VratiSveVlasnike, null);
            f.CmbVlasnik.DropDownStyle = ComboBoxStyle.DropDownList;
            f.CmbVlasnik.DisplayMember = "Ime";       // kod tebe je polje Ime = "Ime i prezime"
            f.CmbVlasnik.ValueMember = "IdVlasnik";
            f.CmbVlasnik.DataSource = _vlasnici;

            // mesta (za labelu – lookup id→naziv)
            var mesta = Komunikacija.Instance
                        .PosaljiZahtev<List<Mesto>>(Operacija.VratiSvaMesta, null);
            _mestoById = mesta.ToDictionary(m => m.IdMesto, m => m.Naziv);

            // inicijalno popuni infо o vlasniku
            OsveziVlasnikInfo(f);
        }

        public void OsveziVlasnikInfo(FrmPrijemniKreiraj f)
        {
            if (f.CmbVlasnik.SelectedItem is Vlasnik v)
            {
                f.LblVlasnikAdresa.Text = v.Adresa;
                f.LblVlasnikTelefon.Text = v.BrojTelefona;
                f.LblVlasnikEmail.Text = v.Email;
                f.LblVlasnikMesto.Text = _mestoById.TryGetValue(v.IdMesto, out var naziv) ? naziv : "";
            }
            else
            {
                f.LblVlasnikAdresa.Text = f.LblVlasnikTelefon.Text = f.LblVlasnikEmail.Text = f.LblVlasnikMesto.Text = "";
            }
        }

        // INSERT header, vrati nov ID
        public int Sacuvaj(FrmPrijemniKreiraj f)
        {
            if (f.CmbVlasnik.SelectedValue is not int idVlasnik)
            { MessageBox.Show("Izaberi vlasnika."); return 0; }

            var r = Session.Session.Instance.PrijavljeniRadnik;

            var p = new PrijemniObrazac
            {
                Datum = DateTime.Today,
                IdRadnik = r.IdRadnik,
                IdVlasnik = idVlasnik
            };

            try
            {
                var idObj = Komunikacija.Instance.PosaljiZahtev<object>(Operacija.DodajPrijemniObrazac, p);
                return ParseId(idObj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private static int ParseId(object idObj)
        {
            switch (idObj)
            {
                case int i: return i;
                case long l: return checked((int)l);
                case string s when int.TryParse(s, out var n): return n;
                case JsonElement je when je.ValueKind == JsonValueKind.Number: return je.GetInt32();
                case JsonElement je when je.ValueKind == JsonValueKind.String
                                      && int.TryParse(je.GetString(), out var m):
                    return m;
                default: throw new InvalidOperationException("Neočekivan tip ID odgovora: " + idObj?.GetType().FullName);
            }
        }
    }
}
