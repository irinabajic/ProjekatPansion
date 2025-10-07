using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorisnickiInterfejs.Session
{
    public class Session
    {
        private static Session instance;
        private Session()
        {

        }
        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }
        public Radnik PrijavljeniRadnik { get; set; }

        public bool JePrijavljen => PrijavljeniRadnik != null;

        // Pozovi na logout / gašenje aplikacije
        public void Odjavi()
        {
            PrijavljeniRadnik = null;
        }

        //public Macka TrenutnaMacka { get; set; }
        //npr ako hocu da je prikazem na drugoj formi
        //uzmem je direktno iz sesije
    }
}
