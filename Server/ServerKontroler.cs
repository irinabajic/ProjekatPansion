using DBBroker;
using Domen;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public sealed class ServerKontroler
    {
        private static readonly ServerKontroler _i = new ServerKontroler();
        public static ServerKontroler Instance => _i;

        private readonly Broker broker = new Broker();

        public BindingList<Radnik> VratiSviPrijavljeniRadnik()
        {
            var so = new VratiSviPrijavljeniRadnikSO(); // SO: SELECT * FROM Radnik WHERE prijavljen=1
            so.IzvrsiTemplejt();
            return new BindingList<Radnik>(so.Rez.ToList());
        }
    }
}
