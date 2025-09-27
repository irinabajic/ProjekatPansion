using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class PromeniLozinkuRadnikaSO : OpstaSO
    {
        private readonly int _id;
        private readonly string _nova;
        public PromeniLozinkuRadnikaSO(int id, string nova) { _id = id; _nova = (nova ?? "").Trim(); }

        protected override void Izvrsi()
        {
            if (_id <= 0) throw new Exception("Nedostaje IdRadnik.");
            if (_nova.Length < 4) throw new Exception("Nova lozinka je prekratka.");

            string set = $"[password]='{_nova.Replace("'", "''")}'"; // [password] zbog rezervisane reči
            string where = $"idRadnik={_id}";
            repozitorijum.Izmeni(new Radnik(), set, where);
        }
    }
}
