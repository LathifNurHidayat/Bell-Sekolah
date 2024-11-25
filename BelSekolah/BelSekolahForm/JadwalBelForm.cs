using BelSekolah.BelSekolahDatabase;
using BelSekolah.BelSekolahDatabase.Helper;
using BelSekolah.BelSekolahForm.PopUpForm;
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
    public partial class JadwalBelForm : Form
    {
        private Form mainForm;
        private readonly BelSekolahDatabase.Database db;
        public JadwalBelForm(Form mainForm)
        {   
            InitializeComponent();
            this.mainForm = mainForm;
            this.WindowState = FormWindowState.Maximized;
            initgrid();
            RegisterControlEvent();
            db = new BelSekolahDatabase.Database();
        }

        private void RegisterControlEvent()
        {
            AddNormalButton.Click += AddButton_Click;
            AddKhususButton.Click += AddKhususButton_Click;
        }

        private void AddKhususButton_Click(object? sender, EventArgs e)
        {
            InputJadwalForm tambah = new InputJadwalForm("Jadwal Khusus");
            tambah.ShowDialog();
        }

        private void AddButton_Click(object? sender, EventArgs e)
        {
            InputJadwalForm tambah = new InputJadwalForm("Jadwal Normal");
            tambah.ShowDialog();
        }

        private void initgrid()
        {   
            List<string> jadwalList = db.GetJadwalKhusus();
            JadwalBelGrid.Rows.Clear();
            foreach (var jadwal in jadwalList)
            {
                var splitData = jadwal.Split(new string[] { ", " }, StringSplitOptions.None);
                JadwalBelGrid.Rows.Add(splitData);
            }
        }

    } 
}
