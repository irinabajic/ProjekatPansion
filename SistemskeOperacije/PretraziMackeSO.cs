using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class PretraziMackeSO : OpstaSO
    {
        private readonly string kriterijum;  // npr. "naziv LIKE 'Mi%'"
        public List<Macka> Rez { get; private set; }
        public PretraziMackeSO(string kriterijum) { this.kriterijum = kriterijum; }
        protected override void Izvrsi()
        {
            string Esc(string s) => (s ?? "").Replace("'", "''");
            string k = Esc(kriterijum ?? "");
            string where = string.IsNullOrWhiteSpace(k)
                ? "1=1"
                : $"naziv LIKE '%{k}%' OR rasa LIKE '%{k}%' OR napomene LIKE '%{k}%'";
            Rez = repozitorijum.Pretrazi(new Macka(), where).OfType<Macka>().ToList();

        }
    }
}
