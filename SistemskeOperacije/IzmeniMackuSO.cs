using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class IzmeniMackuSO :OpstaSO
    {
        private readonly Macka m;
        public IzmeniMackuSO(Macka m) { this.m = m; }
        protected override void Izvrsi()
        {
            string Esc(string s) => (s ?? "").Replace("'", "''");
            var set = $"naziv='{Esc(m.Naziv)}', rasa='{Esc(m.Rasa)}', napomene='{Esc(m.Napomene)}'";
            var rows = repozitorijum.Izmeni(new Macka(), set, $"idMacka = {m.IdMacka}");
            if (rows != 1) throw new Exception("Mačka nije pronađena ili nije izmenjena.");
        }
        private static string Esc(string s) => (s ?? "").Replace("'", "''");
    }
}
