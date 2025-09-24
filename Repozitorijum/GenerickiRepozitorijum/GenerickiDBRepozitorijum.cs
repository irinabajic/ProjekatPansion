using DBBroker;
using Domen;
using Microsoft.Data.SqlClient;
using Repozitorijum.DBRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repozitorijum.GenerickiRepozitorijum
{
    //sloj izmedju SO i brokera

    public class GenerickiDBRepozitorijum : IRepozitorijum<IDomenObjekat>
    {
        private Broker broker = new Broker();

        public void Dodaj(IDomenObjekat obj)
        {
            SqlCommand komanda = broker.NapraviKomandu();
            komanda.CommandText = $"insert into {obj.NazivTabele} values ({obj.UbaciVrednosti})";
            komanda.ExecuteNonQuery();
        }

        public void Obrisi(IDomenObjekat obj) 
        {
            throw new NotImplementedException();
        }

        public List<IDomenObjekat> VratiSvi(IDomenObjekat obj)
        {
            List<IDomenObjekat> rez = new List<IDomenObjekat> ();
            SqlCommand komanda = broker.NapraviKomandu();
            komanda.CommandText = $"select * from {obj.NazivTabele}";
            SqlDataReader reader = komanda.ExecuteReader();
            while (reader.Read())
            {
                rez.Add(obj.ReadRow(reader));
            }
            reader.Close();
            return rez;
        }

        public void Login(string username, string password)
        {

        }

        public List<IDomenObjekat> Pretrazi(IDomenObjekat obj, string kriterijum)
        {
            List<IDomenObjekat> rez = new List<IDomenObjekat>();
            SqlCommand komanda = broker.NapraviKomandu();
            komanda.CommandText = string.IsNullOrWhiteSpace(kriterijum)
                ? $"SELECT * FROM {obj.NazivTabele}"
                : $"SELECT * FROM {obj.NazivTabele} WHERE {kriterijum}";

            SqlDataReader reader = komanda.ExecuteReader();
            while (reader.Read())
            {
                rez.Add(obj.ReadRow(reader));
            }
            reader.Close();
            return rez;
        }

        public int Izmeni(IDomenObjekat t, string setClause, string whereClause)
        {
            SqlCommand komanda = broker.NapraviKomandu();
            komanda.CommandText = $"UPDATE {t.NazivTabele} SET {setClause} WHERE {whereClause}";
            return komanda.ExecuteNonQuery();
        }
        public void OtvoriKonekciju()
        {
            broker.OtvoriKonekciju();
        }

        public void ZatvoriKonekciju()
        {
            broker.ZatvoriKonekciju();
        }

        public void ZapocniTransakciju()
        {
            broker.ZapocniTransakciju();
        }

        public void Commit()
        {
            broker.Commit();
        }

        public void Rollback()
        {
            broker.Rollback();
        }

    }
}
