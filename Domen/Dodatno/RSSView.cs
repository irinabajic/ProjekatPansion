using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Dodatno
{
    [Serializable]
    public class RSSView : IDomenObjekat
    {
        public int IdRadnik { get; set; }
        public int IdStrucnaSprema { get; set; }
        public string BrojSertifikata { get; set; } = "";
        public string Naziv { get; set; } = "";                // Stručna sprema - naziv
        public int StepenObrazovanja { get; set; }             // int, kao u tabeli
        public string Ustanova { get; set; } = "";

        // IDomenObjekat
        public string NazivTabele => "RSSView";      // čitamo iz VIEW-a
        public string KoloneZaInsert => "";          // ne koristimo za view
        public string UbaciVrednosti => "";          // ne koristimo za view

        public IDomenObjekat ReadRow(SqlDataReader reader)
        {
            return new RSSView
            {
                IdRadnik = reader["idRadnik"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idRadnik"]),
                IdStrucnaSprema = reader["idStrucnaSprema"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idStrucnaSprema"]),
                BrojSertifikata = reader["brojSertifikata"] == DBNull.Value ? "" : Convert.ToString(reader["brojSertifikata"]),
                Naziv = reader["naziv"] == DBNull.Value ? "" : Convert.ToString(reader["naziv"]),
                StepenObrazovanja = reader["stepenObrazovanja"] == DBNull.Value ? 0 : Convert.ToInt32(reader["stepenObrazovanja"]),
                Ustanova = reader["ustanova"] == DBNull.Value ? "" : Convert.ToString(reader["ustanova"])
            };
        }
    }
}
