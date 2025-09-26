using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class RegistrujRadnikaSO : OpstaSO
    {
        private readonly Radnik r;
        public RegistrujRadnikaSO(Radnik r) { this.r = r; }

        protected override void Izvrsi()
        {
            if (r == null) throw new ArgumentNullException(nameof(r));

            string Esc(string s) => (s ?? "").Replace("'", "''");

            // osnovna validacija
            if (string.IsNullOrWhiteSpace(r.Ime)) throw new Exception("Ime je obavezno.");
            if (string.IsNullOrWhiteSpace(r.Username)) throw new Exception("Korisničko ime je obavezno.");
            if (string.IsNullOrWhiteSpace(r.Password)) throw new Exception("Lozinka je obavezna.");
            if (r.Username.Length < 3) throw new Exception("Korisničko ime mora imati bar 3 znaka.");
            if (r.Password.Length < 4) throw new Exception("Lozinka mora imati bar 4 znaka.");

            // provera unikatnosti username-a
            var postoji = repozitorijum.Pretrazi(new Radnik(), $"username = '{Esc(r.Username)}'")
                                       .Cast<Radnik>()
                                       .Any();
            if (postoji) throw new Exception("Korisničko ime je zauzeto.");

            // podrazumevano nije prijavljen
            r.Prijavljen = false;

            // insert
            repozitorijum.Dodaj(r); // generički insert koristi KoloneZaInsert/UbaciVrednosti iz domena
        }

    }
}
