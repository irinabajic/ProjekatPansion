using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSvaMestaSO : OpstaSO  
    {
        public List<Mesto> Rez { get; private set; } = new();

        protected override void Izvrsi()
        {
            Rez = repozitorijum.VratiSvi(new Mesto())
                               .Cast<Mesto>()
                               .OrderBy(m => m.Naziv)
                               .ToList();
        }
    }
}
