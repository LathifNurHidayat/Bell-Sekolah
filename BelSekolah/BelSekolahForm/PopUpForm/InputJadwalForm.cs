using BelSekolah.BelSekolahDatabase;
using BelSekolah.BelSekolahDatabase.Helper;
using CSCore.XAudio2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; 
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;
using Microsoft.VisualBasic.ApplicationServices;
using CSCore.SoundOut;

namespace BelSekolah.BelSekolahForm.PopUpForm
{
    public partial class InputJadwalForm : Form
    {
        // private readonly Database db;

        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader; // menggunakan ini untuk memutar sound
        private bool _isPlaying = false;
        public InputJadwalForm(string Jenis)
        {
            InitializeComponent();
           // db = new Database();
            JenisJadwalLabel.Text = Jenis;
            RegisterControlEvent();

            PausePlayButton.Text = "▶";
        }

        private void RegisterControlEvent()
        {
            BrowseButton.Click += BrowseButton_Click;
            PausePlayButton.Click += PausePlayButton_Click;
        }

        private void PausePlayButton_Click(object? sender, EventArgs e)
        {
            PausePlayButton.Text = (PausePlayButton.Text == "■") ? "▶" : "■";
            string soundFolder = @"C:\Users\Lenovo\source\repos\Bel_Sekolah\BelSekolah\sound"; // mencari file di folder sound

            if (!Directory.Exists(soundFolder))
            {
                MessageBox.Show("Folder suara tidak ditemukan!");
                return;
            }

            string fileName = SoundFileText.Text.Trim(); 

            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Nama file suara harus diisi!");
                return;
            }

            // jalur lengkap file suara
            string filePath = Path.Combine(soundFolder, fileName);

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"File suara '{fileName}' tidak ditemukan di folder '{soundFolder}'!");
                return;
            }

            // Inisialisasi atau reload SoundPlayer jika file berubah
            if (waveOutDevice == null || audioFileReader == null || audioFileReader.FileName != filePath)
            {
                try
                {
                    // Menghentikan dan membersihkan resource sebelumnya
                    waveOutDevice?.Stop();
                    waveOutDevice?.Dispose();
                    audioFileReader?.Dispose();

                    // Membaca file MP3
                    audioFileReader = new AudioFileReader(filePath);
                    waveOutDevice = new WaveOutEvent();
                    waveOutDevice.Init(audioFileReader);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tidak dapat memuat file suara: {ex.Message}");
                    return;
                }
            }

            // Jika belum memutar, mulai pemutaran suara
            if (!_isPlaying)
            {
                try
                {
                    waveOutDevice.Play();
                    PausePlayButton.Text = "■"; // Ganti ikon tombol
                    _isPlaying = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal memutar suara: {ex.Message}");
                }
            }
            else
            {
                // Jika sedang memutar, hentikan suara
                try
                {
                    waveOutDevice.Stop();
                    PausePlayButton.Text = "▶"; // Ganti ikon tombol
                    _isPlaying = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghentikan suara: {ex.Message}");
                }
            }
        }

        private void BrowseButton_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sound Files (*.mp3)|*.mp3";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FilePath = openFileDialog.FileName;
                string NamaFile = Path.GetFileName(FilePath);
                SoundFileText.Text = NamaFile;

                SelectAndReplace(FilePath);
            }
        }

        private void SelectAndReplace(string FilePath)
        {
            string tujuanFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound");

            if (!Directory.Exists(tujuanFolder))
            {
                Directory.CreateDirectory(tujuanFolder);
            }

            string tujuanPath = Path.Combine(tujuanFolder, Path.GetFileName(FilePath));

            File.Copy(FilePath, tujuanPath, true);
        }
        private void InputJadwalForm_Load(object sender, EventArgs e)
        {
            evenButton();
        }
        private void evenButton()
        {
            CancleButton.Click += CancleButton_Click;
          //  BrowseButton.Click += BrowseButton_Click;
            SaveButton.Click += SaveButton_Click;
        }
        #region Save
        private void SaveButton_Click(object? sender, EventArgs e)
        {
            string filePath = SoundFileText.Text;
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Mohon pilih file.");
                return;
            }
            string fileName = System.IO.Path.GetFileName(filePath);

            byte[] fileBytes;
            try
            {
                fileBytes = File.ReadAllBytes(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membaca file: {ex.Message}");
                return;
            }
            string time = WaktuPicker.Value.ToString("HH:mm");
            string description = KeteranganText.Text;
            string day = GetSelectedDays();
            if (string.IsNullOrEmpty(description) || string.IsNullOrEmpty(day))
            {
                MessageBox.Show("Mohon lengkapi semua input.");
                return;
            }
            try
            {
                bool isTrue = true;
                //db.SaveSound(time, day, description, fileName, fileBytes, isTrue);

                MessageBox.Show("Data berhasil disimpan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat menyimpan data: {ex.Message}");
            }
        }
        private string GetSelectedDays()
        {
            List<string> selectedDays = new List<string>();

            if (SetiapSeninCheckBox.Checked)
                selectedDays.Add("Senin");
            if (SetiapSelasaCheckBox.Checked)
                selectedDays.Add("Selasa");
            if (SetiapRabuCheckBox.Checked)
                selectedDays.Add("Rabu");
            if (SetiapKamisCheckBox.Checked)
                selectedDays.Add("Kamis");
            if (SetiapJumatCheckBox.Checked)
                selectedDays.Add("Jumat");

            return string.Join(", ", selectedDays);
        }

        public void SaveSoundd(string fileName, string filePath, string time, string day, string description)
        {
            if (string.IsNullOrEmpty(fileName) ||
                string.IsNullOrEmpty(filePath) ||
                string.IsNullOrEmpty(time) ||
                string.IsNullOrEmpty(day) ||
                string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Semua kolom harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TimeSpan.TryParse(time, out _))
            {
                MessageBox.Show("Format waktu tidak valid!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL query
            string query = "INSERT INTO Sounds (FileName, FilePath, Time, Day, Description) VALUES (@FileName, @FilePath, @Time, @Day, @Description)";

            try
            {
                using (var connection = new SQLiteConnection(ConnStringHelper.GetConn()))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Menambahkan parameter
                        command.Parameters.AddWithValue("@FileName", fileName);
                        command.Parameters.AddWithValue("@FilePath", filePath);
                        command.Parameters.AddWithValue("@Time", time);
                        command.Parameters.AddWithValue("@Day", day);
                        command.Parameters.AddWithValue("@Description", description);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Kesalahan database: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Browse
       /* private void BrowseButton_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3|All Files(*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    SoundFileText.Text = selectedFilePath;
                }
            }
        }*/
        #endregion


        private void CancleButton_Click(object? sender, EventArgs e)
        {
           this.Close();
        }
    }
}
