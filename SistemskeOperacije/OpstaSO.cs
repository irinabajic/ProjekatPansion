using Domen;
using Repozitorijum.DBRepozitorijum;
using Repozitorijum.GenerickiRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public abstract class OpstaSO
    {
        protected IRepozitorijum<IDomenObjekat> repozitorijum = new GenerickiDBRepozitorijum();
    
        public void IzvrsiTemplejt()
        {
            try
            {
                repozitorijum.OtvoriKonekciju();
                repozitorijum.ZapocniTransakciju();
                Izvrsi();
                repozitorijum.Commit();
            }
            catch (Exception ex)
            {
                repozitorijum.Rollback();
                throw;
            }
            finally
            {
                repozitorijum.ZatvoriKonekciju();
            }
        }

        protected abstract void Izvrsi();
    }
}
