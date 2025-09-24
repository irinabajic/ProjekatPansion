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
    }
}
