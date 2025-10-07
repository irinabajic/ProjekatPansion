using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Dodatno
{
    // STAVKE
    [Serializable]
    public class StavkaPrijemnogView : IDomenObjekat
    {
        public int IdPrijemniObrazac { get; set; }
        public int Rb { get; set; }
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
            StavkaOpis = r["StavkaOpis"] as string ?? "",
            IdMacka = (int)r["idMacka"],
            MackaNaziv = r["MackaNaziv"] as string ?? "",
            MackaRasa = r["MackaRasa"] as string ?? "",
            MackaNapomene = r["MackaNapomene"] as string ?? ""
        };
    }
}
