using BelSekolah.BelSekolahBackEnd.Dal;
using BelSekolah.BelSekolahBackEnd.Model;
using BelSekolah.BelSekolahDatabase;
using BelSekolah.BelSekolahDatabase.Helper;
using BelSekolah.BelSekolahForm.PopUpForm;
using BelSekolah.BelSekolahForm.PopUpForm.Jadwalkan_Form;
using Dapper;
using NAudio.Wave;
using NAudio.Wave.Asio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BelSekolah.BelSekolahForm
{
    public partial class JadwalBelForm : Form
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private enum GridAktif { None, JadwalNormal, JadwalKhusus };
        private GridAktif _gridAktif = GridAktif.None;
        private enum ComboAktif { ComboAktif, ComboNonAktif };
        private ComboAktif _combo = ComboAktif.ComboAktif;

        private Form mainForm;
        private readonly JadwalDal _jadwalDal;
        private readonly JadwalKhususDal _jadwalKhususDal;
        private readonly JadwalNormalDal _jadwalNormalDal;
        private readonly JadwalModel _jadwalModel;
        private readonly RencanakanJadwalDal _rencanakanJadwalDal;

        private int _hariID;
        private string _waktuSekarang;
        private string _hariSekarang;
        private string _jenisJadwal;
        private bool _isRunning = false;

        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _jam;
        private System.Windows.Forms.Timer _cekJadwal;

        private List<JadwalDto> _dataJadwalPutar = new List<JadwalDto>();
        private string _keteranganJadwal;
        private Form _loadForm;


        public JadwalBelForm(Form mainForm)
        {
            InitializeComponent();
            _jadwalDal = new JadwalDal();
            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalNormalDal = new JadwalNormalDal();
            _jadwalModel = new JadwalModel();
            _rencanakanJadwalDal = new RencanakanJadwalDal();


            _timer = new System.Windows.Forms.Timer();
            _jam = new System.Windows.Forms.Timer();
            _cekJadwal = new System.Windows.Forms.Timer();

            this.mainForm = mainForm;
            _loadForm = mainForm;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new Size(1600, 800);

            _hariSekarang = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));
            _waktuSekarang = DateTime.Now.ToString("HH:mm");
            _hariID = Convert.ToInt32(HariCombo.SelectedValue);

            RegisterControlEvent();
            InitialCombo();

            _jam.Interval = 1000;
            _jam.Tick += _jam_Tick;
            _jam.Start();

            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;

            /* _cekJadwal.Interval = 5000;
             _cekJadwal.Tick += (s, e) => {AddDataToList(); };*/

            LoadJadwalDetil(_hariID);

            CustomStyleGrid(JadwalNormalGrid);
            CustomStyleGrid(JadwalKhususGrid);

            _dataJadwalPutar.Clear();
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

            grid.RowTemplate.Height = 30;
        }

        private void _jam_Tick(object? sender, EventArgs e)
        {
            JamLabel.Text = DateTime.Now.ToString("HH:mm:ss");

            if (DateTime.Now.Hour == 17 && DateTime.Now.Minute == 00 && DateTime.Now.Second == 00)
            { 
                BelSekolah.BelSekolahForm.HitungMundurForm.HitungMundurForm form = new BelSekolah.BelSekolahForm.HitungMundurForm.HitungMundurForm(_loadForm);
                form.ShowDialog();
            }
        }

        private async void _timer_Tick(object? sender, EventArgs e)
        {
            /*TimeSpan timeNow = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));*/
            TimeSpan timeNow = TimeSpan.Parse(JamLabel.Text);

            var data = _dataJadwalPutar.FirstOrDefault(x => x.Waktu == timeNow);

            var stopSoundIsPlayed = _dataJadwalPutar.FirstOrDefault(x => x.Waktu > timeNow);
            if (stopSoundIsPlayed != null && (stopSoundIsPlayed.Waktu - timeNow).TotalSeconds <= 5)
            {
                StopAudio();
            }

            if (data != null)
            {
                string path = data.SoundPath;

                if (path.Contains("|"))
                {
                    string[] laguName = data.SoundName.Split('|');
                    foreach (string lagu in laguName)
                    {
                        string laguPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Lagu Lagu", lagu);
                        await PlaySoundAsync(laguPath);
                        await Task.Delay(3000);
                    }
                }
                else
                {
                    await PlaySoundAsync(path);
                }
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
        }

        private async Task PlaySoundAsync(string soundPath)
        {
            if (!File.Exists(soundPath))
            {
                MessageBox.Show("File audio tidak ditemukan.");
                MessageBox.Show(soundPath);

                return;
            }

            var tcs = new TaskCompletionSource<bool>();

            try
            {
                await StopSoundGraduallyAsync();

                audioFileReader = new AudioFileReader(soundPath);
                waveOutDevice = new WaveOutEvent();
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.Play();

                waveOutDevice.PlaybackStopped += (s, e) =>
                {
                    CleanupAudioResources();
                    tcs.TrySetResult(true); // Pastikan task diselesaikan
                };

                await tcs.Task;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memutar suara: {ex.Message}");
            }
        }

        private async Task StopSoundGraduallyAsync()
        {
            if (waveOutDevice != null && audioFileReader != null)
            {
                try
                {
                    int fadeOutDuration = 1000; // ms
                    float initialVolume = 1.0f;

                    if (waveOutDevice.Volume > 0)
                        initialVolume = waveOutDevice.Volume;

                    for (int i = 10; i >= 0; i--)
                    {
                        waveOutDevice.Volume = initialVolume * (i / 10f);
                        await Task.Delay(fadeOutDuration / 10);
                    }

                    waveOutDevice.Stop();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error during fade-out: {ex.Message}");
                }
            }

            CleanupAudioResources();

        }

        

        private void CleanupAudioResources()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
        }

        private void ClearText()
        {
            HariText.Clear();
        }

        private void GetJadwalDiputar()
        {
            ClearText();
            HariText.Text = _hariSekarang;
        }

        private void AddDataToList()
        {
            _dataJadwalPutar.Clear();

            _hariSekarang = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("ID-id"));
            _hariID = _jadwalDal.GetIdByHari(_hariSekarang);
            // _hariID = (int)HariCombo.SelectedValue;
            var jenis_jadwal = _jadwalDal.GetJenisJadwal(_hariID)?.JenisJadwal;
            _jenisJadwal = jenis_jadwal?.ToString() ?? string.Empty;

            string tanggalHariIni = DateTime.Now.ToString("dd-MM-yyyy");
            int cekRencanaJadwalID = _rencanakanJadwalDal.GetTanggal(tanggalHariIni);

            if (cekRencanaJadwalID != 0)
            {
                var data = _jadwalKhususDal.ListDataAddToPlay(cekRencanaJadwalID).Select(x => new JadwalDto
                {
                    Keterangan = x.Keterangan,
                    HariID = x.HariID,
                    Waktu = TimeSpan.Parse(x.Waktu),
                    SoundName = x.SoundName,
                    SoundPath = x.SoundPath
                });
                string keterangan = _jadwalDal.GetHariById(data?.FirstOrDefault()?.HariID ?? 0).ToString();
                _keteranganJadwal = keterangan != string.Empty ? $"{keterangan} - Jadwal Direncanakan" : "Data Kosong";
                foreach (var item in data)
                {
                    _dataJadwalPutar.Add(item);
                }
                return;
            }
              
            if (!string.IsNullOrEmpty(_jenisJadwal))
            {

                if (_jenisJadwal == "Jadwal Normal")
                {
                    var data = _jadwalNormalDal.ListData(_hariID).Select(x => new JadwalDto
                    {
                        Keterangan = x.Keterangan,
                        HariID = x.HariID,
                        Waktu = TimeSpan.Parse(x.Waktu),
                        SoundName = x.SoundName,
                        SoundPath = x.SoundPath,
                    });
                    string keterangan = _jadwalDal.GetHariById(data.FirstOrDefault()?.HariID ?? 0).ToString();
                    _keteranganJadwal = keterangan != string.Empty ? $"{keterangan} - Jadwal Normal" : "Data Kosong";
                    foreach (var item in data)
                    {
                        _dataJadwalPutar.Add(item);
                    }
                }
                else if (_jenisJadwal == "Jadwal Khusus")
                {

                    var data = _jadwalKhususDal.ListData(_hariID).Select(x => new JadwalDto
                    {
                        Keterangan = x.Keterangan,
                        HariID = x.HariID,
                        Waktu = TimeSpan.Parse(x.Waktu),
                        SoundName = x.SoundName,
                        SoundPath = x.SoundPath,
                    });
                    string keterangan = _jadwalDal.GetHariById(data.FirstOrDefault()?.HariID ?? 0).ToString();
                    _keteranganJadwal = keterangan != string.Empty ? $"{keterangan} - Jadwal Khusus" : "Data Kosong";
                    foreach (var item in data)
                    {
                        _dataJadwalPutar.Add(item);
                    }
                }
            }
        }

        private void InitialCombo()
        {
            var Hari = _jadwalDal.ListData();
            HariCombo.DataSource = Hari;
            HariCombo.DisplayMember = "Hari";
            HariCombo.ValueMember = "HariID";

            var selectedHari = Hari.FirstOrDefault(x => x.Hari.Equals(_hariSekarang, StringComparison.OrdinalIgnoreCase));
            if (selectedHari != null)
            {
                HariCombo.SelectedItem = selectedHari;
            }
        }

        private void LoadJadwalDetil(int HariID)
        {
            var jadwalNormal = _jadwalNormalDal.ListData(HariID);
            JadwalNormalGrid.DataSource = jadwalNormal;
            JadwalNormalGrid.Columns["JadwalNormalID"].Visible = false;
            JadwalNormalGrid.Columns["HariID"].Visible = false;
            JadwalNormalGrid.Columns["SoundPath"].Visible = false;
            JadwalNormalGrid.Columns["SoundName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            JadwalNormalGrid.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            var jadwalKhusus = _jadwalKhususDal.ListData(HariID);
            JadwalKhususGrid.DataSource = jadwalKhusus;
            JadwalKhususGrid.Columns["JadwalKhususID"].Visible = false;
            JadwalKhususGrid.Columns["HariID"].Visible = false;
            JadwalKhususGrid.Columns["SoundPath"].Visible = false;
            JadwalKhususGrid.Columns["IsUjian"].Visible = false;
            JadwalKhususGrid.Columns["RencanakanJadwalID"].Visible = false;
            JadwalKhususGrid.Columns["SoundName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            JadwalKhususGrid.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            if (JadwalNormalGrid.RowCount < 1)
            {
                TambahNormalButton.Text = "Tambah";
                TambahNormalButton.BackColor = Color.Goldenrod;
            }
            else
            {
                TambahNormalButton.Text = "Edit";
                TambahNormalButton.BackColor = Color.Coral;
            }


            if (JadwalKhususGrid.RowCount < 1)
            {
                TambahKhususButton.Text = "Tambah";
                TambahKhususButton.BackColor = Color.Goldenrod;
            }
            else
            {
                TambahKhususButton.Text = "Edit";
                TambahKhususButton.BackColor = Color.Coral;
            }

            AddDataToList();
        }

        #region EVENT

        private void RegisterControlEvent()
        {
            this.FormClosing += JadwalBelForm_FormClosing;
            this.Load += JadwalBelForm_Load;
            MainPanel.Resize += MainPanel_Resize;

            TambahKhususButton.Click += TambahKhususButton_Click;
            TambahNormalButton.Click += TambahNormalButton_Click;

            JadwalNormalRadio.CheckedChanged += JadwalRadio_CheckedChanged;
            JadwalKhususRadio.CheckedChanged += JadwalRadio_CheckedChanged;

            StartStopButton.Click += StartStopButton_Click;
            HariCombo.SelectedValueChanged += HariCombo_SelectedValueChanged;

            JadwalKhususRadio.Click += JadwalRadio_Click;
            JadwalNormalRadio.Click += JadwalRadio_Click;

            DeleteKhususButton.Click += DeleteButton_Click;
            DeleteNormalButton.Click += DeleteButton_Click;

            JadwalKhususToolStripMenuItem.Click += JadwalKhususToolStripMenuItem_Click;
            JadwalUjianToolStripMenuItem1.Click += JadwalUjianToolStripMenuItem1_Click;

            JadwalkanButton.Click += JadwalkanButton_Click;

            DetailJadwalLinkLabel.Click += DetailJadwalLinkLabel_Click;
        }



        private void JadwalBelForm_Load(object? sender, EventArgs e)
        {
            StartStopButton.PerformClick();
        }

        private void DetailJadwalLinkLabel_Click(object? sender, EventArgs e)
        {
            var form = new DataJadwalDiputarForm();
            _keteranganJadwal = _dataJadwalPutar.Any() ? _keteranganJadwal : "Data Kosong";
            form.LoadData(_dataJadwalPutar ?? new List<JadwalDto>(), _keteranganJadwal);
            form.ShowDialog(this);
        }

        private void JadwalBelForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Jika aplikasi ditutup, maka bel juga akan dihentikan !! \n Anda yakin ingin menutup aplikasi ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
            else
                this.mainForm.Close();
        }

        private void JadwalkanButton_Click(object? sender, EventArgs e)
        {
            if (_isRunning)
            {
                MessageBox.Show("Matikan running terlebih dahulu", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RencanakanJadwalForm jadwalkanBelForm = new RencanakanJadwalForm();
            if (jadwalkanBelForm.ShowDialog(this) == DialogResult.OK)
            {
                // AddDataToList();
            }
        }

        private void JadwalUjianToolStripMenuItem1_Click(object? sender, EventArgs e)
        {
            /*    string hari = ((JadwalModel)HariCombo.SelectedItem).Hari.ToString();
                InputDataForm inputDataForm = new InputDataForm(hari, _hariID, "Jadwal Khusus", TambahKhususButton.Text, true);
                if (inputDataForm.ShowDialog() == DialogResult.OK)
                    LoadJadwalDetil(_hariID);*/

            InputJadwalUjianForm inputUjianForm = new InputJadwalUjianForm(Convert.ToInt32(HariCombo.SelectedValue));
            if (inputUjianForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadJadwalDetil(Convert.ToInt32(HariCombo.SelectedValue));
            }
        }

        private void JadwalKhususToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            string hari = ((JadwalModel)HariCombo.SelectedItem).Hari.ToString();
            InputJadwalForm inputDataForm = new InputJadwalForm(hari, Convert.ToInt32(HariCombo.SelectedValue), "Jadwal Khusus", TambahKhususButton.Text, false);
            if (inputDataForm.ShowDialog(this) == DialogResult.OK)
                LoadJadwalDetil(Convert.ToInt32(HariCombo.SelectedValue));
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if ((button == DeleteNormalButton && JadwalNormalGrid.RowCount < 1) ||
                    (button == DeleteKhususButton && JadwalKhususGrid.RowCount < 1))
                {
                    MessageBox.Show("Tidak ada data di dalam tabel!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (MessageBox.Show("Anda yakin akan menghapus semua data didalam tabel ?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (sender as Button == DeleteNormalButton)
                        _jadwalNormalDal.Delete(Convert.ToInt32(HariCombo.SelectedValue));
                    if (sender as Button == DeleteKhususButton)
                        _jadwalKhususDal.Delete(Convert.ToInt32(HariCombo.SelectedValue));
                    LoadJadwalDetil(Convert.ToInt32(HariCombo.SelectedValue));
                }
            }
        }

        private void MainPanel_Resize(object? sender, EventArgs e)
        {
            int centerScreen = MainPanel.Width / 2;

            JadwalNormalGrid.Width = centerScreen - 20;
            JadwalKhususGrid.Width = centerScreen - 30;

            JadwalNormalGrid.Location = new Point(20, 130);
            JadwalKhususGrid.Location = new Point(centerScreen + 10, 130);

            JadwalNormalRadio.Location = new Point(20, 90);
            JadwalKhususRadio.Location = new Point(centerScreen + 10, 90);

            TambahKhususButton.Location = new Point(centerScreen + 10, MainPanel.Height - TambahKhususButton.Height - 20);

            DeleteKhususButton.Location = new Point(
                centerScreen + 10 + TambahKhususButton.Width + 10,
                MainPanel.Height - DeleteKhususButton.Height - 20
            );

            TambahNormalButton.Location = new Point(15, MainPanel.Height - TambahKhususButton.Height - 20);
            DeleteNormalButton.Location = new Point(15 + TambahNormalButton.Width + 10,
                MainPanel.Height - DeleteKhususButton.Height - 20
            );

            JadwalNormalGrid.Height = MainPanel.Height - 200;
            JadwalKhususGrid.Height = MainPanel.Height - 200;

        }

        private void JadwalRadio_Click(object? sender, EventArgs e)
        {
            if (_isRunning)
            {
                if (sender == JadwalKhususRadio)
                    JadwalNormalRadio.Checked = true;
                if (sender == JadwalNormalRadio)
                    JadwalKhususRadio.Checked = true;
                MessageBox.Show("Matikan running terlebih dahulu", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void JadwalRadio_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                foreach (var control in this.Controls.OfType<RadioButton>())
                {
                    if (control != rb && control.Checked)
                    {
                        control.Checked = false;
                    }
                }
            }
            string value = "";
            if (JadwalKhususRadio.Checked) value = "Jadwal Khusus";
            if (JadwalNormalRadio.Checked) value = "Jadwal Normal";

            int hariID = (int)HariCombo.SelectedValue;
            var data = new JadwalModel
            {
                HariID = hariID != 0 ? hariID : 0,
                JenisJadwal = value,
            };

            _jadwalDal.Update(data);
        }

        private void HariCombo_SelectedValueChanged(object? sender, EventArgs e)
        {
            var value = HariCombo.SelectedValue;
            if (value != null && int.TryParse(value.ToString(), out _hariID))
            {
                var jenis_jadwal = _jadwalDal.GetJenisJadwal(_hariID)?.JenisJadwal;
                if (jenis_jadwal == "Jadwal Normal") JadwalNormalRadio.Checked = true;
                if (jenis_jadwal == "Jadwal Khusus") JadwalKhususRadio.Checked = true;
                LoadJadwalDetil(Convert.ToInt32(HariCombo.SelectedValue));
            }
        }

        private void StartStopButton_Click(object? sender, EventArgs e)
        {
            if (StartStopButton.Text == "Start")
            {
                _hariSekarang =  DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));

                StartStopButton.Text = "Stop";
                StartStopButton.BackColor = Color.Red;
                _timer.Start();
                _cekJadwal.Start();
                _combo = ComboAktif.ComboNonAktif;

                _isRunning = true;
                AnimasiText();
                AddDataToList();
                GetJadwalDiputar();
            }

            else if (StartStopButton.Text == "Stop")
            {
                
                StartStopButton.Text = "Start";
                StartStopButton.BackColor = Color.LimeGreen;
                _timer.Stop();
                _cekJadwal.Stop();
                _combo = ComboAktif.ComboAktif;

                _isRunning = false;
                RunningLabel.Text = "Stopped . . . .";
                _dataJadwalPutar.Clear();

                ClearText();
            }
        }

        private async Task AnimasiText()
        {
            int titik = 0;

            while (_isRunning)
            {
                titik = (titik % 4) + 1;
                RunningLabel.Text = "Running " + string.Join(" ", new string('.', titik).ToCharArray());
                await Task.Delay(500);
            }
        }


        private void TambahNormalButton_Click(object? sender, EventArgs e)
        {
            string hari = ((JadwalModel)HariCombo.SelectedItem).Hari.ToString();
            InputJadwalForm inputDataForm = new InputJadwalForm(hari, Convert.ToInt32(HariCombo.SelectedValue), "Jadwal Normal", TambahNormalButton.Text, false);
            if (inputDataForm.ShowDialog(this) == DialogResult.OK)
                LoadJadwalDetil(Convert.ToInt32(HariCombo.SelectedValue));
        }

        private void TambahKhususButton_Click(object? sender, EventArgs e)
        {
            if (TambahKhususButton.Text == "Edit")
            {
                bool isUjian = Convert.ToInt32(JadwalKhususGrid.Rows[0].Cells["IsUjian"]?.Value) == 1 ? true : false;

                if (isUjian)
                {
                    InputJadwalUjianForm inputJadwalUjianForm = new InputJadwalUjianForm(Convert.ToInt32(HariCombo.SelectedValue));
                    if (inputJadwalUjianForm.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadJadwalDetil(Convert.ToInt32(HariCombo.SelectedValue));
                    }
                }
                else
                {
                    string hari = ((JadwalModel)HariCombo.SelectedItem).Hari.ToString();
                    InputJadwalForm inputDataForm = new InputJadwalForm(hari, Convert.ToInt32(HariCombo.SelectedValue), "Jadwal Khusus", TambahKhususButton.Text, false);
                    if (inputDataForm.ShowDialog(this) == DialogResult.OK)
                        LoadJadwalDetil(Convert.ToInt32(HariCombo.SelectedValue));
                }
            }
            else
            {
                contextMenuStrip2.Show(Cursor.Position);
            }
        }


        #endregion

        public class JadwalDto
        {
            public string Keterangan { get; set; }
            public int HariID { get; set; }
            public TimeSpan Waktu { get; set; }
            public string SoundName { get; set; }
            public string SoundPath { get; set; }
        }
    }
}