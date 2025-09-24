using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Vlasnik : IDomenObjekat
    {
        public int IdVlasnik { get; set; }
        public string Ime { get; set; } = "";
        public int BrojTelefona { get; set; }
        public string Adresa { get; set; } = "";
        public string Email { get; set; } = "";
        public int IdMesto { get; set; }
        
        public string NazivTabele => "Vlasnik";

        public string KoloneZaInsert => "ime,brojTelefona,adresa,email,idMesto";
        public string UbaciVrednosti => $"'{Esc(Ime)}',{BrojTelefona},'{Esc(Adresa)}','{Esc(Email)}',{IdMesto}";


        private static string Esc(string s) => (s ?? "").Replace("'", "''");
        public IDomenObjekat ReadRow(SqlDataReader reader)
        {
            return new Vlasnik
            {
                IdVlasnik = (int)reader["idVlasnik"],
                Ime = reader["ime"] as string ?? "",
                BrojTelefona = (int)reader["brojTelefona"],
                Adresa = reader["adresa"] as string ?? "",
                Email = reader["email"] as string ?? "",
                IdMesto = (int)reader["idMesto"]
            };
        }
    }
}
