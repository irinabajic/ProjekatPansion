using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    //Read-only domen za poglede
    [Serializable]
    public class PrijemniObrazacView : IDomenObjekat
    {
        public int IdPrijemniObrazac { get; set; }
        public DateTime Datum { get; set; }

        public int IdRadnik { get; set; }
        public string RadnikIme { get; set; } = "";
        public string RadnikUsername { get; set; } = "";
        public string RadnikTelefon { get; set; } = "";

        public int IdVlasnik { get; set; }
        public string VlasnikIme { get; set; } = "";
        public string VlasnikAdresa { get; set; } = "";
        public string VlasnikEmail { get; set; } = "";
        public string VlasnikTelefon { get; set; } = "";
        public string VlasnikMesto { get; set; } = "";

        [Browsable(false)] public string NazivTabele => "vw_PrijemniObrazac_Detalj";
        [Browsable(false)] public string KoloneZaInsert => "";
        [Browsable(false)] public string UbaciVrednosti => "";

        public IDomenObjekat ReadRow(SqlDataReader r) => new PrijemniObrazacView
        {
            IdPrijemniObrazac = (int)r["idPrijemniObrazac"],
            Datum = (DateTime)r["datum"],
            IdRadnik = (int)r["idRadnik"],
            RadnikIme = r["RadnikIme"] as string ?? "",
            RadnikUsername = r["RadnikUsername"] as string ?? "",
            RadnikTelefon = r["RadnikTelefon"] as string ?? "",
            IdVlasnik = (int)r["idVlasnik"],
            VlasnikIme = r["VlasnikIme"] as string ?? "",
            VlasnikAdresa = r["VlasnikAdresa"] as string ?? "",
            VlasnikEmail = r["VlasnikEmail"] as string ?? "",
            VlasnikTelefon = r["VlasnikTelefon"] as string ?? "",
            VlasnikMesto = r["VlasnikMesto"] as string ?? ""
        };
    }

    // STAVKE
    [Serializable]
    public class StavkaPrijemnogView : IDomenObjekat
    {
        public int IdPrijemniObrazac { get; set; }
        public int Rb { get; set; }
        public string StavkaNaziv { get; set; } = "";
        public string StavkaOpis { get; set; } = "";
        public int IdMacka { get; set; }
        public string MackaNaziv { get; set; } = "";
        public string MackaRasa { get; set; } = "";
        public string MackaNapomene { get; set; } = "";

        [Browsable(false)] public string NazivTabele => "vw_StavkaPrijemnog_Detalj";
        [Browsable(false)] public string KoloneZaInsert => "";
        [Browsable(false)] public string UbaciVrednosti => "";

        public IDomenObjekat ReadRow(SqlDataReader r) => new StavkaPrijemnogView
        {
            IdPrijemniObrazac = (int)r["idPrijemniObrazac"],
            Rb = (int)r["rb"],
            StavkaNaziv = r["StavkaNaziv"] as string ?? "",
            StavkaOpis = r["StavkaOpis"] as string ?? "",
            IdMacka = (int)r["idMacka"],
            MackaNaziv = r["MackaNaziv"] as string ?? "",
            MackaRasa = r["MackaRasa"] as string ?? "",
            MackaNapomene = r["MackaNapomene"] as string ?? ""
        };
    }
}
