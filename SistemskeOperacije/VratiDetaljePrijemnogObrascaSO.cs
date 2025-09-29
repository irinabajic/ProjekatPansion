using Domen.Dodatno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiDetaljePrijemnogObrascaSO : OpstaSO
    {
        private readonly int _id;
        public PrijemniDetaljiDTO Rez { get; private set; } = new();
        public VratiDetaljePrijemnogObrascaSO(int id) { _id = id; }

        protected override void Izvrsi()
        {
            var h = repozitorijum.Pretrazi(new PrijemniObrazacView(), $"idPrijemniObrazac={_id}")
                                 .Cast<PrijemniObrazacView>()
                                 .FirstOrDefault() ?? throw new Exception("Prijemni obrazac nije pronađen.");

            var stavke = repozitorijum.Pretrazi(new StavkaPrijemnogView(), $"idPrijemniObrazac={_id}")
                                      .Cast<StavkaPrijemnogView>()
                                      .OrderBy(s => s.Rb)
                                      .ToList();

            Rez = new PrijemniDetaljiDTO { Header = h, Stavke = stavke };
        }
    }
}
