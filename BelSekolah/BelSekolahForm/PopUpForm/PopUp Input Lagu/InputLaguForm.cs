using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah.BelSekolahForm.PopUpForm.PopUp_Input_Lagu
{
    public partial class InputLaguForm : Form
    {
        public string SoundName { get; set; }
        private List<TextBox> listTextBox = new List<TextBox>();
        private string _soundName;

        public InputLaguForm(string SoundName)
        {
            InitializeComponent();
            _soundName = SoundName;
            InitialTextBox();
            RegisterControlEvent();
            listTextBox.AddRange(new[] { Lagu1Text, Lagu2Text, Lagu3Text, Lagu4Text, Lagu5Text, Lagu6Text });
        }

        private void RegisterControlEvent()
        {
            SimpanButton.Click += SimpanButton_Click;

            BrowseLagu1Button.Click += BrowseLaguButton_Click;
            BrowseLagu2Button.Click += BrowseLaguButton_Click;
            BrowseLagu3Button.Click += BrowseLaguButton_Click;
            BrowseLagu4Button.Click += BrowseLaguButton_Click;
            BrowseLagu5Button.Click += BrowseLaguButton_Click;
            BrowseLagu6Button.Click += BrowseLaguButton_Click;

            DeleteLagu1Button.Click += DeleteLaguButton_Click;
            DeleteLagu2Button.Click += DeleteLaguButton_Click;
            DeleteLagu3Button.Click += DeleteLaguButton_Click;
            DeleteLagu4Button.Click += DeleteLaguButton_Click;
            DeleteLagu5Button.Click += DeleteLaguButton_Click;
            DeleteLagu6Button.Click += DeleteLaguButton_Click;
        }

        private void DeleteLaguButton_Click(object? sender, EventArgs e)
        {
            Button button = sender as Button;
            
            if (!string.IsNullOrWhiteSpace(listTextBox.FirstOrDefault(x => x.Tag == button.Tag).Text))
                {
                listTextBox.FirstOrDefault(x => x.Tag == button.Tag).Clear();
                }
        }

        private void BrowseLaguButton_Click(object? sender, EventArgs e)
        {
            Button button = sender as Button;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sound (*.mp3) |*.mp3";
            string folderApk = openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Lagu Lagu");

            string soundPath = string.Empty;
            string soundName = string.Empty;

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                soundPath = openFileDialog.FileName;
                soundName = Path.GetFileName(soundPath);

                listTextBox.FirstOrDefault(x => x.Tag == button.Tag).Text = soundName;

                if (!Directory.Exists(folderApk)) 
                    Directory.CreateDirectory(folderApk);

                string tujuanCopy = Path.Combine(folderApk, soundName);

                if (!File.Exists(tujuanCopy))
                {
                    File.Copy(soundPath, tujuanCopy);
                }
            }
        }

        private void SimpanButton_Click(object? sender, EventArgs e)
        {
            var TextBox = new[] {Lagu1Text.Text, Lagu2Text.Text, Lagu3Text.Text, Lagu4Text.Text ,Lagu5Text.Text , Lagu6Text.Text };

            SoundName = string.Join("|", TextBox.Where(x => !string.IsNullOrWhiteSpace(x)));
            this.DialogResult = DialogResult.OK;
        }

        private void InitialTextBox()
        {
            if (string.IsNullOrEmpty(_soundName)) return;

            string[] Sound = _soundName.Split('|');
            var textBoxes = new[] { Lagu1Text, Lagu2Text, Lagu3Text, Lagu4Text, Lagu5Text, Lagu6Text };

            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Text = i < Sound.Length ? Sound[i] : string.Empty;
            }

        }
    }
} 