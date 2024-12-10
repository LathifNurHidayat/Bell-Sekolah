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
                                aa.RencanakanJadwalID, aa.HariID,  aa.Tanggal, aa.Keterangan, aa.IsUjian,
                                IFNULL(bb.Hari, ' ') AS Hari
                            FROM 
                                RencanakanJadwal aa
                                LEFT JOIN JadwalHari bb ON aa.HariID = bb.HariID
                            ORDER BY
                                Tanggal ASC";

                return Conn.Query<RencanakanJadwalModel>(sql);
            }
        }

        public RencanakanJadwalModel? GetDataUjian(int rencanakanID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                            SELECT 
                                RencanakanJadwalID, Tanggal , Keterangan
                            FROM
                                RencanakanJadwal
                            WHERE  
                                RencanakanJadwalID = @RencanakanJadwalID";

                return Conn.Query<RencanakanJadwalModel>(sql, new { RencanakanJadwalID = rencanakanID }).FirstOrDefault();
            }
        }

        public int Insert(RencanakanJadwalModel model)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                            INSERT INTO RencanakanJadwal
                            (HariID, Tanggal, Keterangan, IsUjian)
                            VALUES
                            (@HariID, @Tanggal, @Keterangan, @IsUjian)";

                var Dp = new DynamicParameters();
                Dp.Add("@HariID", model.HariID, System.Data.DbType.Int32);
                Dp.Add("@Tanggal", model.Tanggal, System.Data.DbType.String);
                Dp.Add("@Keterangan", model.Keterangan, System.Data.DbType.String);
                Dp.Add("@IsUjian", model.IsUjian, System.Data.DbType.Int32);

                Conn.Execute(sql,Dp);
                return (int)Conn.LastInsertRowId;
            }
        }

        public void Update(RencanakanJadwalModel model)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                            UPDATE RencanakanJadwal
                            SET
                            HariID = @HariID, Tanggal = @Tanggal, Keterangan = @Keterangan
                            WHERE
                            RencanakanJadwalID = @RencanakanJadwalID";

                var Dp = new DynamicParameters();
                Dp.Add("@RencanakanJadwalID", model.RencanakanJadwalID, System.Data.DbType.Int32);
                Dp.Add("@HariID", model.HariID, System.Data.DbType.Int32);
                Dp.Add("@Tanggal", model.Tanggal, System.Data.DbType.String);
                Dp.Add("@Keterangan", model.Keterangan, System.Data.DbType.String);

                Conn.Execute(sql, Dp);
            }
        }


        public void Delete(int RencanakanJadwalID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                            DELETE FROM 
                                RencanakanJadwal 
                            WHERE
                            RencanakanJadwalID = @RencanakanJadwalID";

                Conn.Execute(sql, new { RencanakanJadwalID = RencanakanJadwalID});
            }
        }

        public bool CekTanggal(string tanggal, int rencanakanID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                const string sql = @"SELECT COUNT(*) FROM RencanakanJadwal WHERE Tanggal = @Tanggal AND RencanakanJadwalID != @RencanakanJadwalID";

                return Conn.QueryFirstOrDefault<bool>(sql, new { Tanggal = tanggal , RencanakanJadwalID  = rencanakanID});
            }
        }

        public int  GetTanggal(string tanggal)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                const string sql = @"SELECT RencanakanJadwalID FROM RencanakanJadwal WHERE Tanggal = @Tanggal ";

                return Conn.QueryFirstOrDefault<int>(sql, new { Tanggal = tanggal});
            }
        }

    }
}
