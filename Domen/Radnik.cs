using Microsoft.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Radnik : IDomenObjekat
    {
        public int IdRadnik { get; set; }
        public string Ime { get; set; } = "";
        public int BrojTelefona { get; set; }

        public string NazivTabele => "Radnik";

        public string UbaciVrednosti => $"{IdRadnik},'{Ime}',{BrojTelefona}";

        public IDomenObjekat ReadRow(SqlDataReader reader)
        {
            return new Radnik
            {
                IdRadnik = (int)reader["idRadnik"],
                Ime = reader["ime"] as string ?? "",
                BrojTelefona = (int)reader["brojTelefona"]
            };
        }
    }
}
