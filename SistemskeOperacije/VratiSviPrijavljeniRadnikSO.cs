using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSviPrijavljeniRadnikSO : OpstaSO
    {
        public List<Radnik> Rez {  get; private set; }
        protected override void Izvrsi()
        {
            Rez = repozitorijum
                    .Pretrazi(new Radnik(), "prijavljen = 1")
                    .OfType<Radnik>()
                    .ToList();
        }
    }
}
