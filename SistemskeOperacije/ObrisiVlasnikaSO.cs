using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiVlasnikaSO : OpstaSO
    {
        private readonly int id;
        public ObrisiVlasnikaSO(int id) { this.id = id; }

        protected override void Izvrsi()
        {
            var rows = repozitorijum.Obrisi(new Vlasnik(), $"idVlasnik = {id}");
            if (rows != 1) throw new Exception("Vlasnik nije obrisan.");
        }
    }
}
