using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiStrucnuSpremuSO : OpstaSO
    {
        private readonly int id;
        public ObrisiStrucnuSpremuSO(int id) { this.id = id; }
        protected override void Izvrsi()
        {
            var rows = repozitorijum.Obrisi(new StrucnaSprema(), $"idStrucnaSprema = {id}");
            if (rows != 1) throw new Exception("Stručna sprema nije obrisana.");
        }
    }
}
