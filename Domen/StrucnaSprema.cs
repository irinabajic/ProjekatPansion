using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class StrucnaSprema : IDomenObjekat
    {
        public int IdStrucnaSprema { get; set; }
        public string Naziv { get; set; } = "";
        public int StepenObrazovanja { get; set; }
        public string Ustanova { get; set; } = "";

        public string NazivTabele => "StrucnaSprema";

        public string KoloneZaInsert => "naziv,stepenObrazovanja,ustanova";
        public string UbaciVrednosti => $"'{Esc(Naziv)}',{StepenObrazovanja},'{Esc(Ustanova)}'";

        private static string Esc(string s) => (s ?? "").Replace("'", "''");
        public IDomenObjekat ReadRow(SqlDataReader reader)
        {
            return new StrucnaSprema
            {
                IdStrucnaSprema = (int)reader["idStrucnaSprema"],
                Naziv = reader["naziv"] as string ?? "",
                StepenObrazovanja = (int)reader["stepenObrazovanja"],
                Ustanova = reader["ustanova"] as string ?? ""
            };
        }
    }
}
