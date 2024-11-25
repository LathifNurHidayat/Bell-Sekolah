using BelSekolah.BelSekolahBackEnd.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah.BelSekolahForm.PopUpForm
{
    public partial class EditJadwalForm : Form
    {
        private readonly JadwalKhususDal _jadwalKhususDal;
        private readonly JadwalNormalDal _jadwalNormalDal;

        public EditJadwalForm(string Jenis)
        {
            InitializeComponent();
            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalNormalDal = new JadwalNormalDal();

            JenisJadwalLabel.Text = Jenis;
            RegisterControlEvent();

            PausePlayButton.Text = "▶";
        }

        private void RegisterControlEvent()
        {
            BrowseButton.Click += BrowseButton_Click;
            PausePlayButton.Click += PausePlayButton_Click;
        }

        private void PausePlayButton_Click(object? sender, EventArgs e)
        {
            PausePlayButton.Text = (PausePlayButton.Text == "■") ? "▶" : "■";
        }

        private void BrowseButton_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sound Files (*.mp3)|*.mp3";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FilePath = openFileDialog.FileName;
                string NamaFile = Path.GetFileName(FilePath);
                SoundFileText.Text = NamaFile;

                SelectAndReplace(FilePath);
            }
        }

        private void SelectAndReplace(string FilePath)
        {
            string tujuanFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Sound");

            if (!Directory.Exists(tujuanFolder))
            {
                Directory.CreateDirectory(tujuanFolder);
            }

            string tujuanPath = Path.Combine(tujuanFolder, Path.GetFileName(FilePath));
            File.Copy(FilePath, tujuanPath, true);
        }



    }
}
