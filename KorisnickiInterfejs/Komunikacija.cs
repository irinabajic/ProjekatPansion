using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace KorisnickiInterfejs
{
    //na foru klijenta
    //samo prima i salje poruke
    public class Komunikacija
    {
        private static Komunikacija instance;
        private Socket socket;
        private Komunikacija() { }
        public static Komunikacija Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Komunikacija();
                }
                return instance;
            }
        }

        private KomunikacijaHelper helper;

        public bool PoveziSe()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("127.0.0.1", 9000);
                helper = new KomunikacijaHelper(socket);

                Debug.WriteLine("[CLIENT] Uspesno povezivanje sa serverom.");
                return true;
            }
            catch (Exception)
            {
                Debug.WriteLine("[CLIENT] Neuspesno povezivanje sa serverom.");
                return false;
            }
        }

        public void Posalji(object poruka)
        {
            if (helper == null) throw new InvalidOperationException("Pozovi Connect() pre slanja.");
            helper.Posalji(poruka);
        }

        public T Primi<T>()
        {
            if (helper == null) throw new InvalidOperationException("Pozovi Connect() pre prijema.");
            return helper.Primi<T>();
        }

        public T PosaljiZahtev<T>(Zahtev zahtev) where T : class
        {
            if (helper == null) throw new InvalidOperationException("Pozovi Connect() pre slanja.");
            helper.Posalji(zahtev);
            Odgovor odgovor = helper.Primi<Odgovor>();
            if (!odgovor.Signal) throw new Exception(odgovor.Poruka);

            // KLJUČNA LINIJA:
            return KomunikacijaHelper.ReadType<T>(odgovor.Objekat);
        }

        public T PosaljiZahtev<T>(Operacija operacija, object objekat = null) where T : class
        {
            if (helper == null) throw new InvalidOperationException("Pozovi Connect() pre slanja.");

            var zahtev = new Zahtev { Operacija = operacija, Objekat = objekat };
            helper.Posalji(zahtev);

            Odgovor odgovor;
            try
            {
                odgovor = helper.Primi<Odgovor>();  // ovde je do sada pucalo
            }
            catch (IOException ex)
            {
                throw new Exception("Server je prekinuo vezu. Pokušaj ponovo. " + ex.Message);
            }
            catch (SocketException ex)
            {
                throw new Exception("Veza sa serverom je prekinuta. " + ex.Message);
            }

            if (!odgovor.Signal)
                throw new Exception(odgovor.Poruka ?? "Operacija nije uspela.");

            // KLJUČNA LINIJA (ostaje kao i do sada):
            return KomunikacijaHelper.ReadType<T>(odgovor.Objekat);
        }

        public bool PosaljiZahtevSafe(Operacija operacija, object objekat, out string poruka)
        {
            poruka = null;
            if (helper == null) { poruka = "Nema konekcije."; return false; }

            var zahtev = new Zahtev { Operacija = operacija, Objekat = objekat };
            helper.Posalji(zahtev);

            var odgovor = helper.Primi<Odgovor>();
            if (!odgovor.Signal)
            {
                poruka = odgovor.Poruka ?? "Operacija nije uspela.";
                return false;
            }
            return true;
        }

        public bool PosaljiZahtevSafe<T>(Operacija operacija, object objekat, out T rezultat, out string poruka)
    where T : class
        {
            rezultat = null;
            poruka = null;

            if (helper == null) { poruka = "Nema konekcije."; return false; }

            var zahtev = new Zahtev { Operacija = operacija, Objekat = objekat };
            helper.Posalji(zahtev);

            Odgovor odgovor = helper.Primi<Odgovor>();
            if (!odgovor.Signal)
            {
                poruka = odgovor.Poruka ?? "Operacija nije uspela.";
                return false;
            }

            rezultat = KomunikacijaHelper.ReadType<T>(odgovor.Objekat);
            return true;
        }



        public void ZatvoriKonekciju()
        {
            try
            {
                if (helper != null)
                {
                    Zahtev zahtev = new Zahtev() { Operacija = Operacija.KrajKomunikacije };
                    helper.Posalji(zahtev); 
                }
                socket?.Shutdown(SocketShutdown.Both);
                socket?.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
