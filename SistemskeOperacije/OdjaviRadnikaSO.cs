using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class OdjaviRadnikaSO : OpstaSO
    {
        private readonly int id;
        public OdjaviRadnikaSO(int id) { this.id = id; }

        protected override void Izvrsi()
        {
            repozitorijum.Izmeni(new Radnik(), "prijavljen = 0", $"idRadnik = {id}");
        }
    }
}
