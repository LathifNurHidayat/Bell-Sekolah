using BelSekolah.BelSekolahBackEnd.Dal;
using BelSekolah.BelSekolahBackEnd.Model;
using BelSekolah.BelSekolahDatabase;
using BelSekolah.BelSekolahDatabase.Helper;
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

namespace BelSekolah.BelSekolahForm.PopUpForm
{
    public partial class InputJadwalForm : Form
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader; // menggunakan ini untuk memutar sound
        private bool _isPlaying = false;
        private readonly JadwalKhususDal _jadwalKhususDal;
        private readonly JadwalNormalDal _jadwalNormalDal;
        private int _hariId;

        public InputJadwalForm(string Jenis, int HariId)
        {
            InitializeComponent();
            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalNormalDal = new JadwalNormalDal();

            _hariId = HariId;
            JenisJadwalLabel.Text = Jenis;
            RegisterControlEvent();

            PausePlayButton.Text = "▶";
        }

      

        private void RegisterControlEvent()
        {
            BrowseButton.Click += BrowseButton_Click;
            PausePlayButton.Click += PausePlayButton_Click;
            SaveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (WaktuPicker.Value.TimeOfDay == DateTime.Today.TimeOfDay || KeteranganText.Text == "" || SoundFileText.Text == "")
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
                SoundFileText.Clear();

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

        private void SaveData()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", SoundFileText.Text);

            if (JenisJadwalLabel.Text == "Jadwal Normal")
            {
                var jadwalNormal = new JadwalNormalModel
                {
                    HariID = _hariId,
                    Waktu = WaktuPicker.Value.ToString("HH:mm"),
                    Keterangan = KeteranganText.Text,
                    SoundName = SoundFileText.Text,
                    SoundPath = filePath
                };

                if (_hariId == 0)
                {
                    _jadwalNormalDal.Insert(jadwalNormal);
                }

            }

            if (JenisJadwalLabel.Text == "Jadwal Khusus")
            {
                var jadwalKhusus = new JadwalKhususModel
                {
                    HariID = _hariId,
                    Waktu = WaktuPicker.Value.ToString(),
                    Keterangan = KeteranganText.Text,
                    SoundName = SoundFileText.Text,
                    SoundPath = filePath
                };

                if (_hariId == 0)
                {
                    _jadwalKhususDal.Insert(jadwalKhusus);
                }
            }
        }
    }
}
