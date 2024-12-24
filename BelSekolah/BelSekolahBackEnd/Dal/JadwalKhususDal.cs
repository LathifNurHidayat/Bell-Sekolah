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
    public class JadwalKhususDal
    {

        public void Insert(JadwalKhususModel model)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                                INSERT INTO JadwalKhusus
                                    (HariID, Waktu, Keterangan, SoundName, SoundPath, IsUjian, RencanakanJadwalID)
                                VALUES
                                    (@HariID, @Waktu, @Keterangan, @SoundName, @SoundPath, @IsUjian, @RencanakanJadwalID)";

                using (var cmd = new SQLiteCommand(sql, Conn))
                {
                    cmd.Parameters.AddWithValue("@HariID", model.HariID);
                    cmd.Parameters.AddWithValue("@Waktu", model.Waktu);
                    cmd.Parameters.AddWithValue("@Keterangan", model.Keterangan);
                    cmd.Parameters.AddWithValue("@SoundName", model.SoundName);
                    cmd.Parameters.AddWithValue("@SoundPath", model.SoundPath);
                    cmd.Parameters.AddWithValue("@IsUjian", model.IsUjian);
                    cmd.Parameters.AddWithValue("@RencanakanJadwalID", model.RencanakanJadwalID);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(JadwalKhususModel model)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                                    UPDATE 
                                        JadwalKhusus
                                    SET 
                                        Waktu = @Waktu,
                                        Keterangan = @Keterangan,
                                        SoundName = @SoundName,
                                        SoundPath = @SoundPath
                                    WHERE 
                                        JadwalKhususID = @JadwalKhususID";

                using (var cmd = new SQLiteCommand(sql, Conn))
                {
                    cmd.Parameters.AddWithValue("@JadwalKhususID", model.JadwalKhususID);
                    cmd.Parameters.AddWithValue("@Waktu", model.Waktu);
                    cmd.Parameters.AddWithValue("@Keterangan", model.Keterangan);
                    cmd.Parameters.AddWithValue("@SoundName", model.SoundName);
                    cmd.Parameters.AddWithValue("@SoundPath", model.SoundPath);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<JadwalKhususModel> ListData(int hariID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = $@"
                            SELECT 
                                JadwalKhususID, Waktu, Keterangan, SoundName, SoundPath, IsUjian
                            FROM 
                                JadwalKhusus
                            WHERE 
                                HariID = @HariID AND RencanakanJadwalID = 0
                            ORDER BY 
                                JadwalKhususID ASC";

                return Conn.Query<JadwalKhususModel>(sql, new {HariID = hariID});
            }
        }



        public IEnumerable<JadwalKhususModel> ListDataForUjian(int rencanakanID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = $@"
                            SELECT 
                                JadwalKhususID, Waktu, Keterangan, SoundName, SoundPath, IsUjian
                            FROM 
                                JadwalKhusus
                            WHERE 
                                RencanakanJadwalID = @RencanakanJadwalID AND IsUjian = 1
                            ORDER BY 
                                Waktu ASC";

                return Conn.Query<JadwalKhususModel>(sql, new { RencanakanJadwalID = rencanakanID });
            }
        }

        public IEnumerable<JadwalKhususModel> ListDataAddToPlay(int rencanakanID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = $@"
                            SELECT 
                                JadwalKhususID, Waktu, Keterangan, SoundName, SoundPath, IsUjian
                            FROM 
                                JadwalKhusus
                            WHERE 
                                RencanakanJadwalID = @RencanakanJadwalID
                            ORDER BY 
                                JadwalKhususID ASC";

                return Conn.Query<JadwalKhususModel>(sql, new { RencanakanJadwalID = rencanakanID });
            }
        }

        public IEnumerable<JadwalKhususModel> ListDataForJadwal(int rencanakanID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = $@"
                            SELECT 
                                JadwalKhususID, Waktu, Keterangan, SoundName, SoundPath, IsUjian
                            FROM 
                                JadwalKhusus
                            WHERE 
                                RencanakanJadwalID = @RencanakanJadwalID AND IsUjian = 0
                            ORDER BY 
                                Waktu ASC";

                return Conn.Query<JadwalKhususModel>(sql, new { RencanakanJadwalID = rencanakanID });
            }
        }

        public void Delete(int hariID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"DELETE FROM JadwalKhusus WHERE HariID = @HariID";

                Conn.Execute(sql, new { HariID = hariID});
            }
        }

        public void DeleteOneRow(int jadwalID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"DELETE FROM JadwalKhusus WHERE JadwalKhususID = @JadwalKhususID";

                Conn.Execute(sql, new { JadwalKhususID = jadwalID });
            }
        }

        public JadwalKhususModel? GetData(int JadwalKhususId)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                            SELECT 
                                JadwalKhususID, Waktu, Keterangan, SoundName, SoundPath
                            FROM 
                                JadwalKhusus
                            WHERE  
                                IsUjian = 1 AND JadwalKhususID = @JadwalKhususID";

                return Conn.Query<JadwalKhususModel>(sql, new { JadwalKhususID = JadwalKhususId}).FirstOrDefault();
            }
        }

   
       
    }
}