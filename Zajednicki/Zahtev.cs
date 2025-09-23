using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{
    public class Zahtev
    {
        public object Objekat { get; }
        public Operacija Operacija { get; set; }
        public Zahtev(Operacija operacija, object objekat)
        {
            Operacija = operacija;
            Objekat = objekat;
        }
    }
}
