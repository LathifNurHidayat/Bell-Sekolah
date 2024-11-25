using BelSekolah.BelSekolahBackEnd.Model;
using BelSekolah.BelSekolahDatabase.Helper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelSekolah.BelSekolahBackEnd.Dal
{
    public class JadwalDal
    {
        public int Insert(JadwalModel model)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                                    INSERT INTO JadwalHari
                                        (JenisJadwal, Hari)
                                    VALUES 
                                        (@JenisJadwal, @Hari);";

                using (var cmd = new SQLiteCommand(sql, Conn))
                {
                    cmd.Parameters.AddWithValue("@JenisJadwal", model.JenisJadwal);
                    cmd.Parameters.AddWithValue("@Hari", model.Hari);

                    cmd.ExecuteNonQuery();
                    long idLastInsert = Conn.LastInsertRowId;
                    return (int)idLastInsert;
                }
            }
        }

        public void Update(JadwalModel model)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                                    UPDATE 
                                        JadwalHari
                                    SET 
                                        JenisJadwal = @JenisJadwal,
                                        Hari = @Hari
                                    WHERE 
                                        HariID = @HariID";

                using (var cmd = new SQLiteCommand(sql, Conn))
                {
                    cmd.Parameters.AddWithValue("@HariID", model.HariID);
                    cmd.Parameters.AddWithValue("@JenisJadwal", model.JenisJadwal);
                    cmd.Parameters.AddWithValue("@Hari", model.Hari);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public <Ienumerable> ListData(int HariId)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                                    SELECT 
                                        HariID, JenisJadwal, Hari
                                    FROM 
                                        JadwalHari
                                    WHERE 
                                        HariID = @HariID";

                using (var cmd = new SQLiteCommand(sql, Conn))
                {
                    cmd.Parameters.AddWithValue("@HariID", HariId);
                   
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
