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
            
        }
    }
}
