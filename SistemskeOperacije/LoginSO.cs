using Domen;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class LoginSO : OpstaSO
    {
        private readonly string username;
        private readonly string password;
        public Radnik Rez {  get; private set; }

        public LoginSO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        protected override void Izvrsi()
        {
            string Esc(string s) => (s ?? "").Replace("'", "''");

            var lista = repozitorijum.Pretrazi(new Radnik(),
                          $"username = '{Esc(username)}' AND password = '{Esc(password)}'");

            var r = lista.OfType<Radnik>().FirstOrDefault();
            if (r == null) throw new Exception("Neispravni kredencijali.");
            if (r.Prijavljen) throw new Exception("Radnik je već prijavljen.");

            // označi kao prijavljen u bazi
            repozitorijum.Izmeni(new Radnik(), "prijavljen = 1", $"idRadnik = {r.IdRadnik}");

            r.Prijavljen = true;
            Rez = r;
        }
    }
}
