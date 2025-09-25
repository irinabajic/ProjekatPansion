using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class IzmeniPrijemniObrazacSO : OpstaSO
    {
        private readonly PrijemniObrazac p;
        public IzmeniPrijemniObrazacSO(PrijemniObrazac p) { this.p = p; }

        protected override void Izvrsi()
        {
            var set =
                $"datum='{p.Datum:yyyy-MM-dd}', " +
                $"idRadnik={p.IdRadnik}, idVlasnik={p.IdVlasnik}";
            var rows = repozitorijum.Izmeni(new PrijemniObrazac(), set,
                                            $"idPrijemniObrazac={p.IdPrijemniObrazac}");
            if (rows != 1) throw new Exception("Prijemni obrazac nije izmenjen.");
        }
    }
}
