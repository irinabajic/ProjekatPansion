using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class DodajMackuSO : OpstaSO
    {
        private readonly Macka m;
        public int NoviId { get; private set; }
        public DodajMackuSO(Macka m) { this.m = m; }
        protected override void Izvrsi()
        {
            NoviId = repozitorijum.Dodaj(m);
        }
    }
}
