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

        //Radnik

        public void IzmeniRadnika(Radnik r)
        {
            var so = new IzmeniRadnikaSO(r); so.IzvrsiTemplejt();
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

        //Prijemni obrazac
        public List<PrijemniObrazac> VratiSvePrijemneObrasce()
        { var so = new VratiSvePrijemneObrasceSO(); so.IzvrsiTemplejt(); return so.Rez; }

        public int DodajPrijemniObrazac(PrijemniObrazac p)
        { var so = new DodajPrijemniObrazacSO(p); so.IzvrsiTemplejt(); return so.NoviId; }

        public void IzmeniPrijemniObrazac(PrijemniObrazac p)
        { var so = new IzmeniPrijemniObrazacSO(p); so.IzvrsiTemplejt(); }

        public void ObrisiPrijemniObrazac(int id)
        { var so = new ObrisiPrijemniObrazacSO(id); so.IzvrsiTemplejt(); }

        public List<PrijemniObrazac> PretraziPrijemneObrasce(string k)
        { var so = new PretraziPrijemneObrasceSO(k); so.IzvrsiTemplejt(); return so.Rez; }

        //Strucna sprema
        public List<StrucnaSprema> VratiSveStrucneSpreme()
        {
            var so = new VratiSveStrucneSpremeSO(); so.IzvrsiTemplejt(); return so.Rez;
        }
        public int DodajStrucnuSpremu(StrucnaSprema s)
        {
            var so = new DodajStrucnuSpremuSO(s); so.IzvrsiTemplejt(); return so.NoviId;
        }
        public void IzmeniStrucnuSpremu(StrucnaSprema s)
        {
            var so = new IzmeniStrucnuSpremuSO(s); so.IzvrsiTemplejt();
        }
        public void ObrisiStrucnuSpremu(int id)
        {
            var so = new ObrisiStrucnuSpremuSO(id); so.IzvrsiTemplejt();
        }
        public List<StrucnaSprema> PretraziStrucneSpreme(string kriterijum)
        {
            var so = new PretraziStrucneSpremeSO(kriterijum); so.IzvrsiTemplejt(); return so.Rez;
        }

        //Detalji prijemnog

        public PrijemniDetaljiDTO VratiDetaljePrijemnogObrasca(int id)
        {
            var so = new VratiDetaljePrijemnogObrascaSO(id);
            so.IzvrsiTemplejt();
            return so.Rez;
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
