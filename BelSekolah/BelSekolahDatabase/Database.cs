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

                string createTableSounds = @"
                    CREATE TABLE IF NOT EXISTS Sounds (
                        SoundID INTEGER PRIMARY KEY AUTOINCREMENT,
                        FileName TEXT NOT NULL,
                        SoundFile BLOB NOT NULL
                    );";

                string createTableJadwalKhusus = @"
                    CREATE TABLE IF NOT EXISTS JadwalKhusus(
                        JadwalKhususID INTEGER PRIMARY KEY AUTOINCREMENT,
                        IsTrue INTEGER NOT NULL,
                        SoundID INTEGER NOT NULL,
                        Waktu TEXT NOT NULL,
                        Hari TEXT NOT NULL,
                        Keterangan TEXT NOT NULL,
                        FOREIGN KEY (SoundID) REFERENCES Sounds(SoundID) ON DELETE CASCADE
                    );";

                string createTableJadwalNormal = @"
                    CREATE TABLE IF NOT EXISTS JadwalNormal(
                        JadwalNormalID INTEGER PRIMARY KEY AUTOINCREMENT,
                        IsTrue INTEGER NOT NULL,
                        SoundID INTEGER NOT NULL,
                        Waktu TEXT NOT NULL,
                        Hari TEXT NOT NULL,
                        Keterangan TEXT NOT NULL,
                        FOREIGN KEY (SoundID) REFERENCES Sounds(SoundID) ON DELETE CASCADE
                    );";

                ExecuteNonQuery(createTableSounds, connection);
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
        public void SaveSound(string fileName, string filePath, string time, string day, string description)
        {
            if (string.IsNullOrEmpty(fileName) ||
                string.IsNullOrEmpty(filePath) ||
                string.IsNullOrEmpty(time) ||
                string.IsNullOrEmpty(day) ||
                string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Semua parameter harus diisi.");
            }

            string query = "INSERT INTO Sounds (FileName, FilePath, Time, Day, Description) VALUES (@FileName, @FilePath, @Time, @Day, @Description)";

            try
            {
                using (var connection = new SQLiteConnection(ConnStringHelper.GetConn()))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
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
            catch (SQLiteException ex)
            {
                throw new Exception($"Kesalahan database: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Terjadi kesalahan: {ex.Message}");
            }
        }

        #endregion


        // benahi get sound
        #region file sound 
        public List<string> GetSounds()
        {
            List<string> soundsList = new List<string>();

            string query = "SELECT FileName, SoundFile FROM Sounds";

            using (SQLiteConnection connection = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string fileName = reader["FileName"].ToString();
                            string filePath = reader["FilePath"].ToString();
                            soundsList.Add($"{fileName} - {filePath}"); // Gabungkan nama file dan path
                        }
                    }
                }
            }

            return soundsList;
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


