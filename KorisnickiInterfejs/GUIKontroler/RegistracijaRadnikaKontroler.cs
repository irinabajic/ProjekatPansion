using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace KorisnickiInterfejs.GUIKontroler
{
    public class RegistracijaRadnikaKontroler
    {
        public void Registruj(FrmRegistracijaRadnika f)
        {
            var ime = f.TxtIme.Text?.Trim() ?? "";
            var telefon = f.TxtTelefon.Text?.Trim() ?? "";
            var user = f.TxtUsername.Text?.Trim() ?? "";
            var pass = f.TxtPassword.Text;
            var potvrda = f.TxtPotvrda.Text;

            if (string.IsNullOrWhiteSpace(ime) ||
                string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(pass) ||
                string.IsNullOrWhiteSpace(potvrda))
            {
                MessageBox.Show("Sva polja osim telefona su obavezna.");
                return;
            }
            if (pass != potvrda)
            {
                MessageBox.Show("Lozinka i potvrda se ne poklapaju.");
                return;
            }
            if (user.Length < 3) { MessageBox.Show("Korisničko ime mora imati bar 3 znaka."); return; }
            if (pass.Length < 4) { MessageBox.Show("Lozinka mora imati bar 4 znaka."); return; }

            var r = new Radnik
            {
                Ime = ime,
                BrojTelefona = telefon,
                Username = user,
                Password = pass,
                Prijavljen = false
            };

            // poziv serveru
            var resp = Komunikacija.Instance.PosaljiZahtev<object>(Operacija.RegistrujRadnika, r);
            MessageBox.Show("Registracija uspešna.");
            f.DialogResult = DialogResult.OK;
        }
    }
}
