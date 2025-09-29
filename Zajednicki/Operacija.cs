namespace Zajednicki
{
    public enum Operacija
    {
        Login,

        //Radnik 
        IzmeniRadnika,
        RegistrujRadnika,
        VratiSveRadnike,
        DodajRadnika,
        ObrisiRadnika,
        PromeniLozinkuRadnika,
        PromeniLozinkuSaVerifikacijom,

        // Macka CRUD
        VratiSveMacke,
        DodajMacku,
        IzmeniMacku,
        ObrisiMacku,
        PretraziMacke,

        // Vlasnik CRUD
        VratiSveVlasnike,
        DodajVlasnika,
        IzmeniVlasnika,
        ObrisiVlasnika,
        PretraziVlasnike,

        // Prijemni obrazac CRUD
        VratiSvePrijemneObrasce,
        DodajPrijemniObrazac,
        IzmeniPrijemniObrazac,
        ObrisiPrijemniObrazac,
        PretraziPrijemneObrasce,

        // Prijemni obrazac grid
        VratiSvePrijemneObrasceGrid,
        PretraziPrijemneObrasceGrid,

        //Strucna sprema CRUD
        VratiSveStrucneSpreme,
        DodajStrucnuSpremu,
        IzmeniStrucnuSpremu,
        ObrisiStrucnuSpremu,
        PretraziStrucneSpreme,

        //Detalji prijemnog
        VratiDetaljePrijemnogObrasca,

        //RSS
        VratiMojeRSS,
        DodajRSS,
        IzmeniRSS,
        ObrisiRSS,

        //Mesto
        VratiSvaMesta,

        //Stavke obrasca
        DodajStavkuObrasca,
        ObrisiStavkuObrasca,



        Logout,
        KrajKomunikacije
    }
}
