using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IDomenObjekat
    {
        string NazivTabele { get; }
        string UbaciVrednosti { get; }
        string KoloneZaInsert { get; }

        IDomenObjekat ReadRow(SqlDataReader reader);
    }
}
