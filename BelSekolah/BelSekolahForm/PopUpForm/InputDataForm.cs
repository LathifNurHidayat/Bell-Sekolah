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
        private string _status;
        private bool _isPlaying = false;

        private List<JadwalPutarDto> _jadwalPutarDto = new List<JadwalPutarDto>();

        public InputDataForm(string Hari, int HariID, string JenisJadwal, string Status)
        {
            InitializeComponent();

            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalNormalDal = new JadwalNormalDal();
            _hariID = HariID;
            _jenisJadwal = JenisJadwal;
            _status = Status;

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            HariText.Text = $"{Hari} - {JenisJadwal}";
            InitialPlayButton();
            RegisterControlEvent();

            if (_status == "Edit")
            {
                GetData();
            }
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
            List<Label> labelControls = new List<Label>
            {
                Jam0Label, Jam1Label, Jam2Label, Jam3Label, JamIstirahat1Label, Jam4Label,
                Jam5Label, Jam6Label, JamIstirahat2Label, Jam7Label, Jam8Label, Jam9Label,
                Jam10Label, JamKepulanganLabel
            };

            List<DateTimePicker> datePickerControls = new List<DateTimePicker>
            {
                Jam0Picker, Jam1Picker, Jam2Picker, Jam3Picker, JamIstirahat1Picker, Jam4Picker,
                Jam5Picker, Jam6Picker, JamIstirahat2Picker, Jam7Picker, Jam8Picker, Jam9Picker,
                Jam10Picker, JamKepulanganPicker
            };

            List<TextBox> textBoxControls = new List<TextBox>
            {
                Jam0Text, Jam1Text, Jam2Text, Jam3Text, JamIstirahat1Text, Jam4Text, Jam5Text,
                Jam6Text, JamIstirahat2Text, Jam7Text, Jam8Text, Jam9Text, Jam10Text, JamKepulanganText
            };

            List<JadwalPutarDto> data = new List<JadwalPutarDto>();

            if (_jenisJadwal == "Jadwal Khusus")
            {
                data = _jadwalKhususDal.ListData(_hariID).Select(x => new JadwalPutarDto
                {
                    HariID = x.HariID,
                    JadwalID = x.JadwalKhususID,
                    Keterangan = x.Keterangan,
                    Waktu = x.Waktu ?? "",
                    SoundName = x.SoundName ?? "",
                    SoundPath = x.SoundPath ?? ""
                }).ToList();
            }
            else if (_jenisJadwal == "Jadwal Normal")
            {
                data = _jadwalNormalDal.ListData(_hariID).Select(x => new JadwalPutarDto
                {
                    HariID = x.HariID,
                    JadwalID = x.JadwalNormalID,
                    Keterangan = x.Keterangan,
                    Waktu = x.Waktu ?? "",
                    SoundName = x.SoundName ?? "",
                    SoundPath = x.SoundPath ?? ""
                }).ToList();
            }

            for (int i = 0; i < data.Count && i < labelControls.Count; i++)
            {
                var item = data[i];
                labelControls[i].Text = item.Keterangan;
                datePickerControls[i].Value = DateTime.TryParse(item.Waktu, out var waktu) ? waktu : DateTime.Now;
                textBoxControls[i].Text = item.SoundName;
            }
        }


        private void SaveData()
        {
            List<Label> labels = new List<Label>()
            {
                Jam0Label, Jam1Label, Jam2Label, Jam3Label, JamIstirahat1Label, Jam4Label,
                Jam5Label, Jam6Label, JamIstirahat2Label, Jam7Label, Jam8Label, Jam9Label,
                Jam10Label, JamKepulanganLabel
            };

            List<DateTimePicker> datePickers = new List<DateTimePicker>()
            {
                Jam0Picker, Jam1Picker, Jam2Picker, Jam3Picker, JamIstirahat1Picker, Jam4Picker,
                Jam5Picker, Jam6Picker, JamIstirahat2Picker, Jam7Picker, Jam8Picker, Jam9Picker,
                Jam10Picker, JamKepulanganPicker
            };

            List<TextBox> textBoxes = new List<TextBox>()
            {
                Jam0Text, Jam1Text, Jam2Text, Jam3Text, JamIstirahat1Text, Jam4Text,
                Jam5Text, Jam6Text, JamIstirahat2Text, Jam7Text, Jam8Text, Jam9Text,
                Jam10Text, JamKepulanganText
            };

            var jadwalData = new List<JadwalPutarDto>();

            for (int i = 0; i < labels.Count; i++)
            {
                jadwalData.Add(new JadwalPutarDto
                {
                    HariID = _hariID,
                    Keterangan = labels[i].Text,
                    Waktu = datePickers[i].Value.ToString("HH:mm"),
                    SoundName = textBoxes[i].Text,
                    SoundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", textBoxes[i].Text)
                });
            }

            if (_status == "Tambah")
            {
                if (_jenisJadwal == "Jadwal Normal")
                {
                    foreach (var jadwal in jadwalData)
                    {
                        var normalModel = new JadwalNormalModel
                        {
                            HariID = jadwal.HariID,
                            Keterangan = jadwal.Keterangan,
                            Waktu = jadwal.Waktu,
                            SoundName = jadwal.SoundName,
                            SoundPath = jadwal.SoundPath
                        };

                        _jadwalNormalDal.Insert(normalModel);
                    }
                }
                else if (_jenisJadwal == "Jadwal Khusus")
                {
                    foreach (var jadwal in jadwalData)
                    {
                        var khususModel = new JadwalKhususModel
                        {
                            HariID = jadwal.HariID,
                            Keterangan = jadwal.Keterangan,
                            Waktu = jadwal.Waktu,
                            SoundName = jadwal.SoundName,
                            SoundPath = jadwal.SoundPath
                        };

                        _jadwalKhususDal.Insert(khususModel);
                    }
                }

                if (_status == "Edit")
                {
                    if (_jenisJadwal == "Jadwal Normal")
                    {
                        foreach (var jadwal in jadwalData)
                        {
                            var normalModel = new JadwalNormalModel
                            {
                                HariID = jadwal.HariID,
                                Keterangan = jadwal.Keterangan,
                                Waktu = jadwal.Waktu,
                                SoundName = jadwal.SoundName,
                                SoundPath = jadwal.SoundPath
                            };

                            _jadwalNormalDal.Update(normalModel);
                        }
                    }
                    else if (_jenisJadwal == "Jadwal Khusus")
                    {
                        foreach (var jadwal in jadwalData)
                        {
                            var khususModel = new JadwalKhususModel
                            {
                                HariID = jadwal.HariID,
                                Keterangan = jadwal.Keterangan,
                                Waktu = jadwal.Waktu,
                                SoundName = jadwal.SoundName,
                                SoundPath = jadwal.SoundPath
                            };

                            _jadwalKhususDal.Update(khususModel);
                        }
                    }
                }

            }
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
            BrowseJam9Button.Click += BrowseButton_Click;
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
            PlayJam9Button.Click += PlayJamButton_Click;
            PlayJam10Button.Click += PlayJamButton_Click;
            PlayJamKepulanganButton.Click += PlayJamButton_Click;

            UbahButton.Click += UbahButton_Click;
            SimpanButton.Click += SimpanButton_Click;

        }

        private void SimpanButton_Click(object? sender, EventArgs e)
        {
            SaveData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UbahButton_Click(object? sender, EventArgs e)
        {
            string mulai = "";
            int interval = 0;
            int istirahat_1 = 0;
            int istirahat_2 = 0;

            IntervalForm intervalForm = new IntervalForm();
            if (intervalForm.ShowDialog(this) == DialogResult.OK)
            {
                mulai = intervalForm.mulai;
                interval = intervalForm.interval;
                istirahat_1 = intervalForm.istirahat_1;
                istirahat_2 = intervalForm.istirahat_2;
            }


            List<DateTimePicker> datePickerControls = new List<DateTimePicker>
            {
                Jam0Picker, Jam1Picker, Jam2Picker, Jam3Picker, JamIstirahat1Picker, Jam4Picker,
                Jam5Picker, Jam6Picker, JamIstirahat2Picker, Jam7Picker, Jam8Picker, Jam9Picker,
                Jam10Picker, JamKepulanganPicker
            };

            DateTimePicker selectedPicker = datePickerControls.FirstOrDefault( x => x.Name.Equals(mulai, StringComparison.OrdinalIgnoreCase));
            if (selectedPicker == null) return;

            DateTime startTime = selectedPicker.Value;

            foreach (var picker in datePickerControls)
            {
                if (picker == JamIstirahat1Picker)
                {
                    picker.Value = startTime;
                    startTime = startTime.AddMinutes(istirahat_1);
                }
                else if (picker == JamIstirahat2Picker)
                {
                    picker.Value = startTime;
                    startTime = startTime.AddMinutes(istirahat_2);
                }
                else
                {
                    picker.Value = startTime;
                    startTime = startTime.AddMinutes(interval);
                }
            }
            MessageBox.Show("Interval waktu berhasil diubah!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void PlayJamButton_Click(object? sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == null) return;

            TextBox textbox = (TextBox)panel2.Controls.OfType<TextBox>().FirstOrDefault(x => x.Tag?.ToString() == button.Tag?.ToString());
            if (textbox?.Text == string.Empty)
            {
                MessageBox.Show("Masukan data sound terlebih dahulu", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textbox != null && textbox.Text != null)
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