using Domen;
using Repozitorijum.DBRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class DodajStavkuObrascaSO : OpstaSO
    {
        private readonly StavkaObrasca _ulaz;
        public DodajStavkuObrascaSO(StavkaObrasca ulaz) => _ulaz = ulaz;

        protected override void Izvrsi()
        {
            // 1) izračunaj rb = MAX+1 za dati prijemni
            var lista = repozitorijum.Pretrazi(new StavkaObrasca(),
                         $"idPrijemniObrazac={_ulaz.IdPrijemniObrazac}");
            int nextRb = lista.Count == 0 ? 1 : lista.Cast<StavkaObrasca>().Max(s => s.Rb) + 1;

            // 2) insert
            _ulaz.Rb = nextRb;
            repozitorijum.DodajBezIdentity(_ulaz);
        }
    }
}
