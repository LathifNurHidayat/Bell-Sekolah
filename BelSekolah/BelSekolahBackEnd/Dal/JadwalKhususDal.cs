using BelSekolah.BelSekolahDatabase.Helper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelSekolah.BelSekolahBackEnd.Dal
{
    public class JadwalKhususDal
    {
        public IEnumerable<BelSekolahBackEnd.Model.JadwalKhususModel> ListJadwalKhusus()
        {
            const string sql = @"SELECT Waktu FROM JadwalKhusus";
            using var db = new SQLiteConnection(ConnStringHelper.GetConn());
            return db.Query<BelSekolahBackEnd.Model.JadwalKhususModel>(sql);
        }
    }
}
