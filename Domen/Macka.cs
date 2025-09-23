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
        public int MackaId { get; set; }
        public string Ime { get; set; }

        //ostali property za macku
        public string NazivTabele => "Macka";

        public string UbaciVrednosti => $"{MackaId},'{Ime}', i ostali property";
        public override string ToString()
        {
            return Ime;
        }
    }

    
}
