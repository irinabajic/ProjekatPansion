namespace Zajednicki
{
    public enum Operacija
    {
        Login,
        VratiSveRadnike,

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

        //Strucna sprema CRUD
        VratiSveStrucneSpreme,
        DodajStrucnuSpremu,
        IzmeniStrucnuSpremu,
        ObrisiStrucnuSpremu,
        PretraziStrucneSpreme,

        Logout,
        KrajKomunikacije
    }
}
