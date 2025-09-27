using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiRadnikaSO : OpstaSO
    {
        private readonly int _id;
        public ObrisiRadnikaSO(int id) { _id = id; }
        protected override void Izvrsi()
        {
            repozitorijum.Obrisi(new Radnik(), $"idRadnik={_id}");
        }
    }
}
