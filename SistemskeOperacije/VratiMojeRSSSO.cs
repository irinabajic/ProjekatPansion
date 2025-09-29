using DBBroker;
using Domen.Dodatno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiMojeRSSSO : OpstaSO
    {
        private readonly int _idRadnik;
        public List<RSSView> Rez { get; private set; } = new();

        public VratiMojeRSSSO(int idRadnik) { _idRadnik = idRadnik; }

        protected override void Izvrsi()
        {
            Rez = repozitorijum.Pretrazi(new RSSView(), $"idRadnik={_idRadnik}")
                               .Cast<RSSView>()
                               .OrderBy(x => x.Naziv)
                               .ToList();
        }
    }
}
