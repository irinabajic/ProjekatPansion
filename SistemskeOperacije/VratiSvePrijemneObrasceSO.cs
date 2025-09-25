using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSvePrijemneObrasceSO : OpstaSO
    {
        public List<PrijemniObrazac> Rez { get; private set; } = new();
        protected override void Izvrsi()
        {
            Rez = repozitorijum.VratiSvi(new PrijemniObrazac())
                               .Cast<PrijemniObrazac>().ToList();
        }
    }
}
