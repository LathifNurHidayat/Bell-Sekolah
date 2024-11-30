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
                                    (HariID, Waktu, Keterangan, SoundName, SoundPath)
                                VALUES
                                    (@HariID, @Waktu, @Keterangan, @SoundName, @SoundPath)";

                using (var cmd = new SQLiteCommand(sql, Conn))
                {
                    cmd.Parameters.AddWithValue("@HariID", model.HariID);
                    cmd.Parameters.AddWithValue("@Waktu", model.Waktu);
                    cmd.Parameters.AddWithValue("@Keterangan", model.Keterangan);
                    cmd.Parameters.AddWithValue("@SoundName", model.SoundName);
                    cmd.Parameters.AddWithValue("@SoundPath", model.SoundPath);

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

        public IEnumerable<JadwalKhususModel> ListData(int HariId)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                            SELECT 
                                JadwalKhususID, HariID, Waktu, Keterangan, SoundName, SoundPath
                            FROM 
                                JadwalKhusus
                            WHERE 
                                HariID = @HariID
                            ORDER BY 
                                Waktu ASC";

                return Conn.Query<JadwalKhususModel>(sql, new { HariID = HariId });
            }
        }

        public void Delete(int JadwalKhususId)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"DELETE FROM JadwalKhusus WHERE JadwalKhususID = @JadwalKhususID";

                Conn.Execute(sql, new { JadwalKhususID = JadwalKhususId});
            }
        }

        public JadwalKhususModel? GetData(int JadwalID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                            SELECT 
                                JadwalKhususID, HariID, Waktu, Keterangan, SoundName, SoundPath
                            FROM 
                                JadwalKhusus
                            WHERE 
                                JadwalKhususID = @JadwalKhususID";

                return Conn.Query<JadwalKhususModel>(sql, new { JadwalKhususID = JadwalID }).FirstOrDefault();
            }
        }
    }
}
