namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server;
        private Thread nitAccept;
        private Thread nitDgv;
        private volatile bool kraj = false;
        public FrmServer()
        {
            InitializeComponent();
            btnZaustavi.Enabled = false;
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

            //nitDgv = new Thread(AzurirajDgv) { IsBackground = true };
            //nitDgv.Start();
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            kraj = true;
            try { server?.Stop(); } catch { }
            try { nitAccept?.Join(1000); } catch { }
            try { nitDgv?.Join(1000); } catch { }

            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
        }

        private void FrmServer_Load(object sender, EventArgs e)
        {

        }
    }
}
