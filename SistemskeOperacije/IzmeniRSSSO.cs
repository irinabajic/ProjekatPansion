using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class IzmeniRSSSO : OpstaSO
    {
        private readonly RSS _rss;
        public IzmeniRSSSO(RSS rss) { _rss = rss; }

        protected override void Izvrsi()
        {
            if (_rss == null) throw new ArgumentNullException(nameof(_rss));
            if (_rss.IdRadnik <= 0 || _rss.IdStrucnaSprema <= 0)
                throw new InvalidOperationException("Nevalidan identifikator.");
            if (string.IsNullOrWhiteSpace(_rss.BrojSertifikata))
                throw new InvalidOperationException("Broj sertifikata je obavezan.");

            // veza mora postojati
            bool exists = repozitorijum.Pretrazi(new RSS(),
                            $"idRadnik={_rss.IdRadnik} AND idStrucnaSprema={_rss.IdStrucnaSprema}").Any();
            if (!exists) throw new InvalidOperationException("Veza ne postoji.");

            string esc(string s) => (s ?? "").Replace("'", "''");

            int aff = repozitorijum.Izmeni(new RSS(),
                       setClause: $"brojSertifikata='{esc(_rss.BrojSertifikata)}'",
                       whereClause: $"idRadnik={_rss.IdRadnik} AND idStrucnaSprema={_rss.IdStrucnaSprema}");
            if (aff != 1) throw new Exception("Izmena nije uspela.");
        }
    }
}
