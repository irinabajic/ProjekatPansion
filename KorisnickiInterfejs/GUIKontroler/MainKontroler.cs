using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace KorisnickiInterfejs.GUIKontroler
{
    public class MainKontroler
    {
        public void Init(FrmMain f)
        {
            var r = Session.Session.Instance.PrijavljeniRadnik;

            // levo: osnovni podaci
            f.LblImeIPrezime.Text = r?.Ime ?? "";
            f.LblEmail.Text = r?.Username ?? "";     // ako nemaš email kolonu
            f.LblTelefon.Text = r?.BrojTelefona ?? "";
        }

        public void UcitajKolege(FrmMain f)
        {
            // sa servera: svi radnici
            List<Radnik> svi = Komunikacija.Instance
                .PosaljiZahtev<List<Radnik>>(Operacija.VratiSveRadnike);

            // isključi prijavljenog iz liste
            var ja = Session.Session.Instance.PrijavljeniRadnik;
            var kolege = (ja == null) ? svi : svi.Where(x => x.IdRadnik != ja.IdRadnik).ToList();

            // desno: grid sa kolegama
            var dgv = f.DgvKolege; // vidi napomenu ispod
            dgv.ReadOnly = true;
            dgv.AutoGenerateColumns = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.DataSource = null;
            dgv.DataSource = kolege;

            SakrijKolone(dgv, "IdRadnik","Password", "Prijavljen", "NazivTabele", "UbaciVrednosti", "KoloneZaInsert");
        }

        private void SakrijKolone(DataGridView dgv, params string[] names)
        {
            foreach (var n in names)
                if (dgv.Columns.Contains(n))
                    dgv.Columns[n].Visible = false;
        }
    }
}
