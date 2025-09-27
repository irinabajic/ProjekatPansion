using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class DodajRadnikaSO : OpstaSO
    {
        private readonly Radnik _r;
        public int NoviId { get; private set; }
        public DodajRadnikaSO(Radnik r) { _r = r; }

        protected override void Izvrsi()
        {
            if (string.IsNullOrWhiteSpace(_r.Username) ||
                string.IsNullOrWhiteSpace(_r.Password) ||
                string.IsNullOrWhiteSpace(_r.Ime))
                throw new Exception("Username, lozinka i ime su obavezni.");

            string esc = _r.Username.Replace("'", "''");
            bool zauzet = repozitorijum.Pretrazi(new Radnik(), $"username='{esc}'")
                                       .Cast<Radnik>().Any();
            if (zauzet) throw new Exception("Korisničko ime je zauzeto.");

            NoviId = repozitorijum.Dodaj(_r);
        }
    }
}
