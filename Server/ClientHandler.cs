using AplikacionaLogika;
using Domen;
using KorisnickiInterfejs.Session;
using Microsoft.Data.SqlClient;
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

                        //Macka
                        case Operacija.VratiSveMacke:
                            {
                                var lista = AplikacionaLogika.Kontroler.Instance.VratiSveMacke();
                                helper.Posalji(new Odgovor { Signal = true, Objekat = lista });
                                break;
                            }
                        case Operacija.DodajMacku:
                            {
                                var m = KomunikacijaHelper.ReadType<Macka>(req.Objekat);
                                int id = AplikacionaLogika.Kontroler.Instance.DodajMacku(m);
                                helper.Posalji(new Odgovor { Signal = true, Objekat = id });
                                break;
                            }
                        case Operacija.IzmeniMacku:
                            {
                                try
                                {
                                    var m = KomunikacijaHelper.ReadType<Domen.Macka>(req.Objekat);
                                    if (string.IsNullOrWhiteSpace(m.Naziv) ||
                                        string.IsNullOrWhiteSpace(m.Rasa) ||
                                        string.IsNullOrWhiteSpace(m.Napomene))
                                        throw new Exception("Sva polja su obavezna.");

                                    AplikacionaLogika.Kontroler.Instance.IzmeniMacku(m);
                                    helper.Posalji(new Odgovor { Signal = true, Poruka = "Sačuvano." });
                                }
                                catch (Exception ex)
                                {
                                    helper.Posalji(new Odgovor { Signal = false, Poruka = ex.Message });
                                }
                                break;
                            }
                        case Operacija.ObrisiMacku:
                            {
                                int id = KomunikacijaHelper.ReadType<int>(req.Objekat);
                                AplikacionaLogika.Kontroler.Instance.ObrisiMacku(id);
                                helper.Posalji(new Odgovor { Signal = true, Poruka = "OK" });
                                break;
                            }
                        
                        case Operacija.PretraziMacke:
                            {
                                string kriterijum = KomunikacijaHelper.ReadType<string>(req.Objekat);
                                var lista = AplikacionaLogika.Kontroler.Instance.PretraziMacke(kriterijum);
                                helper.Posalji(new Odgovor { Signal = true, Objekat = lista });
                                break;
                            }

                        //Vlasnik
                        // Vlasnik
                        case Operacija.VratiSveVlasnike:
                            {
                                var lista = AplikacionaLogika.Kontroler.Instance.VratiSveVlasnike();
                                helper.Posalji(new Odgovor { Signal = true, Objekat = lista });
                                break;
                            }
                        case Operacija.DodajVlasnika:
                            {
                                var v = KomunikacijaHelper.ReadType<Domen.Vlasnik>(req.Objekat);
                                // osnovna validacija
                                if (string.IsNullOrWhiteSpace(v.Ime) ||
                                    string.IsNullOrWhiteSpace(v.BrojTelefona) ||
                                    string.IsNullOrWhiteSpace(v.Adresa) ||
                                    string.IsNullOrWhiteSpace(v.Email) ||
                                    v.IdMesto <= 0)
                                {
                                    helper.Posalji(new Odgovor { Signal = false, Poruka = "Sva polja su obavezna (IdMesto > 0)." });
                                    break;
                                }

                                int id = AplikacionaLogika.Kontroler.Instance.DodajVlasnika(v);
                                helper.Posalji(new Odgovor { Signal = true, Objekat = id });
                                break;
                            }
                        case Operacija.IzmeniVlasnika:
                            {
                                try
                                {
                                    var v = KomunikacijaHelper.ReadType<Domen.Vlasnik>(req.Objekat);

                                    if (v.IdVlasnik <= 0 ||
                                        string.IsNullOrWhiteSpace(v.Ime) ||
                                        string.IsNullOrWhiteSpace(v.BrojTelefona) ||
                                        string.IsNullOrWhiteSpace(v.Adresa) ||
                                        string.IsNullOrWhiteSpace(v.Email) ||
                                        v.IdMesto <= 0)
                                        throw new Exception("Sva polja su obavezna (Id i IdMesto moraju biti > 0).");

                                    AplikacionaLogika.Kontroler.Instance.IzmeniVlasnika(v);
                                    helper.Posalji(new Odgovor { Signal = true, Poruka = "Sačuvano." });
                                }
                                catch (Exception ex)
                                {
                                    helper.Posalji(new Odgovor { Signal = false, Poruka = ex.Message });
                                }
                                break;
                            }
                        case Operacija.ObrisiVlasnika:
                            {
                                int id = KomunikacijaHelper.ReadType<int>(req.Objekat);
                                AplikacionaLogika.Kontroler.Instance.ObrisiVlasnika(id);
                                helper.Posalji(new Odgovor { Signal = true, Poruka = "OK" });
                                break;
                            }
                        case Operacija.PretraziVlasnike:
                            {
                                string kriterijum = KomunikacijaHelper.ReadType<string>(req.Objekat);
                                var lista = AplikacionaLogika.Kontroler.Instance.PretraziVlasnike(kriterijum);
                                helper.Posalji(new Odgovor { Signal = true, Objekat = lista });
                                break;
                            }



                        case Operacija.Logout:
                            {
                                int id = KomunikacijaHelper.ReadType<int>(req.Objekat);
                                AplikacionaLogika.Kontroler.Instance.Logout(id);
                                helper.Posalji(new Odgovor { Signal = true, Poruka = "OK" });
                                // ako želiš da zatvoriš vezu posle logout-a:
                                // radi = false; return;
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
            catch (SqlException)
            {
                helper.Posalji(new Odgovor { Signal = false, Poruka = "Mačka je vezana za prijemni obrazac." });
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

