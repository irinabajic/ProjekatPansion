using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repozitorijum.DBRepozitorijum
{
    public interface IRepozitorijum<T> where T : class
    {
        //select * from korisnik where pass =...
        //select * from product where prod =...

        //select * from nazivTabele where uslov
        
        //select * from product join manufacturer on ... where...
        //select * from product where ...

        //select * from nazivTabele joinUslov uslov
        void Dodaj(T t);
        List<T> VratiSvi(T t);
        List<T> Pretrazi(T t, string kriterijum);
        void Obrisi(T t);
        int Izmeni(T t, string setClause, string whereClause);

        void OtvoriKonekciju();
        void ZatvoriKonekciju();
        void ZapocniTransakciju();
        void Commit();
        void Rollback();
    }
}
