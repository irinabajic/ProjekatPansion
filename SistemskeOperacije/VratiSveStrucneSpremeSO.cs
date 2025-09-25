using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSveStrucneSpremeSO : OpstaSO
    {
        public List<StrucnaSprema> Rez { get; private set; } = new();
        protected override void Izvrsi()
        {
            Rez = repozitorijum.VratiSvi(new StrucnaSprema())
                               .Cast<StrucnaSprema>()
                               .ToList();
        }
    }
}
