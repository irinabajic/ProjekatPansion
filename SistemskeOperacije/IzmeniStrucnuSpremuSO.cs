using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class IzmeniStrucnuSpremuSO : OpstaSO
    {
        private readonly StrucnaSprema s;
        public IzmeniStrucnuSpremuSO(StrucnaSprema s) { this.s = s; }
        protected override void Izvrsi()
        {
            string Esc(string v) => (v ?? "").Replace("'", "''");
            var set = $"naziv='{Esc(s.Naziv)}', stepenObrazovanja={s.StepenObrazovanja}, ustanova='{Esc(s.Ustanova)}'";
            var rows = repozitorijum.Izmeni(new StrucnaSprema(), set, $"idStrucnaSprema = {s.IdStrucnaSprema}");
            if (rows != 1) throw new Exception("Stručna sprema nije izmenjena.");
        }
    }
}
