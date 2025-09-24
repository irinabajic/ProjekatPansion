using Domen;
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
        public event EventHandler OdjavljeniKlijent;
        List<ClientHandler> klijenti = new List<ClientHandler>();

        public ClientHandler(Socket socket, List<ClientHandler> klijenti)
        {
            this.socket = socket;
            this.klijenti = klijenti;
            helper = new KomunikacijaHelper(socket);
        }

        public void HandleRequest()
        {
            //try
            //{
            //    Zahtev zahtev;
            //    while ((zahtev != helper.Primi<Zahtev>()).Operacija != OperationCanceledException.KrajKomunikacije)
            //    {
            //        Odgovor odgovor;
            //        try
            //        {
            //            odgovor = KreirajOdgovor(zahtev);
            //        }
            //        catch (Exception ex)
            //        {
            //            odgovor = new Odgovor();
            //            odgovor.Poruka = ex.Message;
            //            odgovor.Signal = false;
            //        }
            //        helper.Posalji(odgovor);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(">>>" + ex.Message);
            }
            //finally
            //{
            //    Stop();
            //    OdjavljeniKlijent?.Invoke(this, EventArgs.Empty);   
            //}
        }


        //public void Stop()
        //{
        //    if (socket != null)
        //    {
        //        socket.Shutdown(SocketShutdown.Both);
        //        socket.Dispose();
        //        socket = null;
        //    }
        //}

        //public void Close()
        //{
        //    try { helper?.Dispose(); } catch { }
        //    try { socket?.Shutdown(SocketShutdown.Both); } catch { }
        //    try { socket?.Dispose(); } catch { }
        //    klijenti.Remove(this);
        //}

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

