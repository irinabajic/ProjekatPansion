using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace KorisnickiInterfejs.GUIKontroler
{
    //prihvata graficke objekte, pretvara ih u domenske
    //i poziva odgovarajucu SO
    public class LoginKontroler
    {
        internal void Login(FrmLogin login)
        {
            string username = login.TxtUsername.Text;
            string password = login.TxtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                login.TxtUsername.BackColor = Color.Salmon;
                login.TxtPassword.BackColor = Color.Salmon;
                return;
            }

            Radnik radnik = new Radnik()
            {
                Username = username,
                Password = password
            };

            try
            {
                Komunikacija.Instance.PoveziSe();
                radnik = Komunikacija.Instance.PosaljiZahtev<Radnik>(Operacija.Login, radnik);
                Session.Session.Instance.PrijavljeniRadnik = radnik;
                MessageBox.Show($"Welcome, {radnik.Ime}!");
                login.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
