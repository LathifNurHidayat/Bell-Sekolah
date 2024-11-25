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
    public class JadwalDal
    {

        public List<JadwalModel> GetJadwalModelsByJenisJadwalAndDay(string jenisJadwal, string currentDay)
        {
            using (var connection = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                string query = @"
            SELECT *
            FROM {0}
            WHERE HariID = (
                SELECT HariID 
                FROM JadwalHari 
                WHERE Hari = @Hari AND JenisJadwal = @JenisJadwal
            )";

                // Ganti tabel sesuai jenis jadwal
                string tableName = jenisJadwal.Equals("JadwalKhusus", StringComparison.OrdinalIgnoreCase)
                    ? "JadwalKhusus"
                    : "JadwalNormal";

                query = string.Format(query, tableName);

                return connection.Query<JadwalModel>(query, new { Hari = currentDay, JenisJadwal = jenisJadwal }).ToList();
            }
        }



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

        public IEnumerable<JadwalModel> ListData()
        {
            var jadwalList = new List<JadwalModel>();

            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                                    SELECT 
                                        HariID, JenisJadwal, Hari
                                    FROM 
                                        JadwalHari";

                using (var cmd = new SQLiteCommand(sql, Conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var jadwal = new JadwalModel
                            {
                                HariID = reader.GetInt32(0),
                                JenisJadwal = reader.GetString(1),  
                                Hari = reader.GetString(2)  
                            };

                            jadwalList.Add(jadwal);
                        }
                    }
                }
            }

            return jadwalList;
        }


        public void Delete(int HariID)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"DELETE FROM JadwalHari WHERE HariID = @HariID";

                using (var cmd = new SQLiteCommand(sql, Conn))
                {
                    cmd.Parameters.AddWithValue("@HariID", HariID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

       
    }
}
