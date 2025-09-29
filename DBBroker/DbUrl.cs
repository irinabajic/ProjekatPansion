using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class DbUrl
    {
        public static readonly string FilePath =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dburl.txt");

        // podrazumevano (ako fajl ne postoji):
        public static readonly string Default =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PansionDB;Integrated Security=True;TrustServerCertificate=True;";

        public static string Current
            => File.Exists(FilePath) ? File.ReadAllText(FilePath).Trim() : Default;

        public static void Save(string connectionString)
            => File.WriteAllText(FilePath, (connectionString ?? "").Trim());
    }
}
