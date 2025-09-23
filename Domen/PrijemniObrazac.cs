using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class PrijemniObrazac : IDomenObjekat
    {
        public int IdPrijemniObrazac { get; set; }
        public DateTime Datum { get; set; }
        public int IdRadnik { get; set; }
        public int IdVlasnik { get; set; }
        public string NazivTabele => "PrijemniObrazac";

        public string UbaciVrednosti => $"{IdPrijemniObrazac},'{Datum:yyyy-MM-dd}',{IdRadnik},{IdVlasnik}";

        public IDomenObjekat ReadRow(SqlDataReader reader)
        {
            return new PrijemniObrazac
            {
                IdPrijemniObrazac = (int)reader["idPrijemniObrazac"],
                Datum = (DateTime)reader["datum"],
                IdRadnik = (int)reader["idRadnik"],
                IdVlasnik = (int)reader["idVlasnik"]
            };
        }
    }
}
