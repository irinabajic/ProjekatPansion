using Domen;
using Repozitorijum.DBRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class IzmeniVlasnikaSO : OpstaSO
    {
        private readonly Vlasnik v;
        public IzmeniVlasnikaSO(Vlasnik v) { this.v = v; }

        protected override void Izvrsi()
        {
            string Esc(string s) => (s ?? "").Replace("'", "''");
            var set =
                $"ime='{Esc(v.Ime)}', " +
                $"brojTelefona='{Esc(v.BrojTelefona)}', " +
                $"adresa='{Esc(v.Adresa)}', " +
                $"email='{Esc(v.Email)}', " +
            $"idMesto={v.IdMesto}";

            var rows = repozitorijum.Izmeni(new Vlasnik(), set, $"idVlasnik = {v.IdVlasnik}");
            if (rows != 1) throw new Exception("Vlasnik nije pronađen ili nije izmenjen.");
        }
    }
}
