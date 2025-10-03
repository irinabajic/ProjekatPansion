using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Dodatno
{
    [Serializable]
    public class PrijemniUpdateDTO
    {
        public int IdPrijemniObrazac { get; set; }

        // opcioni patch headera (ako nekad zatreba)
        public DateTime? Datum { get; set; }
        public int? IdRadnik { get; set; }
        public int? IdVlasnik { get; set; }

        // komande za stavke (OVO je poenta)
        public List<StavkaObrasca> StavkeZaDodavanje { get; set; } = new();
        public List<int> RedniBrojeviZaBrisanje { get; set; } = new();
    }
}
