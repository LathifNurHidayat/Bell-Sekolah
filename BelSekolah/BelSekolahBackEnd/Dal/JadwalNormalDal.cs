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
    public class JadwalNormalDal
    {

        public void Insert(JadwalNormalModel model)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                using (var transaction = Conn.BeginTransaction())
                {
                    const string sql = @"
                    INSERT INTO JadwalNormal
                        (HariID, Waktu, Keterangan, SoundName, SoundPath)
                    VALUES
                        (@HariID, @Waktu, @Keterangan, @SoundName, @SoundPath)";

                    using (var cmd = new SQLiteCommand(sql, Conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@HariID", model.HariID);
                        cmd.Parameters.AddWithValue("@Waktu", model.Waktu);
                        cmd.Parameters.AddWithValue("@Keterangan", model.Keterangan);
                        cmd.Parameters.AddWithValue("@SoundName", model.SoundName);
                        cmd.Parameters.AddWithValue("@SoundPath", model.SoundPath);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }



        public void Update(JadwalNormalModel model)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                                    UPDATE 
                                        JadwalNormal
                                    SET 
                                        Waktu = @Waktu,
                                        Keterangan = @Keterangan,
                                        SoundName = @SoundName,
                                        SoundPath = @SoundPath
                                    WHERE 
                                        JadwalNormalID = @JadwalNormalID";

                using (var cmd = new SQLiteCommand(sql, Conn))
                {
                    cmd.Parameters.AddWithValue("@JadwalNormalID", model.JadwalNormalID);
                    cmd.Parameters.AddWithValue("@Waktu", model.Waktu);
                    cmd.Parameters.AddWithValue("@Keterangan", model.Keterangan);
                    cmd.Parameters.AddWithValue("@SoundName", model.SoundName);
                    cmd.Parameters.AddWithValue("@SoundPath", model.SoundPath);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<JadwalNormalModel> ListData(int HariId)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                            SELECT 
                                JadwalNormalID, HariID, Waktu, Keterangan, SoundName, SoundPath
                            FROM 
                                JadwalNormal
                            WHERE 
                                HariID = @HariID
                            ORDER BY 
                                Waktu ASC";

                return Conn.Query<JadwalNormalModel>(sql, new { HariID = HariId });
            }
        }



        public void Delete(int JadwalNormalId)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"DELETE FROM JadwalNormal WHERE JadwalNormalID = @JadwalNormalID";

                Conn.Execute(sql, new { JadwalNormalID = JadwalNormalId });
            }
        }

        public JadwalNormalModel? GetData(int JadwalNormalID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                           SELECT 
                                JadwalNormalID, HariID, Waktu, Keterangan, SoundName, SoundPath
                            FROM 
                                JadwalNormal
                            WHERE 
                                JadwalNormalID = @JadwalNormalID";

                return Conn.Query<JadwalNormalModel>(sql, new { JadwalNormalID = JadwalNormalID }).FirstOrDefault();
            }
        }
    }
}
