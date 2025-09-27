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
        private readonly Radnik _r;
        public IzmeniRadnikaSO(Radnik r) { _r = r; }

        protected override void Izvrsi()
        {
            if (_r.IdRadnik <= 0) throw new Exception("Nedostaje IdRadnik.");
            if (string.IsNullOrWhiteSpace(_r.Username)) throw new Exception("Username je obavezan.");

            string escUser = _r.Username.Replace("'", "''");
            // (opciono) proveri unikatnost username-a:
            // ...

            // ⛔ password se NIKAD ne menja ovde
            string set = $"ime='{Esc(_r.Ime)}', brojTelefona='{Esc(_r.BrojTelefona)}', username='{escUser}', prijavljen={(_r.Prijavljen ? 1 : 0)}";
            string where = $"idRadnik={_r.IdRadnik}";
            repozitorijum.Izmeni(new Radnik(), set, where);
        }
        private static string Esc(string s) => (s ?? "").Replace("'", "''");
    }
}
