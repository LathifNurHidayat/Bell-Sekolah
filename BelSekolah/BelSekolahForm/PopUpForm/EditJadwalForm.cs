using BelSekolah.BelSekolahBackEnd.Dal;
using BelSekolah.BelSekolahBackEnd.Model;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah.BelSekolahForm.PopUpForm
{
    public partial class EditJadwalForm : Form
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader; // menggunakan ini untuk memutar sound
        private bool _isPlaying = false;
        private readonly JadwalKhususDal _jadwalKhususDal;
        private readonly JadwalNormalDal _jadwalNormalDal;
        private int _jadwalId;

        public EditJadwalForm(string Jenis, int JadwalId)
        {
            InitializeComponent();
            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalNormalDal = new JadwalNormalDal();

            _jadwalId = JadwalId;
            JenisJadwalLabel.Text = Jenis;
            RegisterControlEvent();

            PausePlayButton.Text = "▶";
            GetData(JadwalId);
        }

        private void RegisterControlEvent()
        {
            BrowseButton.Click += BrowseButton_Click;
            PausePlayButton.Click += PausePlayButton_Click;
            SaveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (KeteranganText.Text == "" || SoundFileText.Text == "")
            {
                MessageBox.Show("Data Harus Lengkap", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveData();
            this.Close();
        }




        private void PausePlayButton_Click(object? sender, EventArgs e)
        {
            // Path folder suara
            string soundFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound");

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

            // Jalur lengkap file suara
            string filePath = Path.Combine(soundFolder, fileName);

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"File suara '{fileName}' tidak ditemukan di folder '{soundFolder}'!");
                return;
            }

            // Jika suara sedang diputar, hentikan
            if (_isPlaying)
            {
                StopPlayback();
                PausePlayButton.Text = "▶";
                return;
            }

            // Inisialisasi atau reload audio jika file berubah
            if (audioFileReader == null || audioFileReader.FileName != filePath)
            {
                ResetAudio(filePath);
            }

            try
            {
                waveOutDevice.Play();
                PausePlayButton.Text = "■";
                _isPlaying = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memutar suara: {ex.Message}");
            }
        }

        // Fungsi reset audio untuk pemutaran ulang
        private void ResetAudio(string filePath)
        {
            try
            {
                StopPlayback(); // Hentikan pemutaran sebelumnya

                // Inisialisasi ulang audio
                audioFileReader = new AudioFileReader(filePath);
                waveOutDevice = new WaveOutEvent();
                waveOutDevice.PlaybackStopped += OnPlaybackStopped;
                waveOutDevice.Init(audioFileReader);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tidak dapat memuat file suara: {ex.Message}");
            }
        }

        // Fungsi untuk menghentikan pemutaran dan membersihkan resource
        private void StopPlayback()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }

            _isPlaying = false;
        }

        // Event handler untuk PlaybackStopped
        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            StopPlayback();
            PausePlayButton.Text = "▶";
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


        private void GetData(int jadwalId)
        {
            if (JenisJadwalLabel.Text == "Jadwal Normal")
            {
                var data = _jadwalNormalDal.GetData(jadwalId);

                if (DateTime.TryParse(data.Waktu, out DateTime waktu)) WaktuPicker.Value = waktu;
                KeteranganText.Text = data.Keterangan;
                SoundFileText.Text = data.SoundName;
            }
            else if (JenisJadwalLabel.Text == "Jadwal Khusus")
            {
                var data = _jadwalKhususDal.GetData(jadwalId);

                if (DateTime.TryParse(data.Waktu, out DateTime waktu)) WaktuPicker.Value = waktu;
                KeteranganText.Text = data.Keterangan;
                SoundFileText.Text = data.SoundName;
            }
        }

        private void SaveData()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", SoundFileText.Text);

            if (JenisJadwalLabel.Text == "Jadwal Normal")
            {
                var jadwalNormal = new JadwalNormalModel
                {
                    JadwalNormalID = _jadwalId,
                    Waktu = WaktuPicker.Value.ToString("HH:mm"),
                    Keterangan = KeteranganText.Text,
                    SoundName = SoundFileText.Text,
                    SoundPath = filePath
                };
                _jadwalNormalDal.Update(jadwalNormal);
            }

            if (JenisJadwalLabel.Text == "Jadwal Khusus")
            {
                var jadwalKhusus = new JadwalKhususModel
                {
                    JadwalKhususID = _jadwalId,
                    Waktu = WaktuPicker.Value.ToString("HH:mm"),
                    Keterangan = KeteranganText.Text,
                    SoundName = SoundFileText.Text,
                    SoundPath = filePath
                };
                _jadwalKhususDal.Update(jadwalKhusus);
            }
        }

    }
}
