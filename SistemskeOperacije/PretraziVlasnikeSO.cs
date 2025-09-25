using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class PretraziVlasnikeSO : OpstaSO
    {
        private readonly string kriterijum;
        public List<Vlasnik> Rez { get; private set; } = new();

        public PretraziVlasnikeSO(string kriterijum) { this.kriterijum = kriterijum ?? ""; }

        protected override void Izvrsi()
        {
            string Esc(string s) => (s ?? "").Replace("'", "''");
            string k = Esc(kriterijum);
            var where = string.IsNullOrWhiteSpace(k)
                ? "1=1"
                : $"ime LIKE '%{k}%' OR email LIKE '%{k}%' OR brojTelefona LIKE '%{k}%'";

            Rez = repozitorijum.Pretrazi(new Vlasnik(), where).Cast<Vlasnik>().ToList();
        }
    }
}
