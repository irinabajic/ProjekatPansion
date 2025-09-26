using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class PrijemniObrazacGrid : IDomenObjekat
    {
        public int IdPrijemniObrazac { get; set; }
        public DateTime Datum { get; set; }

        public int IdRadnik { get; set; }
        public string RadnikIme { get; set; } = "";

        public int IdVlasnik { get; set; }
        public string VlasnikIme { get; set; } = "";

        public int IdMesto { get; set; }
        public string MestoNaziv { get; set; } = "";

        public string Macke { get; set; } = ""; // npr. "Lav, Mia"

        [Browsable(false)] public string NazivTabele => "vw_PrijemniObrasci_Grid";
        [Browsable(false)] public string KoloneZaInsert => "";
        [Browsable(false)] public string UbaciVrednosti => "";

        public IDomenObjekat ReadRow(SqlDataReader r) => new PrijemniObrazacGrid
        {
            IdPrijemniObrazac = (int)r["idPrijemniObrazac"],
            Datum = (DateTime)r["datum"],
            IdRadnik = (int)r["idRadnik"],
            RadnikIme = r["RadnikIme"] as string ?? "",
            IdVlasnik = (int)r["idVlasnik"],
            VlasnikIme = r["VlasnikIme"] as string ?? "",
            IdMesto = (int)r["idMesto"],
            MestoNaziv = r["MestoNaziv"] as string ?? "",
            Macke = r["Macke"] as string ?? ""
        };
    }
}
