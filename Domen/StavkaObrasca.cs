using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class StavkaObrasca : IDomenObjekat
    {
        public int IdPrijemniObrazac { get; set; }
        public int Rb { get; set; }
        public string Naziv { get; set; } = "";
        public string Opis { get; set; } = "";
        public int IdMacka { get; set; }

        public string NazivTabele => "StavkaObrasca";

        public string UbaciVrednosti => $"{IdPrijemniObrazac},{Rb},'{Naziv}','{Opis}',{IdMacka}";

        public IDomenObjekat ReadRow(SqlDataReader reader)
        {
            return new StavkaObrasca
            {
                IdPrijemniObrazac = (int)reader["idPrijemniObrazac"],
                Rb = (int)reader["rb"],
                Naziv = reader["naziv"] as string ?? "",
                Opis = reader["opis"] as string ?? "",
                IdMacka = (int)reader["idMacka"]
            };
        }
    }
}
