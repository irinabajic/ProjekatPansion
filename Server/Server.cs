using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket socket;
        private readonly List<ClientHandler> klijenti = new();

        public void Pokreni()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000)); 
            socket.Listen(50);
            Debug.WriteLine("[SERVER] Server slusa na 9000");
        }

        public void Accept()
        {
            try
            {
                while (true)
                {
                    Debug.WriteLine("[SERVER] Čekam klijenta...");
                    var klSock = socket.Accept();
                    Debug.WriteLine("[SERVER] Klijent povezan.");

                    var ch = new ClientHandler(klSock, klijenti);
                    klijenti.Add(ch);

                    var t = new Thread(ch.HandleRequest) { IsBackground = true };
                    t.Start();
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("[SERVER] Accept stop: " + ex.Message);
            }
        }

        public void Stop()
        {
            //foreach (var ch in klijenti) ch.Close();
            klijenti.Clear();
            try { socket?.Close(); } catch { }
            socket = null;
        }
    }
}
