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
        public string NamaSound { get; set; }

        public InputLaguForm()
        {
            InitializeComponent();
            InitialTextBox();

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
            
            List<TextBox> listTextBox = new List<TextBox>()
            {
                Lagu1Text,Lagu2Text, Lagu3Text,
                Lagu4Text,Lagu5Text,Lagu6Text
            };

            if (!string.IsNullOrWhiteSpace(listTextBox.FirstOrDefault(x => x.Tag == button.Tag).Text))
                {
                listTextBox.FirstOrDefault(x => x.Tag == button.Tag).Clear();
                }
        }

        private void BrowseLaguButton_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sound (*.mp3) |*.mp3";
            openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound", "Lagu Lagu");

            string soundPath = string.Empty;
            string soundName = string.Empty;

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                soundPath = openFileDialog.FileName;
                soundName = Path.GetFileName(soundPath);

                 
            }
            

        }

        private void SimpanButton_Click(object? sender, EventArgs e)
        {
            string Sound = string.Empty;
            var TextBox = new[] {Lagu1Text.Text, Lagu2Text.Text, Lagu3Text.Text, Lagu4Text.Text ,Lagu5Text.Text , Lagu6Text.Text };

            Sound = string.Join("|", TextBox.Where(x => !string.IsNullOrWhiteSpace(x)));
            this.DialogResult = DialogResult.OK;
        }

        private void InitialTextBox()
        {
            string[] Sound = NamaSound.Split('|');
            Lagu1Text.Text = Sound[0] ?? string.Empty;
            Lagu2Text.Text = Sound[1] ?? string.Empty;
            Lagu3Text.Text = Sound[2] ?? string.Empty;
            Lagu4Text.Text = Sound[3] ?? string.Empty;
            Lagu5Text.Text = Sound[4] ?? string.Empty;
            Lagu6Text.Text = Sound[5] ?? string.Empty;  
        }
    }
} 
