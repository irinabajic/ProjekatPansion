using Domen;
using Microsoft.Data.SqlClient;
using Server;
using System;

namespace DBBroker
{
    //sluzi samo za kreiranje konekcije
    public class Broker
    {
        private SqlConnection konekcija = new SqlConnection();
        private SqlTransaction transakcija;

        public SqlCommand NapraviKomandu() => new SqlCommand("", konekcija, transakcija);

        public void OtvoriKonekciju()
        {
            var cs = DbUrl.Current;                    // ← uvek čita aktuelan URL
            if (konekcija.ConnectionString != cs)
                konekcija.ConnectionString = cs;

            if (konekcija.State != System.Data.ConnectionState.Open)
                konekcija.Open();
        }

        public void ZatvoriKonekciju()
        {
            if (konekcija != null && konekcija.State != System.Data.ConnectionState.Closed)
                konekcija.Close();
        }

        public void ZapocniTransakciju() => transakcija = konekcija.BeginTransaction();
        public void Commit() => transakcija?.Commit();
        public void Rollback() => transakcija?.Rollback();

    }
}
