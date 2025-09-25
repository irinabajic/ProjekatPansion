using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class DodajVlasnikaSO : OpstaSO
    {
        private readonly Vlasnik v;
        public int NoviId { get; private set; }

        public DodajVlasnikaSO(Vlasnik v) { this.v = v; }

        protected override void Izvrsi()
        {
            NoviId = repozitorijum.Dodaj(v);
            if (NoviId <= 0) throw new Exception("Vlasnik nije dodat.");
        }
    }
}
