using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class PretraziMackeSO : OpstaSO
    {
        private readonly string kriterijum;  // npr. "naziv LIKE 'Mi%'"
        public List<Macka> Rez { get; private set; }
        public PretraziMackeSO(string kriterijum) { this.kriterijum = kriterijum; }
        protected override void Izvrsi()
        {
            Rez = repozitorijum.Pretrazi(new Macka(), kriterijum)
                               .OfType<Macka>().ToList();
        }
    }
}
