using BelSekolah.BelSekolahBackEnd.Dal;
using BelSekolah.BelSekolahBackEnd.Model;
using BelSekolah.BelSekolahDatabase;
using BelSekolah.BelSekolahDatabase.Helper;
using BelSekolah.BelSekolahForm.PopUpForm;
using Dapper;
using NAudio.Wave;
using NAudio.Wave.Asio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
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
        private enum ComboAktif{ ComboAktif, ComboNonAktif };
        private ComboAktif _combo = ComboAktif.ComboAktif;

        private Form mainForm;
        private readonly JadwalDal _jadwalDal;
        private readonly JadwalKhususDal _jadwalKhususDal;
        private readonly JadwalNormalDal _jadwalNormalDal;
        private readonly JadwalModel _jadwalModel;

        private int _hariID;
        private string _waktuSekarang;
        private string _hariSekarang;
        private string _jenisJadwal;
        private bool _isRunning  = false;

        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _jam;

        private List<JadwalDto> _dataJadwalPutar = new List<JadwalDto>();


        public JadwalBelForm(Form mainForm)
        {
            InitializeComponent();
            _jadwalDal = new JadwalDal();
            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalNormalDal = new JadwalNormalDal();
            _jadwalModel = new JadwalModel();

            _timer = new System.Windows.Forms.Timer();
            _jam = new System.Windows.Forms.Timer();
                
            this.mainForm = mainForm;
          
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new Size(1600, 800);

            _hariSekarang = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));    
            _waktuSekarang = DateTime.Now.ToString("HH:mm");

            RegisterControlEvent();
            InitialCombo();

            _jam.Interval = 1000;
            _jam.Tick += _jam_Tick; ;
            _jam.Start();

            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;

            LoadJadwalDetil(_hariID);

            CustomStyleGrid(JadwalNormalGrid);
            CustomStyleGrid(JadwalKhususGrid);

            

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
        }

        private void _timer_Tick(object? sender, EventArgs e) 
        {
            TimeSpan timeNow = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            var data = _dataJadwalPutar.FirstOrDefault(x => x.Waktu == timeNow);

            var stopSoundIsPlayed = _dataJadwalPutar.FirstOrDefault(x => x.Waktu > timeNow);
            if (stopSoundIsPlayed != null && (stopSoundIsPlayed.Waktu - timeNow).TotalSeconds <= 5)
            {
                StopAudio();
            }

            if (data != null)
            {
                string path = data.SoundPath;
                PlaySound(path);
                return;
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


        private void PlaySound(string soundPath)
        {
            try
            {
                audioFileReader = new AudioFileReader(soundPath);
                waveOutDevice = new WaveOutEvent();
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.Play();
                waveOutDevice.PlaybackStopped += (s, e) =>
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
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memutar suara: {ex.Message}");
            }
        }

        private void ClearText()
        {
            HariText.Clear();
            JenisJadwalText.Clear();
        }

        private void GetJadwalDiputar()
        {
            ClearText();
            HariText.Text = _hariSekarang;
            JenisJadwalText.Text = _jadwalDal.ListData().FirstOrDefault(x => x.Hari == _hariSekarang)?.JenisJadwal.ToString();
        }
        
        private void AddDataToList()
        {
            var jenis_jadwal = _jadwalDal.GetJenisJadwal(_hariID)?.JenisJadwal;
            _hariID = (int)HariCombo.SelectedValue;

            _jenisJadwal = jenis_jadwal?.ToString() ?? string.Empty;
            if (!string.IsNullOrEmpty(_jenisJadwal))
            {
                _dataJadwalPutar.Clear();

                if (_jenisJadwal == "Jadwal Normal")
                {
                    var data = _jadwalNormalDal.ListData(_hariID).Select(x => new JadwalDto
                    {
                        HariID = x.HariID,
                        Waktu = TimeSpan.Parse(x.Waktu),
                        SoundPath = x.SoundPath,
                    });
                    foreach (var item in data)
                    {
                        _dataJadwalPutar.Add(item);
                    }
                }
                else if (_jenisJadwal == "Jadwal Khusus")
                {
                    
                    var data = _jadwalKhususDal.ListData(_hariID).Select(x => new JadwalDto
                    {
                        Waktu = TimeSpan.Parse(x.Waktu),
                        SoundPath = x.SoundPath,
                    });
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
            this.FormClosed += JadwalBelForm_FormClosed;
            MainPanel.Resize += MainPanel_Resize;

            TambahKhususButton.Click += TambahKhususButton_Click;
            TambahNormalButton.Click += TambahNormalButton_Click;

            JadwalNormalGrid.CellMouseClick += JadwalNormalGrid_CellMouseClick;
            JadwalKhususGrid.CellMouseClick += JadwalKhususGrid_CellMouseClick;
    /*        deleteToolStripMenuItem1.Click += DeleteToolStripMenuItem1_Click;
            //deleteToolStripMenuItem1.Visible = false;
            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;*/

            JadwalNormalRadio.CheckedChanged += JadwalRadio_CheckedChanged;
            JadwalKhususRadio.CheckedChanged += JadwalRadio_CheckedChanged;

            StartStopButton.Click += StartStopButton_Click;
            HariCombo.SelectedValueChanged += HariCombo_SelectedValueChanged;

            JadwalKhususRadio.Click += JadwalRadio_Click;
            JadwalNormalRadio.Click += JadwalRadio_Click;

            DeleteKhususButton.Click += DeleteButton_Click;
            DeleteNormalButton.Click += DeleteButton_Click;
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
                        _jadwalNormalDal.Delete(_hariID);
                    if (sender as Button == DeleteKhususButton)
                        _jadwalKhususDal.Delete(_hariID);
                    LoadJadwalDetil(_hariID);
                }
            }
        }

        private void MainPanel_Resize(object? sender, EventArgs e)
        {
            int centerScreen = MainPanel.Width / 2;

            JadwalNormalGrid.Width = centerScreen - 20;
            JadwalKhususGrid.Width = centerScreen - 30;

            JadwalNormalGrid.Location = new Point(20, 140);
            JadwalKhususGrid.Location = new Point(centerScreen + 10, 140);

            JadwalKhususRadio.Location = new Point(centerScreen + 10, 102);

            TambahKhususButton.Location = new Point(centerScreen + 10, MainPanel.Height - TambahKhususButton.Height - 20);

            DeleteKhususButton.Location = new Point(
                centerScreen + 10 + TambahKhususButton.Width + 10,
                MainPanel.Height - DeleteKhususButton.Height - 20
            );
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

            var data = new JadwalModel
            {
                HariID = _hariID != 0 ? _hariID : 0,
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
                if (jenis_jadwal == "Jadwal Normal")JadwalNormalRadio.Checked = true;
                if (jenis_jadwal == "Jadwal Khusus") JadwalKhususRadio.Checked = true;
                LoadJadwalDetil(_hariID);
            }
        }

        private void StartStopButton_Click(object? sender, EventArgs e)
        {
            if (StartStopButton.Text == "Start")
            {
                StartStopButton.Text = "Stop";
                StartStopButton.BackColor = Color.Red;
                _timer.Start();
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

      /*  private void EditToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            string hari = ((JadwalModel)HariCombo.SelectedItem).Hari.ToString();

            if (_gridAktif == GridAktif.JadwalNormal)
            {
                InputDataForm inputDataForm = new InputDataForm(hari, _hariID, "Jadwal Normal", "Edit");
                if (inputDataForm.ShowDialog() == DialogResult.OK)
                    LoadJadwalDetil(_hariID);
            }
            else if (_gridAktif == GridAktif.JadwalKhusus)
            {
                InputDataForm inputDataForm = new InputDataForm(hari, _hariID, "Jadwal Khusus", "Edit");
                if (inputDataForm.ShowDialog() == DialogResult.OK)
                    LoadJadwalDetil(_hariID);
            }

            LoadJadwalDetil(_hariID);
        }

        private void DeleteToolStripMenuItem1_Click(object? sender, EventArgs e)
        {
            if (_gridAktif == GridAktif.JadwalNormal)
            {
                if (MessageBox.Show("Anda yakin ingin menghapus data Jadwal Normal?", "Perhatian", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int jadwalNormalID = Convert.ToInt32(JadwalNormalGrid.CurrentRow.Cells["JadwalNormalID"].Value);
                    _jadwalNormalDal.Delete(jadwalNormalID);
                    LoadJadwalDetil(_hariID);
                }
            }
            else if (_gridAktif == GridAktif.JadwalKhusus)
            {
                if (MessageBox.Show("Anda yakin ingin menghapus data Jadwal Khusus?", "Perhatian", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int jadwalKhususID = Convert.ToInt32(JadwalKhususGrid.CurrentRow.Cells["JadwalKhususID"].Value);
                    _jadwalKhususDal.Delete(jadwalKhususID);
                    LoadJadwalDetil(_hariID);
                }
            }
        }*/

        private void JadwalKhususGrid_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _gridAktif = GridAktif.JadwalKhusus;

                JadwalKhususGrid.ClearSelection();
                JadwalKhususGrid.CurrentCell = JadwalKhususGrid[e.ColumnIndex, e.RowIndex];
                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void JadwalNormalGrid_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _gridAktif = GridAktif.JadwalNormal;

                JadwalNormalGrid.ClearSelection();
                JadwalNormalGrid.CurrentCell = JadwalNormalGrid[e.ColumnIndex, e.RowIndex];
                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void TambahNormalButton_Click(object? sender, EventArgs e)
        {
            string hari = ((JadwalModel)HariCombo.SelectedItem).Hari.ToString();
            InputDataForm inputDataForm = new InputDataForm(hari, _hariID, "Jadwal Normal", TambahNormalButton.Text);
            if (inputDataForm.ShowDialog() == DialogResult.OK)
                LoadJadwalDetil(_hariID);
        }

        private void TambahKhususButton_Click(object? sender, EventArgs e)
        {
            string hari = ((JadwalModel)HariCombo.SelectedItem).Hari.ToString();
            InputDataForm inputDataForm = new InputDataForm(hari, _hariID, "Jadwal Khusus", TambahKhususButton.Text);
            if (inputDataForm.ShowDialog() == DialogResult.OK)
                LoadJadwalDetil(_hariID);
        }


        private void JadwalBelForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

     
        #endregion

        public class JadwalDto
        {
            public int HariID { get; set; }
            public TimeSpan Waktu { get; set; }
            public string SoundPath { get; set; }
        }
    }
}