using BelSekolah.BelSekolahBackEnd.Model;
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
    public class RencanakanJadwalDal
    {
        public IEnumerable<RencanakanJadwalModel> ListData()
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                            SELECT 
                                RencanakanJadwalID, HariID, Tanggal, Keterangan
                            FROM 
                                RencanakanJadwal
                            ORDER BY 
                                Tanggal ASC";

                return Conn.Query<RencanakanJadwalModel>(sql);
            }
        }

    }
}
