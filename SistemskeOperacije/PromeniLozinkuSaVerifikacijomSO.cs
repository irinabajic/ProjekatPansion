using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class PromeniLozinkuSaVerifikacijomSO : OpstaSO
    {
        private readonly int _id;
        private readonly string _stara;
        private readonly string _nova;

        public PromeniLozinkuSaVerifikacijomSO(int id, string stara, string nova)
        {
            _id = id;
            _stara = (stara ?? "").Trim();
            _nova = (nova ?? "").Trim();
        }

        protected override void Izvrsi()
        {
            if (_id <= 0) throw new Exception("Nedostaje IdRadnik.");
            if (string.IsNullOrEmpty(_stara)) throw new Exception("Trenutna lozinka nije uneta.");
            if (_nova.Length < 4) throw new Exception("Nova lozinka mora imati najmanje 4 znaka.");

            var r = repozitorijum.Pretrazi(new Radnik(), $"idRadnik={_id}")
                                 .Cast<Radnik>()
                                 .FirstOrDefault()
                    ?? throw new Exception("Radnik ne postoji.");

            // robustno poređenje: skini trailing razmake iz baze ako je kolona CHAR/NCHAR
            var dbPass = (r.Password ?? "").TrimEnd();
            if (!string.Equals(dbPass, _stara, StringComparison.Ordinal))
                throw new Exception("Trenutna lozinka nije ispravna.");

            // promeni lozinku (password je rezervisana reč → zagrade)
            string set = $"[password]='{Esc(_nova)}'";
            string where = $"idRadnik={_id}";
            repozitorijum.Izmeni(new Radnik(), set, where);
        }

        private static string Esc(string s) => (s ?? "").Replace("'", "''");
    }
}
