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
        //private CommunicationHelper helper;
        public event EventHandler OdjavljeniKlijent;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            //helper = new CommunicationHelper(socket);
        }

        public void HandleRequest()
        {
            try
            {
                //Zahtev zahtev;
                //while ((zahtev != helper.Primi<Zahtev>()).Operation != OperationCanceledException.KrajKomunikacije)
                //{
                //    Odgovor odgovor;
                //    try
                //    {
                //        odgovor = KreirajOdgovor(zahtev);
                //    }
                //    catch (Exception ex)
                //    {
                //        odgovor = new Odgovor();
                //        odgovor.Poruka = ex.Message;
                //        odgovor.Signal = false;
                //    }
                //    helper.Posalji(odgovor);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
            finally
            {
                Stop();
                OdjavljeniKlijent?.Invoke(this, EventArgs.Empty);   
            }
        }


        internal void Stop()
        {
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Dispose();
                socket = null;
            }
        }
        //private Odgovor KreirajOdgovor(Zahtev zahtev)
        //{
        //    Odgovor odgovor = new Odgovor();
        //    switch (zahtev.Operacija)
        //    {
        //        case Operacija.KreirajMacka:
        //            Kontroler.Instance.KreirajMacka((Macka)zahtev.ZahtevObjekat);
        //            odgovor.Poruka = "Macka je uspesno kreirana.";
        //            break;
        //    }
        //}


    }
}
