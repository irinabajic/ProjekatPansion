using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Dodatno
{
    [Serializable]
    public class PrijemniDetaljiDTO
    {
        public PrijemniObrazacView Header { get; set; } = new();
        public List<StavkaPrijemnogView> Stavke { get; set; } = new();
    }
}
