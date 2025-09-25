using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class DodajPrijemniObrazacSO : OpstaSO
    {
        private readonly PrijemniObrazac p;
        public int NoviId { get; private set; }
        public DodajPrijemniObrazacSO(PrijemniObrazac p) { this.p = p; }

        protected override void Izvrsi()
        {
            NoviId = repozitorijum.Dodaj(p);
            if (NoviId <= 0) throw new Exception("Prijemni obrazac nije dodat.");
        }
    }
}
