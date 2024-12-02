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
        private int _hariId = 0;

        public InputJadwalForm(string Jenis, int HariId)
        {
            InitializeComponent();
            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalNormalDal = new JadwalNormalDal();
             
            this.MaximizeBox = false;
            this.MinimizeBox = false;

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
            this.FormClosed += InputJadwalForm_FormClosed;
        }

        private void InputJadwalForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            StopAudio();
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (KeteranganText.Text == "" || SoundFileText.Text == "")
            {
                MessageBox.Show("Data Harus Lengkap", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PausePlayButton_Click(object? sender, EventArgs e)
        {
            string soundFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound");
            if (!Directory.Exists(soundFolder))
            {
                MessageBox.Show("Folder suara tidak ditemukan!");
                return;
            }

            string fileName = SoundFileText.Text.Trim();
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Pilih sound terlebih dahulu!");
                return;
            }

            string filePath = Path.Combine(soundFolder, fileName);
            if (!File.Exists(filePath))
            {
                MessageBox.Show($"File suara '{fileName}' tidak ditemukan di folder '{soundFolder}'!");
                return;
            }

            if (_isPlaying)
            {
                StopAudio();
                PausePlayButton.Text = "▶";
            }
            else
            {
                PlayAudio(filePath);
                PausePlayButton.Text = "■";
            }
        }

        private void PlayAudio(string filePath)
        {
            try
            {
                StopAudio();
                audioFileReader = new AudioFileReader(filePath);
                waveOutDevice = new WaveOutEvent();
                waveOutDevice.PlaybackStopped += (s, e) =>
                {
                    StopAudio();
                    PausePlayButton.Text = "▶";
                };
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.Play();
                _isPlaying = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memutar suara: {ex.Message}");
            }
        }

        private void StopAudio()
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
                  _jadwalNormalDal.Insert(jadwalNormal);
            }

            if (JenisJadwalLabel.Text == "Jadwal Khusus")
            {
                var jadwalKhusus = new JadwalKhususModel
                {
                    HariID = _hariId != 0 ? _hariId : 0,
                    Waktu = WaktuPicker.Value.ToString("HH:mm"),
                    Keterangan = KeteranganText.Text,
                    SoundName = SoundFileText.Text,
                    SoundPath = filePath
                };
                  _jadwalKhususDal.Insert(jadwalKhusus);
            }
        }
    }
}
