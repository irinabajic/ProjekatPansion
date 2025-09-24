using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSveRadnikeSO : OpstaSO
    {
        public List<Radnik> Rez { get; private set; }
        protected override void Izvrsi()
        {
            Rez = repozitorijum.VratiSvi(new Radnik())
                               .OfType<Radnik>()
                               .ToList();
        }
    }
}
