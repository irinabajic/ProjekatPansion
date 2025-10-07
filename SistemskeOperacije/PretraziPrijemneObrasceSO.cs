using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    // Pretrazi (po datumu "YYYY-MM-DD" ili radniku/vlasniku)
    public class PretraziPrijemneObrasceSO : OpstaSO
    {
        private readonly string kriterijum;
        public List<PrijemniObrazac> Rez { get; private set; } = new();

        public PretraziPrijemneObrasceSO(string kriterijum) { this.kriterijum = kriterijum ?? ""; }

        protected override void Izvrsi()
        {
            string Esc(string s) => (s ?? "").Replace("'", "''");
            var k = Esc(kriterijum.Trim());

            string where;
            if (string.IsNullOrWhiteSpace(k))
                where = "1=1";
            else if (int.TryParse(k, out var id))
                where = $"idRadnik={id} OR idVlasnik={id} OR idPrijemniObrazac={id}";
            else
                // datum kao tekst YYYY-MM-DD
                where = $"CONVERT(varchar(10), datum, 23) LIKE '%{k}%'";

            Rez = repozitorijum.Pretrazi(new PrijemniObrazac(), where)
                               .Cast<PrijemniObrazac>().ToList();
        }
    }
}
