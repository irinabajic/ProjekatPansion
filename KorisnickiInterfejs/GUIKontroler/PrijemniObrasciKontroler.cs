using Domen;
using Domen.Dodatno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace KorisnickiInterfejs.GUIKontroler
{
    public class PrijemniObrasciKontroler
    {
        public void Osvezi(FrmPrijemniObrasci f)
        {
            var lista = Komunikacija.Instance
                 .PosaljiZahtev<System.Collections.Generic.List<PrijemniObrazacGrid>>(
                     Operacija.VratiSvePrijemneObrasceGrid)
                 ?? new System.Collections.Generic.List<PrijemniObrazacGrid>();

            f.DgvPrijemniObrasci.AutoGenerateColumns = true;
            f.DgvPrijemniObrasci.Columns.Clear();
            f.DgvPrijemniObrasci.ReadOnly = true;
            f.DgvPrijemniObrasci.MultiSelect = false;
            f.DgvPrijemniObrasci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            f.DgvPrijemniObrasci.DataSource = new BindingList<PrijemniObrazacGrid>(lista);

            SakrijKolone(f.DgvPrijemniObrasci);
            PostaviNasloveKolona(f.DgvPrijemniObrasci);
            SelektujPrviRedAkoPostoji(f.DgvPrijemniObrasci);
        }

        public void PretraziGrid(FrmPrijemniObrasci f)
        {
            var k = f.TxtPretraga.Text?.Trim() ?? "";
            var lista = Komunikacija.Instance
                .PosaljiZahtev<System.Collections.Generic.List<PrijemniObrazacGrid>>(
                    Operacija.PretraziPrijemneObrasceGrid, k)
                ?? new System.Collections.Generic.List<PrijemniObrazacGrid>();

            f.DgvPrijemniObrasci.DataSource = new BindingList<PrijemniObrazacGrid>(lista);
            SakrijKolone(f.DgvPrijemniObrasci);
            PostaviNasloveKolona(f.DgvPrijemniObrasci);
            SelektujPrviRedAkoPostoji(f.DgvPrijemniObrasci);
        }

        private void SakrijKolone(DataGridView dgv)
        {
            foreach (var c in new[]
            {
        "NazivTabele","KoloneZaInsert","UbaciVrednosti",
        "IdPrijemniObrazac",   // ne prikazujemo ga
        "IdMesto","IdVlasnik","IdRadnik"  // sakrij tražene ID-jeve
             })
                if (dgv.Columns.Contains(c)) dgv.Columns[c].Visible = false;
        }

        private void PostaviNasloveKolona(DataGridView dgv)
        {
            void H(string name, string header) { if (dgv.Columns.Contains(name)) dgv.Columns[name].HeaderText = header; }
            H(nameof(PrijemniObrazacGrid.Datum), "Datum");
            H(nameof(PrijemniObrazacGrid.MestoNaziv), "Mesto");
            H(nameof(PrijemniObrazacGrid.VlasnikIme), "Vlasnik");
            H(nameof(PrijemniObrazacGrid.RadnikIme), "Radnik");
            H(nameof(PrijemniObrazacGrid.Macke), "Mačke");
        }

        private static void SelektujPrviRedAkoPostoji(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                int firstVisibleCol = dgv.Columns.Cast<DataGridViewColumn>()
                                           .Where(c => c.Visible)
                                           .Select(c => c.Index).DefaultIfEmpty(0).First();
                dgv.CurrentCell = dgv.Rows[0].Cells[firstVisibleCol];
            }
        }

        private void SakrijMetaKolone(DataGridView dgv)
        {
            foreach (var c in new[] { "UbaciVrednosti", "KoloneZaInsert", "NazivTabele" })
                if (dgv.Columns.Contains(c)) dgv.Columns[c].Visible = false;
        }

        public void Dodaj(FrmPrijemniObrasci f)
        {
            try
            {
                using var dlg = new FrmPrijemniKreiraj();
                if (dlg.ShowDialog(f) != DialogResult.OK) return;

                int id = dlg.NoviIdPrijemnog;
                if (id > 0)
                {
                    using var det = new FrmPrijemniAzuriraj(id);
                    det.ShowDialog(f);
                }

                Osvezi(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Greška u Dodaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool TryGetIdFromRow(DataGridViewRow row, out int id)
        {
            id = 0;
            if (row == null) return false;
            var item = row.DataBoundItem;
            if (item == null) return false;

            switch (item)
            {
                case PrijemniObrazac po:
                    id = po.IdPrijemniObrazac; return true;

                case PrijemniObrazacGrid g:
                    id = g.IdPrijemniObrazac; return true;

                case System.Data.DataRowView drv:
                    id = Convert.ToInt32(drv["IdPrijemniObrazac"]); return true;

                default:
                    var prop = item.GetType().GetProperty("IdPrijemniObrazac");
                    if (prop == null) return false;
                    id = Convert.ToInt32(prop.GetValue(item));
                    return true;
            }
        }

        public void Izmeni(FrmPrijemniObrasci f)
        {
            if (!TryGetIdFromRow(f.DgvPrijemniObrasci.CurrentRow, out var id))
            { MessageBox.Show("Izaberi prijemni obrazac u tabeli."); return; }

            using (var det = new FrmPrijemniAzuriraj(id))
            {
                det.ShowDialog(f);
            }
            Osvezi(f);
        }

        

        public void Obrisi(FrmPrijemniObrasci f)
        {
            if (!TryGetIdFromRow(f.DgvPrijemniObrasci.CurrentRow, out var id))
            { MessageBox.Show("Izaberi prijemni obrazac."); return; }

            try
            {
                Komunikacija.Instance.PosaljiZahtev<object>(Operacija.ObrisiPrijemniObrazac, id);
                MessageBox.Show("Uspešno obrisano.");
                OcistiPolja(f);
                Osvezi(f);
            }
            catch (Exception ex)
            {
                // Poruka stiže sa servera (npr. FK 547) – samo je prikaži
                MessageBox.Show(ex.Message, "Brisanje nije moguće", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Pretrazi(FrmPrijemniObrasci f)
        {
            var kljuc = f.TxtPretraga.Text?.Trim() ?? "";
            var lista = Komunikacija.Instance
                .PosaljiZahtev<List<Domen.PrijemniObrazac>>(Operacija.PretraziPrijemneObrasce, kljuc)
                ?? new List<Domen.PrijemniObrazac>();

            f.DgvPrijemniObrasci.DataSource = new BindingList<Domen.PrijemniObrazac>(lista);
            SakrijMetaKolone(f.DgvPrijemniObrasci);
        }


        public void PrikaziDetalje(FrmPrijemniObrasci f)
        {
            int? id = DohvatiSelektovaniId(f.DgvPrijemniObrasci);
            if (id == null) { MessageBox.Show("Izaberi prijemni obrazac u tabeli."); return; }

            using var frm = new FrmPrijemniDetalji(id.Value);
            frm.ShowDialog(f);
        }

        private static int? DohvatiSelektovaniId(DataGridView dgv)
        {
            if (dgv.CurrentRow == null) return null;

            // 1) najčešći slučaj – strong-typed objekat
            if (dgv.CurrentRow.DataBoundItem is PrijemniObrazacGrid g)
                return g.IdPrijemniObrazac;

            // 2) fallback preko imena kolone
            if (dgv.Columns.Contains("IdPrijemniObrazac"))
            {
                var val = dgv.CurrentRow.Cells["IdPrijemniObrazac"].Value;
                if (val != null && int.TryParse(val.ToString(), out var id)) return id;
            }
            return null;
        }



        private void OcistiPolja(FrmPrijemniObrasci f)
        {
            
            f.TxtPretraga?.Clear();
        }
    }
}
