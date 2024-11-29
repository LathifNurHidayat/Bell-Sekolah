using BelSekolah.BelSekolahBackEnd.Model;
using BelSekolah.BelSekolahDatabase.Helper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelSekolah.BelSekolahBackEnd.Dal
{
    public class JadwalDal
    {
        
        public JadwalModel? GetJenisJadwal(int hari)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();
                const string sql = @"SELECT HariID, JenisJadwal FROM JadwalHari WHERE HariID = @HariID";

               return Conn.QueryFirstOrDefault<JadwalModel>(sql, new {HariID = hari});
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
                                        JenisJadwal = @JenisJadwal
                                    WHERE 
                                        HariID = @HariID";

                using (var cmd = new SQLiteCommand(sql, Conn))
                {
                    cmd.Parameters.AddWithValue("@HariID", model.HariID);
                    cmd.Parameters.AddWithValue("@JenisJadwal", model.JenisJadwal);

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
                                        HariID, 
                                        JenisJadwal, 
                                        Hari
                                    FROM 
                                        JadwalHari
                                    ORDER BY 
                                        CASE Hari
                                            WHEN 'Senin' THEN 1
                                            WHEN 'Selasa' THEN 2
                                            WHEN 'Rabu' THEN 3
                                            WHEN 'Kamis' THEN 4
                                            WHEN 'Jumat' THEN 5
                                            WHEN 'Sabtu' THEN 6
                                            WHEN 'Minggu' THEN 7
                                            ELSE 8 -- Untuk menangani nilai yang tidak dikenali
                                        END;";

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
