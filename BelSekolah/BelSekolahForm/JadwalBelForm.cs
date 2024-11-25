using BelSekolah.BelSekolahForm.PopUpForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah.BelSekolahForm
{
    public partial class JadwalBelForm : Form
    {
        private Form mainForm;
        public JadwalBelForm(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.WindowState = FormWindowState.Maximized;

            RegisterControlEvent();
            InsertUpdateLabel.Text = "Update Data";

        }

        private void RegisterControlEvent()
        {
            AddButton.Click += AddButton_Click;
            this.FormClosed += JadwalBelForm_FormClosed;
            SaveButton.Click += SaveButton_Click;

            TambahKhususButton.Click += TambahKhususButton_Click;
            TambahNormalButton.Click += TambahNormalButton_Click;
        }

        private void TambahNormalButton_Click(object? sender, EventArgs e)
        {
            InputJadwalForm inputJadwalForm = new InputJadwalForm("Jadwal Normal");
            inputJadwalForm.ShowDialog();
        }

        private void TambahKhususButton_Click(object? sender, EventArgs e)
        {
            InputJadwalForm inputJadwalForm = new InputJadwalForm("Jadwal Khusus");
            inputJadwalForm.ShowDialog();
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            InsertUpdateLabel.Text = "Update Data";
        }

        private void JadwalBelForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AddButton_Click(object? sender, EventArgs e)
        {
            InsertUpdateLabel.Text = "Tambahkan Data Baru";
        }



    } 
}
