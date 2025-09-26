using KorisnickiInterfejs.GUIKontroler;

namespace KorisnickiInterfejs
{
    //sluzi samo za prikaz
    //ne sme imati reference tipa na domen itd.
    public partial class FrmLogin : Form
    {
        private LoginKontroler kontroler;
        public FrmLogin()
        {
            InitializeComponent();
            kontroler = new LoginKontroler();
            this.StartPosition = FormStartPosition.CenterScreen;

            btnRegistracija.Click += (s, e) =>
            {
                using var frm = new FrmRegistracijaRadnika();
                frm.ShowDialog(this); // CenterParent ?e je centrirati
            };

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            kontroler.Login(this);
        }


    }
}
