using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSveVlasnikeSO : OpstaSO
    {
        public List<Vlasnik> Rez { get; private set; } = new();
        protected override void Izvrsi()
        {
            Rez = repozitorijum.VratiSvi(new Vlasnik()).Cast<Vlasnik>().ToList();
        }
    }
}
