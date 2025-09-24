using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class RSS : IDomenObjekat
    {
        public int IdRadnik { get; set; }
        public int IdStrucnaSprema { get; set; }
        public string BrojSertifikata { get; set; } = "";

        public string NazivTabele => "RSS";

        public string KoloneZaInsert => "idRadnik,idStrucnaSprema,brojSertifikata";
        public string UbaciVrednosti => $"{IdRadnik},{IdStrucnaSprema},'{Esc(BrojSertifikata)}'";

        private static string Esc(string s) => (s ?? "").Replace("'", "''");
        public IDomenObjekat ReadRow(SqlDataReader reader)
        {
            return new RSS
            {
                IdRadnik = (int)reader["idRadnik"],
                IdStrucnaSprema = (int)reader["idStrucnaSprema"],
                BrojSertifikata = reader["brojSertifikata"] as string ?? ""
            };
        }
    }
}
