using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class DodajStrucnuSpremuSO : OpstaSO
    {
        private readonly StrucnaSprema s;
        public int NoviId { get; private set; }
        public DodajStrucnuSpremuSO(StrucnaSprema s) { this.s = s; }
        protected override void Izvrsi()
        {
            if (string.IsNullOrWhiteSpace(s.Naziv) ||
                string.IsNullOrWhiteSpace(s.Ustanova))
                throw new Exception("Naziv i ustanova su obavezni.");

            NoviId = repozitorijum.Dodaj(s);
            if (NoviId <= 0) throw new Exception("Stručna sprema nije dodata.");
        }
    }
}
