using BelSekolah.BelSekolahBackEnd.Dal;
using BelSekolah.BelSekolahBackEnd.Model;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah.BelSekolahForm.PopUpForm
{
    public partial class InputDataForm : Form
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private readonly JadwalKhususDal _jadwalKhususDal;
        private readonly JadwalNormalDal _jadwalNormalDal;
        private int _hariID;
        private string _jenisJadwal;
        private bool _isPlaying = false;

        private List<JadwalPutarDto> _jadwalPutarDto = new List<JadwalPutarDto>();

        public InputDataForm(string Hari, int HariID, string JenisJadwal)
        {
            InitializeComponent();

            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalNormalDal = new JadwalNormalDal();
            _hariID = HariID;
            _jenisJadwal = JenisJadwal;

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            HariText.Text = $"{Hari} - {JenisJadwal}";
            InitialPlayButton();
            RegisterControlEvent();

        }


        private void InitialPlayButton()
        {
            List<Button> buttons = new List<Button>
            {
                PlayJam0Button,
                PlayJam1Button,
                PlayJam2Button,
                PlayJam3Button,
                PlayJam4Button,
                PlayJam5Button,
                PlayJam6Button,
                PlayJam7Button,
                PlayJam8Button,
                PlayJam9Button,
                PlayJam10Button,
                PlayJamKepulanganButton,
                PlayJamIstirahat1Button,
                PlayJamIstirahat2Button

            };

            foreach (Button button in buttons)
            {
                button.Text = "▶";
            }
        }

        private void GetData()
        {
            if (_jenisJadwal == "Jadwal Khusus")
            {
                var khusus = _jadwalKhususDal.ListData(_hariID);
            }
        }

        private void AdddataToDictionary()
        {
            if (_jenisJadwal == "Jadwal Normal")
            {
                var normal = _jadwalNormalDal.ListData(_hariID).Select(x => new JadwalPutarDto
                {
                    HariID = x.HariID,
                    JadwalID = x.JadwalNormalID,
                    Keterangan = x.Keterangan,
                    Waktu = x.Waktu ?? "",
                    SoundName = x.SoundName ?? "",
                    SoundPath = x.SoundPath ?? "",
                }).ToList() ?? new List<JadwalPutarDto>();
            }
        }

        private void SaveData()
        {
            List<Label> label = new List<Label>()
            {
                Jam0Label,Jam1Label,Jam2Label,Jam3Label,Jam4Label,Jam5Label,Jam6Label,Jam7Label,
                Jam8Label,Jam9Label,Jam10Label,JamIstirahat1Label, JamIstirahat2Label
            };
            List<DateTimePicker> datePicker = new List<DateTimePicker>()
            {
                Jam0Picker, Jam1Picker, Jam2Picker, Jam3Picker, Jam4Picker, Jam5Picker, Jam6Picker,
                Jam7Picker, Jam8Picker, Jam9Picker, Jam10Picker,JamIstirahat1Picker,JamIstirahat2Picker
            };

            var khusus = new JadwalKhususModel
            {
                HariID = _hariID,
                Keterangan =  Jam0Label.ToString(),
                Waktu = Jam0Picker.Value.ToString(),
                SoundName = Jam0Text.ToString()
            };
        }

        private void RegisterControlEvent()
        {
            BrowseJam0Button.Click += BrowseButton_Click;
            BrowseJam1Button.Click += BrowseButton_Click;
            BrowseJam2Button.Click += BrowseButton_Click;
            BrowseJam3Button.Click += BrowseButton_Click;
            BrowseIstirahat1Button.Click += BrowseButton_Click;
            BrowseJam4Button.Click += BrowseButton_Click;
            BrowseJam5Button.Click += BrowseButton_Click;
            BrowseJam6Button.Click += BrowseButton_Click;
            BrowseIstirahat2Button.Click += BrowseButton_Click;
            BrowseJam7Button.Click += BrowseButton_Click;
            BrowseJam8Button.Click += BrowseButton_Click;
            BrowseJam10Button.Click += BrowseButton_Click;
            BrowseKepulanganButton.Click += BrowseButton_Click;


            PlayJam0Button.Click += PlayJamButton_Click;
            PlayJam1Button.Click += PlayJamButton_Click;
            PlayJam2Button.Click += PlayJamButton_Click;
            PlayJam3Button.Click += PlayJamButton_Click;
            PlayJamIstirahat1Button.Click += PlayJamButton_Click;
            PlayJam4Button.Click += PlayJamButton_Click;
            PlayJam5Button.Click += PlayJamButton_Click;
            PlayJam6Button.Click += PlayJamButton_Click;
            PlayJamIstirahat2Button.Click += PlayJamButton_Click;
            PlayJam7Button.Click += PlayJamButton_Click;
            PlayJam8Button.Click += PlayJamButton_Click;
            PlayJam10Button.Click += PlayJamButton_Click;
            PlayJamKepulanganButton.Click += PlayJamButton_Click;

        }

        private void PlayJamButton_Click(object? sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == null) return;

            TextBox textbox = (TextBox)panel2.Controls.OfType<TextBox>().FirstOrDefault(x => x.Tag?.ToString() == button.Tag?.ToString());
            if (textbox == null) return;

            if (textbox.Text != null)
            {
                string FileName = textbox.Text;
                string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", FileName);

                if (File.Exists(FilePath))
                {

                    if (_isPlaying)
                    {
                        StopAudio();
                        button.Text = "▶";
                    }
                    else
                    {
                        PlayAudio(FilePath);
                        button.Text = "■";
                    }
                }
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
                };
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.Play();
                _isPlaying = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memutar suara: {ex.Message}", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Button button = (Button)sender;
            if (button == null) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sound File (*.mp3)|*.mp3";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string SoundPath = openFileDialog.FileName;
                string SoundName = Path.GetFileName(SoundPath);

            TextBox textBox = (TextBox)panel2.Controls.OfType<TextBox>().FirstOrDefault(x => x.Tag?.ToString() == button.Tag?.ToString());
                if (textBox != null)
                {
                    textBox.Text = SoundName;
                }
                SelectAndReplace(SoundPath);
            }
        }

        private void SelectAndReplace(string SoundPath)
        {
            string tujuanFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound");

            if (!Directory.Exists(tujuanFolder))
            {
                Directory.CreateDirectory(tujuanFolder);
            }
            string tujuanPath = Path.Combine(tujuanFolder, Path.GetFileName(SoundPath));
            File.Copy(SoundPath, tujuanPath, true);
        }


        public class JadwalPutarDto
        {
            public int HariID { get; set; }
            public int JadwalID { get; set; }
            public string Keterangan { get; set; }
            public string Waktu { get; set; }
            public string SoundName { get; set; }
            public string SoundPath { get; set; }
        }

    }
}