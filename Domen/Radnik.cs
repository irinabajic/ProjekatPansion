using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace Domen
{
    [Serializable]
    public class Radnik : IDomenObjekat
    {
        public int IdRadnik { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Ime { get; set; } = "";
        public string BrojTelefona { get; set; } = "";
        public bool Prijavljen { get; set; }

        [Browsable(false)]
        public string NazivTabele => "Radnik";
        [Browsable(false)]
        public string UbaciVrednosti => $"{IdRadnik},'{Ime}','{BrojTelefona}','{Username}','{Password}',{Prijavljen}";

        public IDomenObjekat ReadRow(SqlDataReader reader)
        {
            return new Radnik
            {
                IdRadnik = (int)reader["idRadnik"],
                Ime = reader["ime"] as string ?? "",
                BrojTelefona = reader["brojTelefona"] as string ?? "",
                Username = reader["username"] as string ?? "",
                Password = reader["password"] as string ?? "",
                Prijavljen = reader["prijavljen"] != DBNull.Value && (bool)reader["prijavljen"]
            };
        }
    }
}
