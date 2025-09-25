using Domen;
using SistemskeOperacije;

namespace AplikacionaLogika
{
    public class Kontroler
    {
        private static Kontroler instance;
        public static Kontroler Instance => instance ??= new Kontroler();
        private Kontroler() { }

        public Radnik Login(string username, string password)
        {
            var so = new LoginSO(username, password);
            so.IzvrsiTemplejt();
            return so.Rez;
        }

        public List<Radnik> VratiSveRadnike()
        {
            var so = new VratiSveRadnikeSO();
            so.IzvrsiTemplejt();
            return so.Rez;
        }

        //Macka

        public List<Macka> VratiSveMacke()
        {
            var so = new VratiSveMackeSO(); so.IzvrsiTemplejt(); return so.Rez;
        }
        public int DodajMacku(Macka m)
        {
            var so = new DodajMackuSO(m); so.IzvrsiTemplejt(); return so.NoviId;
        }
        public void IzmeniMacku(Macka m)
        {
            var so = new IzmeniMackuSO(m); so.IzvrsiTemplejt();
        }
        public void ObrisiMacku(int idMacka)
        {
            var so = new ObrisiMackuSO(idMacka); so.IzvrsiTemplejt();
        }
        public List<Macka> PretraziMacke(string kriterijum)
        {
            var so = new PretraziMackeSO(kriterijum); so.IzvrsiTemplejt(); return so.Rez;
        }

        //Vlasnik

        public List<Vlasnik> VratiSveVlasnike()
        {
            var so = new VratiSveVlasnikeSO(); so.IzvrsiTemplejt(); return so.Rez;
        }
        public int DodajVlasnika(Vlasnik v)
        {
            var so = new DodajVlasnikaSO(v); so.IzvrsiTemplejt(); return so.NoviId;
        }
        public void IzmeniVlasnika(Vlasnik v)
        {
            var so = new IzmeniVlasnikaSO(v); so.IzvrsiTemplejt();
        }
        public void ObrisiVlasnika(int idVlasnik)
        {
            var so = new ObrisiVlasnikaSO(idVlasnik); so.IzvrsiTemplejt();
        }
        public List<Vlasnik> PretraziVlasnike(string kriterijum)
        {
            var so = new PretraziVlasnikeSO(kriterijum); so.IzvrsiTemplejt(); return so.Rez;
        }



        public void Logout(int idRadnik)
        {
            var so = new OdjaviRadnikaSO(idRadnik);
            so.IzvrsiTemplejt();
        }

        public void OdjaviSve()
        {
            var so = new OdjaviSveRadnikeSO();
            so.IzvrsiTemplejt();
        }
    }
}
