using AplikacionaLogika;
using Domen;
using KorisnickiInterfejs.Session;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace Server
{
    public class ClientHandler
    {
        private Socket socket;
        private KomunikacijaHelper helper;
        List<ClientHandler> klijenti = new List<ClientHandler>();
        private volatile bool radi = true;

        public ClientHandler(Socket socket, List<ClientHandler> klijenti)
        {
            this.socket = socket;
            this.klijenti = klijenti;
            helper = new KomunikacijaHelper(socket);
        }

        public void HandleRequest()
        {
            try
            {
                while (true)
                {
                    Zahtev req = helper.Primi<Zahtev>();
                    switch (req.Operacija)
                    {
                        case Operacija.Login:
                            {
                                // telo dolazi kao Radnik 
                                var ulaz = KomunikacijaHelper.ReadType<Radnik>(req.Objekat);
                                var r = AplikacionaLogika.Kontroler.Instance.Login(ulaz.Username, ulaz.Password);
                                helper.Posalji(new Odgovor { Signal = true, Objekat = r });
                                break;
                            }

                        case Operacija.VratiSveRadnike:
                            {
                                var lista = AplikacionaLogika.Kontroler.Instance.VratiSveRadnike();
                                helper.Posalji(new Odgovor { Signal = true, Objekat = lista });
                                break;
                            }

                        case Operacija.KrajKomunikacije:
                            helper.Posalji(new Odgovor { Signal = true, Poruka = "Kraj" });
                            radi = false;
                            return;

                        default:
                            helper.Posalji(new Odgovor { Signal = false, Poruka = "Nepoznata operacija." });
                            break;
                    }
                }
            } 
            catch (Exception ex)
            {
                Debug.WriteLine("[SERVER] CH error: " + ex.Message);
            }
            finally
            {
                Close();
            }
        }

        public void Close()
        {
            try { helper?.Dispose(); } catch { }
            try { socket?.Shutdown(SocketShutdown.Both); } catch { }
            try { socket?.Dispose(); } catch { }
            klijenti.Remove(this);
        }
        public void Stop()
        {
            radi = false; // prekini while u HandleRequest

            // skini prijavljenog iz serverske sesije (ako koristiš sesiju na serveru)
            try { Session.Instance.Odjavi(); } catch { }

            // opcionalno obavesti klijenta da se veza gasi
            try { helper?.Posalji(new Odgovor { Signal = true, Poruka = "Kraj" }); } catch { }

            // zatvori mrežu
            try { helper?.Dispose(); } catch { }
            try { socket?.Shutdown(SocketShutdown.Both); } catch { }
            try { socket?.Dispose(); } catch { }

            // ukloni handler iz liste
            klijenti.Remove(this);
        }


        //private Odgovor KreirajOdgovor(Zahtev zahtev)
        //{
        //    Odgovor odgovor = new Odgovor();
        //    switch (zahtev.Operacija)
        //    {
        //        case Operacija.KreirajMacka:
        //            Kontroler.Instance.KreirajMacka((Macka)zahtev.Objekat);
        //            odgovor.Poruka = "Macka je uspesno kreirana.";
        //            break;
        //    }
        //}
    }
}

