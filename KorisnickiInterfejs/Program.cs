namespace KorisnickiInterfejs
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var fLogin = new KorisnickiInterfejs.FrmLogin())
            {
                if (fLogin.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new KorisnickiInterfejs.FrmMain());
                }
            }
        }
    }
}