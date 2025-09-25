using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace KorisnickiInterfejs
{
    public class MojProfilKontroler
    {
        public bool Sacuvaj(FrmMojProfil f, Radnik stari)
        {
            if (stari == null) throw new ArgumentNullException(nameof(stari));

            var novi = new Radnik
            {
                IdRadnik = stari.IdRadnik,                     // obavezno
                Ime = f.TxtIme1.Text.Trim(),
                BrojTelefona = f.TxtTelefon1.Text.Trim(),
                Username = f.TxtUsername.Text.Trim(),
                Password = f.TxtPassword.Text.Trim(),
                Prijavljen = stari.Prijavljen                    // nema checkboxa na formi – zadržavamo staru vrednost
            };

            // brza validacija
            if (string.IsNullOrWhiteSpace(novi.Ime) ||
                string.IsNullOrWhiteSpace(novi.BrojTelefona) ||
                string.IsNullOrWhiteSpace(novi.Username) ||
                string.IsNullOrWhiteSpace(novi.Password))
            {
                MessageBox.Show("Sva polja su obavezna.");
                return false;
            }

            // (opciono) još malo validacije
            if (novi.Password.Length < 4)
            {
                MessageBox.Show("Lozinka mora imati najmanje 4 znaka.");
                return false;
            }

            // poziv serveru – SO: IzmeniRadnikaSO, CH: Operacija.IzmeniRadnika
            Komunikacija.Instance.PosaljiZahtev<object>(Operacija.IzmeniRadnika, novi);

            // osveži lokalno “session” stanje da UI odmah vidi promene
            stari.Ime = novi.Ime;
            stari.BrojTelefona = novi.BrojTelefona;
            stari.Username = novi.Username;
            stari.Password = novi.Password;
            stari.Prijavljen = novi.Prijavljen;

            // ako imaš globalni Session objekat, ažuriraj i njega
            try { Session.Session.Instance.PrijavljeniRadnik = stari; } catch { /* ignoriši ako ne koristiš Session */ }

            return true;
        }
    }
}
