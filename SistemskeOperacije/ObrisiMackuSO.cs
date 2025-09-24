using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiMackuSO : OpstaSO
    {
        private readonly int id;
        public ObrisiMackuSO(int id) { this.id = id; }
        protected override void Izvrsi()
        {
            repozitorijum.Obrisi(new Macka(), $"idMacka = {id}");
        }
    }
}
