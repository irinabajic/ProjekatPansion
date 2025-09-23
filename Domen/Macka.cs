using Microsoft.Data.SqlClient;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Macka : IDomenObjekat
    {
        public int IdMacka { get; set; }
        public string Naziv { get; set; } = "";
        public string Rasa { get; set; } = "";
        public string Napomene { get; set; } = "";
 
        //ostali property za macku
        public string NazivTabele => "Macka";

        public string UbaciVrednosti => $"{IdMacka},'{Naziv}','{Rasa}','{Napomene}'";

        public IDomenObjekat ReadRow(SqlDataReader reader)
        {
            return new Macka
            {
                IdMacka = (int)reader["idMacka"],
                Naziv = reader["naziv"] as string ?? "",
                Rasa = reader["rasa"] as string ?? "",
                Napomene = reader["napomene"] as string ?? ""
            };
        }

        public override string ToString()
        {
            return Naziv;
        }
       
    }

    
}
