using Domen.Dodatno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSvePrijemneObrasceGridSO : OpstaSO
    {
        public List<PrijemniObrazacGrid> Rez { get; private set; } = new();
        protected override void Izvrsi()
        {
            Rez = repozitorijum.VratiSvi(new PrijemniObrazacGrid())
                               .Cast<PrijemniObrazacGrid>()
                               .ToList();
        }
    }
}
