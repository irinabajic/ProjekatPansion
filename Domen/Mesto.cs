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

        public string NazivTabele => "Mesto";

        public string UbaciVrednosti => $"{IdMesto},'{Koordinate}'";

        public IDomenObjekat ReadRow(SqlDataReader reader)
        {
            return new Mesto
            {
                IdMesto = (int)reader["idMesto"],
                Koordinate = reader["koordinate"] as string ?? ""
            };
        }
    }
}
