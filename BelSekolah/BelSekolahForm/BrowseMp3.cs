using BelSekolah.BelSekolahDatabase;
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

        #region Display List Box
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
        #endregion


        /* private void DisplaySavedSounds() // kalau menggunakan data grid
         {
             database db = new database();
             var soundsList = db.GetSounds();

             dataGridView1.Rows.Clear();
             foreach (var sound in soundsList)
             {
                 var soundData = sound.Split(" - "); // Memisahkan FileName dan FilePath
                 dataGridView1.Rows.Add(soundData[0], soundData[1]);
             }
         }*/
    }
}
