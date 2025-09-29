using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiStavkuObrascaSO : OpstaSO
    {
        private readonly int _idPO;
        private readonly int _rb;
        public ObrisiStavkuObrascaSO(int idPrijemniObrazac, int rb)
        { _idPO = idPrijemniObrazac; _rb = rb; }

        protected override void Izvrsi()
        {
            // 1) obriši
            repozitorijum.Obrisi(new StavkaObrasca(),
                $"idPrijemniObrazac={_idPO} AND rb={_rb}");

            // 2) reindex – prvo privremeno pomerimo u "visoke" brojeve
            var sve = repozitorijum.Pretrazi(new StavkaObrasca(),
                         $"idPrijemniObrazac={_idPO} ORDER BY rb")
                         .Cast<StavkaObrasca>().ToList();

            for (int i = 0; i < sve.Count; i++)
            {
                var st = sve[i];
                int newRb = i + 1;
                if (st.Rb != newRb)
                {
                    // pass 1: prebaci u 100000 + newRb da ne dođe do sudara
                    repozitorijum.Izmeni(new StavkaObrasca(),
                        $"rb={100000 + newRb}",
                        $"idPrijemniObrazac={_idPO} AND rb={st.Rb}");
                }
            }

            // pass 2: vrati sve >=100000 u prave vrednosti
            repozitorijum.Izmeni(new StavkaObrasca(),
                "rb=rb-100000",
                $"idPrijemniObrazac={_idPO} AND rb>=100000");
        }
    }
}
