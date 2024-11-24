using BelSekolah.BelSekolahDatabase;
using BelSekolah.BelSekolahDatabase.Helper;
using CSCore.XAudio2;
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

namespace BelSekolah.BelSekolahForm.PopUpForm
{
    public partial class InputJadwalForm : Form
    {
        public InputJadwalForm(string Jenis)
        {
            InitializeComponent();
            JenisJadwalLabel.Text = Jenis;
        }

        private void InputJadwalForm_Load(object sender, EventArgs e)
        {
            evenButton();
        }
        private void evenButton()
        {
            CancleButton.Click += CancleButton_Click;
            BrowseButton.Click += BrowseButton_Click;
            SaveButton.Click += SaveButton_Click;
        }
        #region Save
        private void SaveButton_Click(object? sender, EventArgs e)
        {
            string filePath = SoundFileText.Text;
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show(" mohon pilih file ");
                return;
            }
            string fileName = System.IO.Path.GetFileName(filePath);
            string time = WaktuPicker.Value.ToString("HH:mm"); 
            string description = KeteranganText.Text;  
            string day = GetSelectedDays();
            SaveSound(fileName, filePath, time, day, description);
        }
        private string GetSelectedDays()
        {
            List<string> selectedDays = new List<string>();

            if (SetiapSeninCheckBox.Checked)
                selectedDays.Add("Senin");
            if (SetiapSelasaCheckBox.Checked)
                selectedDays.Add("Selasa");
            if (SetiapRabuCheckBox.Checked)
                selectedDays.Add("Rabu");
            if (SetiapKamisCheckBox.Checked)
                selectedDays.Add("Kamis");
            if (SetiapJumatCheckBox.Checked)
                selectedDays.Add("Jumat");

            return string.Join(", ", selectedDays);
        }

        public void SaveSound(string fileName, string filePath, string time, string day, string description)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(filePath) ||
                string.IsNullOrEmpty(time) || string.IsNullOrEmpty(day) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Semua kolom harus diisi!");
                return;
            }
            string query = "INSERT INTO Sounds (FileName, FilePath, Time, Day, Description) VALUES (@FileName, @FilePath, @Time, @Day, @Description)";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnStringHelper.GetConn()))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FileName", fileName);
                        command.Parameters.AddWithValue("@FilePath", filePath);
                        command.Parameters.AddWithValue("@Time", time);
                        command.Parameters.AddWithValue("@Day", day);
                        command.Parameters.AddWithValue("@Description", description);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data berhasil disimpan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }

        #endregion

        #region Browse
        private void BrowseButton_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3|All Files(*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    SoundFileText.Text = selectedFilePath;
                }
            }
        }
        #endregion


        private void CancleButton_Click(object? sender, EventArgs e)
        {
           this.Close();
        }
    }
}
