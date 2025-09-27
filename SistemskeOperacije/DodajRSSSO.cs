using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class DodajRSSSO : OpstaSO
    {
        private readonly RSS _rss;
        public DodajRSSSO(RSS rss) { _rss = rss; }

        protected override void Izvrsi()
        {
            if (_rss == null) throw new ArgumentNullException(nameof(_rss));
            if (_rss.IdRadnik <= 0 || _rss.IdStrucnaSprema <= 0)
                throw new InvalidOperationException("Nevalidan identifikator.");
            if (string.IsNullOrWhiteSpace(_rss.BrojSertifikata))
                throw new InvalidOperationException("Broj sertifikata je obavezan.");

            // roditelji postoje?
            bool radnikOk = repozitorijum.Pretrazi(new Radnik(), $"idRadnik={_rss.IdRadnik}").Any();
            if (!radnikOk) throw new InvalidOperationException("Radnik ne postoji.");

            bool ssOk = repozitorijum.Pretrazi(new StrucnaSprema(), $"idStrucnaSprema={_rss.IdStrucnaSprema}").Any();
            if (!ssOk) throw new InvalidOperationException("Stručna sprema ne postoji.");

            // duplikat para?
            bool exists = repozitorijum.Pretrazi(new RSS(),
                           $"idRadnik={_rss.IdRadnik} AND idStrucnaSprema={_rss.IdStrucnaSprema}").Any();
            if (exists) throw new InvalidOperationException("Veza već postoji.");

            // INSERT (bez identity)
            int aff = repozitorijum.DodajBezIdentity(_rss);
            if (aff != 1) throw new Exception("Dodavanje RSS nije uspelo.");
        }
    }
}
