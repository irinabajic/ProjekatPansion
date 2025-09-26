using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Mesto : IDomenObjekat
    {
        public int IdMesto { get; set; }
        public string Koordinate { get; set; } = "";
        public string Naziv { get; set; } = "";   // NOVO

        public string NazivTabele => "Mesto";
        public string KoloneZaInsert => "koordinate,naziv"; // redosled kao u UbaciVrednosti
        public string UbaciVrednosti => $"'{Esc(Koordinate)}','{Esc(Naziv)}'";

        private static string Esc(string s) => (s ?? "").Replace("'", "''");
        public IDomenObjekat ReadRow(SqlDataReader reader) => new Mesto
        {
            IdMesto = (int)reader["idMesto"],
            Koordinate = reader["koordinate"] as string ?? "",
            Naziv = reader["naziv"] as string ?? ""
        };
    }
}
