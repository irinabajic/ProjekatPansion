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
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            kontroler.Login(this);
        }
    }
}
