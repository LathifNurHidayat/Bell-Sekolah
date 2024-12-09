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
using System.Globalization;

namespace BelSekolah.BelSekolahForm.PopUpForm
{
    public partial class InputRencanakanJadwalUjianForm : Form
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private bool _isPlaying = false;
        private readonly JadwalKhususDal _jadwalKhususDal;
        private readonly JadwalDal _jadwalDal;
        private readonly RencanakanJadwalDal _rencanakanJadwalDal;
        private int _hariId = 0;
        private string _hariName;
        private int _jadwalID = 0;
        private int _rencanaJadwalID;

        public InputRencanakanJadwalUjianForm(int perencanaanID)
        {
            InitializeComponent();
            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalDal = new JadwalDal();
            _rencanakanJadwalDal = new RencanakanJadwalDal();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("id-ID");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("id-ID");

            _rencanaJadwalID = perencanaanID;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            RegisterControlEvent();

            if(perencanaanID != 0)
                GetData(perencanaanID);

            PausePlayButton.Text = "▶";
            LoadData();
            CustomStyleGrid(JadwalUjianGrid);
            ClearForm();

            
        }

        private void GetData(int rencanakanJadwalID)
        {
            var data = _rencanakanJadwalDal.GetDataUjian(rencanakanJadwalID);

            TanggalPicker.Value = DateTime.TryParse(data.Tanggal, out DateTime waktu) ? waktu : DateTime.Today;
            KeteranganJadwalText.Text = data.Keterangan;
        }

        private void CustomStyleGrid(DataGridView grid)
        {
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.EnableHeadersVisualStyles = false;

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            grid.RowTemplate.Height = 30;
        }

        private void ClearForm()
        {
            WaktuPicker.Value = DateTime.Today;
            KeteranganJadwalText.Clear();
            SoundFileText.Clear();
            _jadwalID = 0;
        }

        private void LoadData()
        {
            var data = _jadwalKhususDal.ListDataForRencanakan(_rencanaJadwalID).Select(x => new
            {
                x.JadwalKhususID,
                x.Waktu,
                x.Keterangan,
                x.SoundName,
            }).ToList();

            JadwalUjianGrid.DataSource = data;
            JadwalUjianGrid.Columns["JadwalKhususID"].Visible = false;
        }

        private void RegisterControlEvent()
        {
            BrowseButton.Click += BrowseButton_Click;
            PausePlayButton.Click += PausePlayButton_Click;
            SaveButton.Click += SaveButton_Click;
            this.FormClosed += InputJadwalForm_FormClosed;
            NewButton.Click += NewButton_Click;
            JadwalUjianGrid.RowEnter += JadwalUjianGrid_RowEnter;
            TanggalPicker.ValueChanged += TanggalPicker_ValueChanged;
        }

        private void TanggalPicker_ValueChanged(object? sender, EventArgs e)
        {
            _hariName = TanggalPicker.Value.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));
            _hariId = _jadwalDal.GetIdByHari(_hariName);
        }

        private void JadwalUjianGrid_RowEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                StopAudio();
                _jadwalID = Convert.ToInt32(JadwalUjianGrid.Rows[e.RowIndex]?.Cells["JadwalKhususID"]?.Value);
                var data = _jadwalKhususDal.GetData(_jadwalID);
                if (data == null) return;

                WaktuPicker.Value = DateTime.Parse(data.Waktu);
                KeteranganJadwalText.Text = data.Keterangan;
                SoundFileText.Text = data.SoundName;
            }
        }
         
        private void NewButton_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void InputJadwalForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            StopAudio();
            this.DialogResult = DialogResult.OK;
        }
          
        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (KeteranganJadwalText.Text == "" || SoundFileText.Text == "" || WaktuPicker.Value == DateTime.Today)
            {
                MessageBox.Show("Data Harus Lengkap", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveData();
            LoadData();
            ClearForm();
        }

        private void PausePlayButton_Click(object? sender, EventArgs e)
        {
            string soundFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Ujian");
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
            openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Ujian");

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FilePath = openFileDialog.FileName;
                string NamaFile = Path.GetFileName(FilePath);
                SoundFileText.Clear();

                SoundFileText.Text = NamaFile;

                SelectAndReplace(FilePath);
            }
        }

        private void SelectAndReplace(string SoundPath)
        {
            string tujuanFolder;
            string tujuanPath;

            tujuanFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Ujian");

            if (!Directory.Exists(tujuanFolder))
                Directory.CreateDirectory(tujuanFolder);

            tujuanPath = Path.Combine(tujuanFolder, Path.GetFileName(SoundPath));

            if (!File.Exists(tujuanPath))
                File.Copy(SoundPath, tujuanPath);
        }

        private void SaveData()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Ujian", SoundFileText.Text);

            if (_rencanaJadwalID == 0)
            {
                var data = new RencanakanJadwalModel
                {
                    HariID = _hariId,
                    Tanggal = TanggalPicker.Value.ToString("dd-MM-yyyy"),
                    Keterangan = KeteranganJadwalText.Text,
                    IsUjian = 1
                };
                _rencanaJadwalID = _rencanakanJadwalDal.Insert(data);
            }
            var jadwalKhusus = new JadwalKhususModel
            {
                HariID = _hariId,
                Waktu = WaktuPicker.Value.ToString("HH:mm"),
                Keterangan = KeteranganJadwalText.Text,
                SoundName = SoundFileText.Text,
                SoundPath = filePath,
                IsUjian = 1,
                RencanakanJadwalID = _rencanaJadwalID
            };

            if (_jadwalID == 0)
            {
                _jadwalKhususDal.Insert(jadwalKhusus);
                MessageBox.Show("insert");
            }
            else
            {
                _jadwalKhususDal.Update(jadwalKhusus);
                MessageBox.Show("Update");
            }
                
        }
    }
}