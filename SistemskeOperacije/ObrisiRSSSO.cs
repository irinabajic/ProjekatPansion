using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiRSSSO : OpstaSO
    {
        private readonly RSS _rss;
        public ObrisiRSSSO(RSS rss) { _rss = rss; }

        protected override void Izvrsi()
        {
            if (_rss == null) throw new ArgumentNullException(nameof(_rss));
            if (_rss.IdRadnik <= 0 || _rss.IdStrucnaSprema <= 0)
                throw new InvalidOperationException("Nevalidan identifikator.");

            bool exists = repozitorijum.Pretrazi(new RSS(),
                            $"idRadnik={_rss.IdRadnik} AND idStrucnaSprema={_rss.IdStrucnaSprema}").Any();
            if (!exists) throw new InvalidOperationException("Veza ne postoji.");

            int aff = repozitorijum.Obrisi(new RSS(),
                        whereClause: $"idRadnik={_rss.IdRadnik} AND idStrucnaSprema={_rss.IdStrucnaSprema}");
            if (aff != 1) throw new Exception("Brisanje nije uspelo.");
        }
    }
}
