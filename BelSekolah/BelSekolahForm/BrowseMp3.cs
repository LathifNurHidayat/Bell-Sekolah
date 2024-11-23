using BelSekolah.BelSekolahDatabase;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah.BelSekolahForm
{
    public partial class BrowseMp3 : Form
    {
        public BrowseMp3()
        {
            InitializeComponent();
            database db = new database();
            db.CreateTable();
        }
        private void BrowseMp3_Load(object sender, EventArgs e)
        { 
            evenbutton();
          
            DisplaySavedSounds();
        }

        private void evenbutton()
        {
            browse_button.Click += Browse_button_Click;
            Save_button.Click += Save_button_Click;
            SoundList_box.SelectedIndexChanged += SoundList_box_SelectedIndexChanged;
            Play_button.Click += Play_button_Click;
        }

        // Event handler ketika tombol Play diklik
        private void Play_button_Click(object? sender, EventArgs e)
        {
            // Pastikan ada nama file di TextBox (SoundPlay_text)
            if (!string.IsNullOrEmpty(SoundPlay_text.Text))
            {
                // Ambil teks yang ada di TextBox
                string selectedFile = SoundPlay_text.Text;

                // Periksa apakah format string benar, yaitu ada " - " yang memisahkan FileName dan FilePath
                if (selectedFile.Contains(" - "))
                {
                    var parts = selectedFile.Split(" - ");
                    if (parts.Length == 2)
                    {
                        string fileName = parts[0];  // Nama file
                        string filePath = parts[1];  // Path file

                        // Panggil fungsi untuk memutar suara
                        PlaySound(filePath);
                    }
                    else
                    {
                        MessageBox.Show("Format file tidak valid. Pastikan formatnya adalah 'FileName - FilePath'.");
                    }
                }
                else
                {
                    MessageBox.Show("Format file tidak valid. Pastikan formatnya adalah 'FileName - FilePath'.");
                }
            }
            else
            {
                MessageBox.Show("Pilih suara terlebih dahulu.");
            }
        }

        // Event handler untuk ListBox ketika item dipilih
        private void SoundList_box_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (SoundList_box.SelectedItem != null)
            {
                // Ambil item yang dipilih dari ListBox
                string selectedItem = SoundList_box.SelectedItem.ToString();

                // Menampilkan nama file atau detail lainnya di TextBox
                SoundPlay_text.Text = selectedItem;

                // Ambil nama file dan path dari selectedItem
                var parts = selectedItem.Split(" - "); // Asumsi format: "FileName - FilePath"
                if (parts.Length == 2)
                {
                    string fileName = parts[0];
                    string filePath = parts[1];

                    // Memutar suara dengan filePath
                    PlaySound(filePath);
                }
            }
        }

        // Fungsi untuk memutar suara (misalnya menggunakan NAudio)
        private void PlaySound(string filePath)
        {
            // Memastikan file ada
            if (File.Exists(filePath))
            {
                // Menggunakan NAudio untuk memutar file
                using (var audioFile = new NAudio.Wave.AudioFileReader(filePath))
                using (var outputDevice = new NAudio.Wave.WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                    {
                        // Tunggu sampai audio selesai diputar
                    }
                }
            }
            else
            {
                MessageBox.Show("File tidak ditemukan.");
            }
        }



        #region Browse
        private void Browse_button_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3|All Files(*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    sound_text.Text = selectedFilePath;
                }
            }
        }
        #endregion

        #region Save Button
        private void Save_button_Click(object? sender, EventArgs e)
        {
           string filePath = sound_text.Text;
            if(string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show(" mohon pilih file ");
                return;
            }
            string fileName = System.IO.Path.GetFileName(filePath);
            database db = new database();
            db.SaveSound(fileName, filePath);

            MessageBox.Show("data berhasil di simpan");

            DisplaySavedSounds();
        }
        #endregion

        #region Display dataGrid

       private void DisplaySavedSounds()
        {
            database db = new database();
            var soundsList = db.GetSounds();

            SoundList_box.Items.Clear();
            foreach (var sound in soundsList)
            {
                SoundList_box.Items.Add(sound);
            }
        }

       /* private void DisplaySavedSounds() 
         {
             database db = new database();
             var soundsList = db.GetSounds();

             Sound_grid.Rows.Clear();
             foreach (var sound in soundsList)
             {
                 var soundData = sound.Split(" - "); 
                 Sound_grid.Rows.Add(soundData[0], soundData[1]);
             }
         }*/
        #endregion


    }
}
