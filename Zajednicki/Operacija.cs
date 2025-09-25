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

        Logout,
        KrajKomunikacije
    }
}
