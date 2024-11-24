using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Windows.Forms;
using NAudio.Wave;
using BelSekolah.BelSekolahDatabase.Helper;

namespace BelSekolah.BelSekolahDatabase
{
    public class dbone
    {
        private WaveOutEvent _waveOutEvent;
        private Mp3FileReader _mp3FileReader;
        private string connectionString = "Data Source=sounds.db;Version=3;";

        public void CreateTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string dropTableQuery = "DROP TABLE IF EXISTS Sounds;";
                using (SQLiteCommand command = new SQLiteCommand(dropTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Sounds (
                SoundID INTEGER PRIMARY KEY AUTOINCREMENT,
                FileName TEXT,
                FilePath TEXT,
                Time TEXT,  -- Waktu yang ditentukan
                Day TEXT,   -- Hari yang dipilih
                Description TEXT,  -- Keterangan untuk suara
                SoundFile BLOB  -- Kolom untuk menyimpan data file suara (BLOB)
            );";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        #region Simpan sound
        public void SsaveSound(string fileName, string filePath, string time, string day, string description)
        {
            string query = "INSERT INTO Sounds (FileName, FilePath, Time, Day, Description) VALUES (@FileName, @FilePath, @Time, @Day, @Description)";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@FilePath", filePath);
                    command.Parameters.AddWithValue("@Time", time);
                    command.Parameters.AddWithValue("@Day", day);
                    command.Parameters.AddWithValue("@Description", description);
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Ambil data file sound
        public List<string> GetSounds(string day, string time)
        {
            string query = "SELECT * FROM Sounds WHERE Day = @Day AND Time = @Time";
            List<string> soundsList = new List<string>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Day", day);
                    command.Parameters.AddWithValue("@Time", time);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // Membaca hasil query dan menambahkan data ke list
                        while (reader.Read())
                        {
                            string fileName = reader["FileName"].ToString();
                            string filePath = reader["FilePath"].ToString();
                            string description = reader["Description"].ToString();
                            soundsList.Add($"File: {fileName}, Path: {filePath}, Description: {description}");
                        }
                    }
                }
            }

            return soundsList;
        }
        #endregion
        public void PlaySoundFromDatabase(int soundId)
        {
            try
            {
                using (SQLiteConnection Conn = new SQLiteConnection(connectionString))
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

                                using (var memori = new MemoryStream(fileData))
                                {
                                    _mp3FileReader = new Mp3FileReader(memori);
                                    _waveOutEvent = new WaveOutEvent();
                                    _waveOutEvent.Init(_mp3FileReader);
                                    _waveOutEvent.Play();
                                }
                            }
                            else
                            {
                                Console.WriteLine("File suara tidak ditemukan dengan ID tersebut.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan saat memutar suara: {ex.Message}");
            }
        }
    }
}

