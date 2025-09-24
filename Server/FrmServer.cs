using Domen;
using System.ComponentModel;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server;
        private Thread nitAccept;
        private System.Windows.Forms.Timer tmr;   //  umesto posebne niti
        private volatile bool kraj = false;
        public FrmServer()
        {
            InitializeComponent();
            btnZaustavi.Enabled = false;

            tmr = new System.Windows.Forms.Timer(); // ← OVO fali
            tmr.Interval = 2000;
            tmr.Tick += (s, e) => OsveziDgv();
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            server = new Server();
            server.Pokreni();

            kraj = false;

            nitAccept = new Thread(server.Accept) { IsBackground = true };
            nitAccept.Start();

            btnPokreni.Enabled = false;
            btnZaustavi.Enabled = true;

            tmr.Start();                          // kreni sa osvežavanjem prijavljenih
            OsveziDgv();                          // odmah prvo punjenje
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            kraj = true;
            try { tmr.Stop(); } catch { }

            try { server?.Stop(); } catch { }
            try { nitAccept?.Join(1000); } catch { }

            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;

            // opciono: očisti grid
            dgvRadnici.DataSource = null;
        }

        private void OsveziDgv()
        {
            try
            {
                BindingList<Radnik> lista = ServerKontroler.Instance.VratiSviPrijavljeniRadnik();
                dgvRadnici.AutoGenerateColumns = true;
                dgvRadnici.DataSource = null;
                dgvRadnici.DataSource = lista;

                if (dgvRadnici.Columns.Contains("Password"))
                    dgvRadnici.Columns["Password"].Visible = false;
                if (dgvRadnici.Columns.Contains("Prijavljen"))
                    dgvRadnici.Columns["Prijavljen"].Visible = false;
            }
            catch
            {
                // ignoriši osvežavanje dok se gasi
            }
        }

        private void FrmServer_Load(object sender, EventArgs e)
        {

        }
    }
}
