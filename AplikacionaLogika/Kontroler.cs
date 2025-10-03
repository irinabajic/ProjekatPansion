using Domen;
using Domen.Dodatno;
using SistemskeOperacije;

namespace AplikacionaLogika
{
    public class Kontroler
    {
        private static Kontroler instance;
        public static Kontroler Instance => instance ??= new Kontroler();
        private Kontroler() { }

        //Radnik
        public void RegistrujRadnika(Radnik r)
        {
            var so = new RegistrujRadnikaSO(r);
            so.IzvrsiTemplejt();
        }

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

        public int DodajRadnika(Radnik r)
        { var so = new DodajRadnikaSO(r); so.IzvrsiTemplejt(); return so.NoviId; }

        public void IzmeniRadnika(Radnik r)
        { var so = new IzmeniRadnikaSO(r); so.IzvrsiTemplejt(); }

        public void ObrisiRadnika(int id)
        { var so = new ObrisiRadnikaSO(id); so.IzvrsiTemplejt(); }

        public void PromeniLozinkuRadnika(int id, string nova)
        { var so = new PromeniLozinkuRadnikaSO(id, nova); so.IzvrsiTemplejt(); }

        public void PromeniLozinkuSaVerifikacijom(int id, string stara, string nova)
        {
            var so = new PromeniLozinkuSaVerifikacijomSO(id, stara, nova);
            so.IzvrsiTemplejt();
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

        public void IzmeniPrijemni(Domen.Dodatno.PrijemniUpdateDTO cmd)
        {
            var so = new IzmeniPrijemniObrazacSO(cmd);
            so.IzvrsiTemplejt();
        }

        public void IzmeniPrijemniObrazac(PrijemniObrazac p)
        { var so = new IzmeniPrijemniObrazacSO(p); so.IzvrsiTemplejt(); }

        public void ObrisiPrijemniObrazac(int id)
        { var so = new ObrisiPrijemniObrazacSO(id); so.IzvrsiTemplejt(); }

        public List<PrijemniObrazac> PretraziPrijemneObrasce(string k)
        { var so = new PretraziPrijemneObrasceSO(k); so.IzvrsiTemplejt(); return so.Rez; }

        //Prijemni obrazac grid

        public List<PrijemniObrazacGrid> VratiSvePrijemneObrasceGrid()
        {
            var so = new VratiSvePrijemneObrasceGridSO(); so.IzvrsiTemplejt(); return so.Rez;
        }
        public List<PrijemniObrazacGrid> PretraziPrijemneObrasceGrid(string k)
        {
            var so = new PretraziPrijemneObrasceGridSO(k); so.IzvrsiTemplejt(); return so.Rez;
        }

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

        //RSS
        public List<RSSView> VratiMojeRSS(int idRadnik)
        {
            var so = new VratiMojeRSSSO(idRadnik);
            so.IzvrsiTemplejt();
            return so.Rez;
        }

        public void DodajRSS(RSS rss)
        {
            var so = new DodajRSSSO(rss);
            so.IzvrsiTemplejt();
        }

        public void IzmeniRSS(RSS rss)
        {
            var so = new IzmeniRSSSO(rss);
            so.IzvrsiTemplejt();
        }

        public void ObrisiRSS(RSS rss)
        {
            var so = new ObrisiRSSSO(rss);
            so.IzvrsiTemplejt();
        }

        //Mesto
        public List<Mesto> VratiSvaMesta()
        {
            var so = new VratiSvaMestaSO();
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
