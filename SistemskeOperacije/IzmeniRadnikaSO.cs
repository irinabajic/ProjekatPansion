using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class IzmeniRadnikaSO : OpstaSO
    {
        private readonly Radnik r;
        public IzmeniRadnikaSO(Radnik r) { this.r = r; }

        protected override void Izvrsi()
        {
            if (r == null) throw new ArgumentNullException(nameof(r));
            if (r.IdRadnik <= 0) throw new Exception("Id radnika je obavezan.");

            string Esc(string s) => (s ?? "").Replace("'", "''");

            var set =
                $"ime='{Esc(r.Ime)}', " +
                $"brojTelefona='{Esc(r.BrojTelefona)}', " +
                $"username='{Esc(r.Username)}', " +
                $"password='{Esc(r.Password)}', " +
                $"prijavljen={(r.Prijavljen ? 1 : 0)}";

            var rows = repozitorijum.Izmeni(new Radnik(), set, $"idRadnik = {r.IdRadnik}");
            if (rows != 1) throw new Exception("Radnik nije pronađen ili nije izmenjen.");
        }
    }
}
