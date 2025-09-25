using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class PretraziStrucneSpremeSO : OpstaSO
    {
        private readonly string kriterijum;
        public List<StrucnaSprema> Rez { get; private set; } = new();
        public PretraziStrucneSpremeSO(string kriterijum) { this.kriterijum = kriterijum ?? ""; }

        protected override void Izvrsi()
        {
            string Esc(string s) => (s ?? "").Replace("'", "''");
            string k = Esc(kriterijum);
            string where = string.IsNullOrWhiteSpace(k)
                ? "1=1"
                : $"naziv LIKE '%{k}%' OR ustanova LIKE '%{k}%' OR CAST(stepenObrazovanja AS NVARCHAR) LIKE '%{k}%'";
            Rez = repozitorijum.Pretrazi(new StrucnaSprema(), where).Cast<StrucnaSprema>().ToList();
        }
    }
}
