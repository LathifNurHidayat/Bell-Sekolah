using BelSekolah.BelSekolahBackEnd.Dal;
using BelSekolah.BelSekolahBackEnd.Model;
using NAudio.MediaFoundation;
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
        private string _hariName;
        private string _jenisJadwal;
        private string _status;
        private bool _isUjian;
        private bool _isPlaying = false;

        private List<DateTimePicker> _datePickerControls = new List<DateTimePicker>();
        private List<JadwalPutarDto> _jadwalPutarDto = new List<JadwalPutarDto>();
        private List<TextBox> _textBoxControls = new List<TextBox>();


        public InputDataForm(string Hari, int HariID, string JenisJadwal, string Status, bool Ujian)
        {
            InitializeComponent();

            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalNormalDal = new JadwalNormalDal();
            _hariID = HariID;
            _hariName = Hari;
            _jenisJadwal = JenisJadwal;
            _status = Status;
            _isUjian = Ujian;

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            HariText.Text = $"{Hari} - {JenisJadwal}";
            InitialComponenTolbox();
            RegisterControlEvent();

            if (_status == "Edit")
                GetData();
            else
                DefaultSound();
        }

        private void DefaultSound()
        {
            Dictionary<string, TextBox> soundMappings = new Dictionary<string, TextBox>();
            string soundFolder = string.Empty;

            if (_isUjian)
            {
                soundFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Ujian");
            }
            else
            {
                soundFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Pelajaran");
            }


            if (_hariName == "Jumat")
            {
                Dictionary<string, TextBox> sound = new Dictionary<string, TextBox>
                {
                    { "Jam Ke - 1.mp3", Jam1Text },
                    { "Jam Ke - 2.mp3", Jam2Text },
                    { "Jam Ke - 3.mp3", Jam3Text },
                    { "Jam Istirahat Ke - 1.mp3", JamIstirahat1Text },
                    { "Jam Ke - 4.mp3", Jam4Text },
                    { "Jam Ke - 5.mp3", Jam5Text },
                    { "Jam Ke - 6.mp3", Jam6Text },
                    { "Jam Istirahat Ke - 2.mp3", JamIstirahat2Text },
                    { "Jam Ke - 7.mp3", Jam7Text },
                    { "Jam Ke - 8.mp3", Jam8Text },
                    { "Akhir Pekan.mp3", JamKepulanganText }
                };
                foreach (var item in sound)
                {
                    soundMappings.Add(item.Key, item.Value);
                }
            }

            else
            {
                Dictionary<string, TextBox> sound = new Dictionary<string, TextBox>
                {
                    { "Jam Ke - 1.mp3", Jam1Text },
                    { "Jam Ke - 2.mp3", Jam2Text },
                    { "Jam Ke - 3.mp3", Jam3Text },
                    { "Jam Istirahat Ke - 1.mp3", JamIstirahat1Text },
                    { "Jam Ke - 4.mp3", Jam4Text },
                    { "Jam Ke - 5.mp3", Jam5Text },
                    { "Jam Ke - 6.mp3", Jam6Text },
                    { "Jam Istirahat Ke - 2.mp3", JamIstirahat2Text },
                    { "Jam Ke - 7.mp3", Jam7Text },
                    { "Jam Ke - 8.mp3", Jam8Text },
                    { "Jam Ke - 9.mp3", Jam9Text },
                    { "Jam Ke - 10.mp3", Jam10Text },
                    { "Akhir Jam Pelajaran.mp3", JamKepulanganText }
                };
                foreach (var item in sound)
                {
                    soundMappings.Add(item.Key, item.Value);
                }
            }


            if (Directory.Exists(soundFolder))
            {
                var soundFiles = Directory.GetFiles(soundFolder, "*.mp3");

                List<JadwalPutarDto> jadwalSound = new List<JadwalPutarDto>();

                foreach (var soundPath in soundFiles)
                {
                    var soundName = Path.GetFileName(soundPath);

                    if (soundMappings.TryGetValue(soundName, out TextBox targetTextBox))
                    {
                        targetTextBox.Text = soundName;

                        jadwalSound.Add(new JadwalPutarDto
                        {
                            SoundName = soundName,
                            SoundPath = soundPath
                        });
                    }

                }
            }
            else
            {
                MessageBox.Show("Folder sound tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void InitialComponenTolbox()
        {
            List<Button> buttons = new List<Button>
            {
                PlayJam0Button, PlayJam1Button, PlayJam2Button, PlayJam3Button, PlayJam4Button,
                PlayJam5Button, PlayJam6Button, PlayJam7Button, PlayJam8Button, PlayJam9Button,
                PlayJam10Button, PlayJamKepulanganButton, PlayJamIstirahat1Button, PlayJamIstirahat2Button
            };

            foreach (Button button in buttons)
            {
                button.Text = "▶";
            }

            List<DateTimePicker> datePickerControls = new List<DateTimePicker>
            {
                Jam0Picker, Jam1Picker, Jam2Picker, Jam3Picker, JamIstirahat1Picker, Jam4Picker,
                Jam5Picker, Jam6Picker, JamIstirahat2Picker, Jam7Picker, Jam8Picker, Jam9Picker,
                Jam10Picker, JamKepulanganPicker
            };
            _datePickerControls.AddRange(datePickerControls);

            foreach (DateTimePicker picker in _datePickerControls)
            {
                picker.Value = DateTime.Today;
            }

            List<TextBox> textBox = new List<TextBox>
            {
                Jam0Text, Jam1Text, Jam2Text, Jam3Text, JamIstirahat1Text, Jam4Text, Jam5Text,
                Jam6Text, JamIstirahat2Text, Jam7Text, Jam8Text, Jam9Text, Jam10Text, JamKepulanganText
            };
            _textBoxControls.AddRange(textBox);
        }


        private void GetData()
        {
            List<Label> labelControls = new List<Label>
            {
                Jam0Label, Jam1Label, Jam2Label, Jam3Label, JamIstirahat1Label, Jam4Label,
                Jam5Label, Jam6Label, JamIstirahat2Label, Jam7Label, Jam8Label, Jam9Label,
                Jam10Label, JamKepulanganLabel
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

            foreach (var item in data)
            {
                for (int i = 0; i <= labelControls.Count; i++)
                {
                    if (labelControls[i].Text == item.Keterangan)
                    {
                        _datePickerControls[i].Value = DateTime.TryParse(item.Waktu, out DateTime waktu) ? waktu : DateTime.Today;
                        _textBoxControls[i].Text = item.SoundName;
                        break; 
                    }
                }
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
                if (datePickers[i].Value.TimeOfDay != TimeSpan.Zero && !string.IsNullOrWhiteSpace(textBoxes[i].Text))
                {
                    jadwalData.Add(new JadwalPutarDto
                    {
                        JadwalID = _jadwalPutarDto.FirstOrDefault(x => x.Keterangan == labels[i].Text)?.JadwalID ?? default(int),
                        HariID = _hariID,
                        Keterangan = labels[i].Text,
                        Waktu = datePickers[i].Value.ToString("HH:mm"),
                        SoundName = textBoxes[i].Text,
                        SoundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", textBoxes[i].Text)
                    });
                }
            }


            if (_status == "Tambah")
            {
                if (_jenisJadwal == "Jadwal Normal")
                {
                    foreach (var jadwal in jadwalData)
                    {
                        _jadwalNormalDal.Insert(new JadwalNormalModel
                        {
                            HariID = jadwal.HariID,
                            Keterangan = jadwal.Keterangan,
                            Waktu = jadwal.Waktu,
                            SoundName = jadwal.SoundName,
                            SoundPath = jadwal.SoundPath
                        });
                    }
                }
                else if (_jenisJadwal == "Jadwal Khusus")
                {
                    foreach (var jadwal in jadwalData)
                    {
                        _jadwalKhususDal.Insert(new JadwalKhususModel
                        {
                            HariID = jadwal.HariID,
                            Keterangan = jadwal.Keterangan,
                            Waktu = jadwal.Waktu,
                            SoundName = jadwal.SoundName,
                            SoundPath = jadwal.SoundPath
                        });
                    }
                }
            }
            else if (_status == "Edit")
            {
                if (_jenisJadwal == "Jadwal Normal")
                {
                    _jadwalNormalDal.Delete(_hariID);

                    foreach (var jadwal in jadwalData)
                    {
                        _jadwalNormalDal.Insert(new JadwalNormalModel
                        {
                            HariID = jadwal.HariID,
                            Keterangan = jadwal.Keterangan,
                            Waktu = jadwal.Waktu,
                            SoundName = jadwal.SoundName,
                            SoundPath = jadwal.SoundPath
                        });
                    }
                }
                else if (_jenisJadwal == "Jadwal Khusus")
                {
                    _jadwalKhususDal.Delete(_hariID);

                    foreach (var jadwal in jadwalData)
                    {
                        _jadwalKhususDal.Insert(new JadwalKhususModel
                        {
                            HariID = jadwal.HariID,
                            Keterangan = jadwal.Keterangan,
                            Waktu = jadwal.Waktu,
                            SoundName = jadwal.SoundName,
                            SoundPath = jadwal.SoundPath
                        });
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

            this.FormClosed += InputDataForm_FormClosed;
        }

        private void InputDataForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            StopAudio();
        }

        private void SimpanButton_Click(object? sender, EventArgs e)
        {
            bool isNull = false;

            foreach(var picker in _datePickerControls)
            {
                if (picker.Value == DateTime.Today)
                {
                    isNull = true;
                    break;
                }
            }

            foreach (var text in _textBoxControls)
            {
                if (text.Text == string.Empty)
                {
                    isNull = true;
                    break;
                }
            }

            if (isNull)
            {
                if (MessageBox.Show("Jika terdapat data kosong pada salah satu baris, data tersebut tidak akan disimpan! \nApakah Anda ingin tetap menyimpan data lainnya?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SaveData();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                SaveData();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void UbahButton_Click(object? sender, EventArgs e)
        {
            StopAudio();

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

            DateTimePicker selectedPicker = datePickerControls.FirstOrDefault(x => x.Name.Equals(mulai, StringComparison.OrdinalIgnoreCase));

            if (selectedPicker == null) return;

            int startIndex = datePickerControls.IndexOf(selectedPicker);
            if (startIndex == -1) return;

            DateTime startTime = selectedPicker.Value;

            for (int i = startIndex; i < datePickerControls.Count; i++)
            {
                var picker = datePickerControls[i];

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
                string FilePath = string.Empty;

                if (_isUjian)
                    FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Ujian",  FileName);
                else
                    FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Pelajaran", FileName);

                if (File.Exists(FilePath))
                {
                    if (_isPlaying)
                    {
                        StopAudio();
                        button.Text = "▶";
                    }
                    else
                    {
                        PlayAudio(FilePath, button);
                        button.Text = "■";
                    }
                }
            }
        }


        private void PlayAudio(string filePath, Button button)
        {
            try
            {
                StopAudio();
                audioFileReader = new AudioFileReader(filePath);
                waveOutDevice = new WaveOutEvent();
                waveOutDevice.PlaybackStopped += (s, e) =>
                {
                    StopAudio();
                    button.Text = "▶";
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
            StopAudio();
            if (button == null) return;


            DateTimePicker picker = (DateTimePicker)panel2.Controls.OfType<DateTimePicker>().FirstOrDefault(x => x.Tag?.ToString() == button.Tag?.ToString());
            if (picker?.Value == DateTime.Today)
            {
                MessageBox.Show("Mohon atur jam terlebih dahulu !","Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sound File (*.mp3)|*.mp3";

            if (_isUjian)
                openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Ujian");
            else
                openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Pelajaran");


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
                MessageBox.Show(SoundPath);
            }
        }

        private void SelectAndReplace(string SoundPath)
        {
            if (_isUjian)
            {
                string tujuanFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Ujian");

                if (!Directory.Exists(tujuanFolder))
                {
                    Directory.CreateDirectory(tujuanFolder);
                }
                string tujuanPath = Path.Combine(tujuanFolder, Path.GetFileName(SoundPath));
                File.Copy(SoundPath, tujuanPath, true);
            }
            else
            {
                string tujuanFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Jam Pelajaran");

                if (!Directory.Exists(tujuanFolder))
                {
                    Directory.CreateDirectory(tujuanFolder);
                }
                string tujuanPath = Path.Combine(tujuanFolder, Path.GetFileName(SoundPath));
                File.Copy(SoundPath, tujuanPath, true);
            }
            
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