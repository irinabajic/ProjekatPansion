using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiPrijemniObrazacSO : OpstaSO
    {
        private readonly int id;
        public ObrisiPrijemniObrazacSO(int id) { this.id = id; }

        protected override void Izvrsi()
        {
            var rows = repozitorijum.Obrisi(new PrijemniObrazac(),
                                            $"idPrijemniObrazac={id}");
            if (rows != 1) throw new Exception("Brisanje nije uspelo.");
        }
    }
}
