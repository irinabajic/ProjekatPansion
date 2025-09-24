using Domen;
using Microsoft.Data.SqlClient;

namespace DBBroker
{
    //sluzi samo za kreiranje konekcije
    public class Broker
    {
        private SqlConnection konekcija;
        private SqlTransaction transakcija;

        public Broker()
        {
            konekcija = new SqlConnection(@"Data source=(localdb)\MSSQLLocalDB;Initial Catalog=PansionDB;Integrated Security=True; TrustServerCertificate=True;");
        }

        public SqlCommand NapraviKomandu()
        {
            SqlCommand komanda = new SqlCommand("", konekcija, transakcija);
            return komanda;
        }

        public void OtvoriKonekciju()
        {
            konekcija.Open();
        }

        public void ZatvoriKonekciju()
        {
            if(konekcija != null && konekcija.State != System.Data.ConnectionState.Closed)
            {
                konekcija.Close();
            }
        }

        public void ZapocniTransakciju()
        {
            transakcija = konekcija.BeginTransaction();
        }
        public void Commit()
        {
            transakcija.Commit();
        }

        public void Rollback()
        {
            transakcija.Rollback();
        }    
      
    }
}
