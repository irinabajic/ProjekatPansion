using Domen.Dodatno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{

    public class PretraziPrijemneObrasceGridSO : OpstaSO
    {
        private readonly string _k;
        public List<PrijemniObrazacGrid> Rez { get; private set; } = new();
        public PretraziPrijemneObrasceGridSO(string k) { _k = k ?? ""; }

        protected override void Izvrsi()
        {
            string Esc(string s) => (s ?? "").Replace("'", "''");
            var k = Esc(_k);
            var where = string.IsNullOrWhiteSpace(k) //ako je kriterijum prazan, vrati sve
                ? "1=1"
                : $"VlasnikIme LIKE '%{k}%' OR RadnikIme LIKE '%{k}%' " +
                  $"OR MestoNaziv LIKE '%{k}%' OR Macke LIKE '%{k}%'";
            Rez = repozitorijum.Pretrazi(new PrijemniObrazacGrid(), where)
                               .Cast<PrijemniObrazacGrid>() 
                               .ToList(); //ako WHERE ne nadje nista, ToList() vraca praznu listu bez izuzetaka
        }
    }
}
