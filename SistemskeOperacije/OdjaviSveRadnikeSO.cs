using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class OdjaviSveRadnikeSO : OpstaSO
    {
        protected override void Izvrsi()
        {
            // setuj sve na 0 (WHERE 1=1)
            repozitorijum.Izmeni(new Radnik(), "prijavljen = 0", "1=1");
        }
    }
}
