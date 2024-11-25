using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SQLite;
using NAudio.Wave;
using BelSekolah.BelSekolahDatabase.Helper;

namespace BelSekolah.BelSekolahDatabase
{
    public class Database
    {
        private WaveOutEvent _waveOutEvent;
        private Mp3FileReader _mp3FileReader;


        public void CreateTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                connection.Open();

                string createTableJadwalHari = @"
                    CREATE TABLE IF NOT EXISTS Hari(
                        HariID INTEGER PRIMARY KEY AUTOINCREMENT,
                        JenisJadwal TEXT NOT NULL,
                        Hari TEXT NOT NULL
                    )";

                string createTableJadwalKhusus = @"
                    CREATE TABLE IF NOT EXISTS JadwalKhusus(
                        HariID INTEGER NOT NULL,
                        Waktu TEXT NOT NULL,
                        Keterangan TEXT NOT NULL,
                        SoundName TEXT NOT NULL,
                        SoundPath TEXT NOT NULL
                    )";

                string createTableJadwalNormal = @"
                    CREATE TABLE IF NOT EXISTS JadwalNormal(
                        HariID INTEGER NOT NULL,
                        Waktu TEXT NOT NULL,
                        Keterangan TEXT NOT NULL,
                        SoundName TEXT NOT NULL,
                        SoundPath TEXT NOT NULL
                    )";

                ExecuteNonQuery(createTableJadwalHari, connection);
                ExecuteNonQuery(createTableJadwalKhusus, connection);
                ExecuteNonQuery(createTableJadwalNormal, connection);
            }
        }

        private void ExecuteNonQuery(string query, SQLiteConnection connection)
        {
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }




        #region simpan sound 
        public void SaveSound(string waktu, string hari, string keterangan, string soundName, byte[] sound, bool isTrue)
        {
            // Validasi input agar tidak ada parameter kosong
            if (string.IsNullOrEmpty(waktu) ||
                string.IsNullOrEmpty(hari) ||
                string.IsNullOrEmpty(keterangan) ||
                string.IsNullOrEmpty(soundName) ||
                sound == null || sound.Length == 0)
            {
                throw new ArgumentException("Semua parameter harus diisi.");
            }

            // Query SQL untuk menyisipkan data ke tabel JadwalKhusus
            string query = @"
        INSERT INTO JadwalKhusus (IsTrue, Waktu, Hari, Keterangan, SoundName, Sound) 
        VALUES (@IsTrue, @Waktu, @Hari, @Keterangan, @SoundName, @Sound)";

            try
            {
                // Membuka koneksi SQLite
                using (var connection = new SQLiteConnection(ConnStringHelper.GetConn()))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Menambahkan nilai parameter ke query
                        command.Parameters.AddWithValue("@IsTrue", isTrue ? 1 : 0); // Konversi bool ke INTEGER
                        command.Parameters.AddWithValue("@Waktu", waktu);
                        command.Parameters.AddWithValue("@Hari", hari);
                        command.Parameters.AddWithValue("@Keterangan", keterangan);
                        command.Parameters.AddWithValue("@SoundName", soundName);
                        command.Parameters.AddWithValue("@Sound", sound);

                        // Menjalankan perintah SQL
                        command.ExecuteNonQuery();
                    }
                }

                // Menampilkan pesan sukses
                MessageBox.Show("Data berhasil disimpan!");
            }
            catch (SQLiteException ex)
            {
                // Menangkap kesalahan database
                MessageBox.Show($"Kesalahan database: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Menangkap kesalahan umum lainnya
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }


        #endregion


        // benahi get sound
        #region file sound 
        public List<string> GetJadwalKhusus()
        {
            List<string> jadwalList = new List<string>();

            // Menyesuaikan query untuk mengambil data dari tabel JadwalKhusus
            string query = "SELECT SoundName, Waktu, Hari, Keterangan FROM JadwalKhusus";

            using (SQLiteConnection connection = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // Membaca data dari query dan menambahkannya ke list
                        while (reader.Read())
                        {
                            string soundName = reader["SoundName"].ToString();
                            string waktu = reader["Waktu"].ToString();
                            string hari = reader["Hari"].ToString();
                            string keterangan = reader["Keterangan"].ToString();

                            // Menyusun format data yang ingin ditampilkan, misalnya:
                            jadwalList.Add($"Sound: {soundName}, Waktu: {waktu}, Hari: {hari}, Keterangan: {keterangan}");
                        }
                    }
                }
            }

            return jadwalList;
        }

        #endregion 

        public void PlaySoundFromDatabase(int soundId)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();
                string query = @"SELECT SoundFile FROM Sounds WHERE SoundID = @SoundID";
                using (var cmd = new SQLiteCommand(query, Conn))
                {
                    cmd.Parameters.AddWithValue("@SoundID", soundId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] fileData = (byte[])reader["SoundFile"];
                            var memori = new MemoryStream(fileData);

                            _mp3FileReader = new Mp3FileReader(memori);
                            _waveOutEvent = new WaveOutEvent();
                            _waveOutEvent.Init(_mp3FileReader);
                            _waveOutEvent.Play();
                        }
                    }

                }
            }
        }


    }
}


