using Microsoft.Data.SqlClient;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Browsable(false)]
        public string NazivTabele => "Macka";
        [Browsable(false)]
        public string KoloneZaInsert => "naziv, rasa, napomene";
        [Browsable(false)]
        public string UbaciVrednosti => $"'{Esc(Naziv)}',''{Esc(Rasa)}'".Replace("''", "'") switch { _ => $"'{Esc(Naziv)}','{Esc(Rasa)}','{Esc(Napomene)}'" };

        private static string Esc(string s) => (s ?? "").Replace("'", "''");

        public IDomenObjekat ReadRow(SqlDataReader r) => new Macka
        {
            IdMacka = (int)r["idMacka"],
            Naziv = r["naziv"] as string ?? "",
            Rasa = r["rasa"] as string ?? "",
            Napomene = r["napomene"] as string ?? ""
        };

        public override string ToString()
        {
            return Naziv;
        }
       
    }

    
}
