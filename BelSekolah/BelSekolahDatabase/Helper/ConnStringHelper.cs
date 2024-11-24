using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BelSekolah.BelSekolahDatabase.Helper
{
    public class ConnStringHelper
    {
        public static string GetConn()
        {
            return "Data Source=sounds.db;Version=3;";
        }

    }
}
