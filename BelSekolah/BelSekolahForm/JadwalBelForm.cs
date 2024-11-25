using BelSekolah.BelSekolahBackEnd.Dal;
using BelSekolah.BelSekolahBackEnd.Model;
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
        
        private readonly JadwalDal _jadwalDal;
        private readonly JadwalKhususDal _jadwalKhususDal;
        private readonly JadwalNormalDal _jadwalNormalDal;

        private int _jadwalHariID;
        
        public JadwalBelForm(Form mainForm)
        {   
            InitializeComponent();
            _jadwalDal = new JadwalDal();
            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalNormalDal = new JadwalNormalDal();

            this.mainForm = mainForm;
            this.WindowState = FormWindowState.Maximized;
            RegisterControlEvent();
            InsertUpdateLabel.Text = "Update Data"; 

            InitialCombo();
            LoadJadwal();
            LoadJadwalDetil(_jadwalHariID);

        }

        private void InitialCombo()
        {
            List<string> Hari = new List<string>() {"Pilih Hari", "Senin", "Selasa", "Rabu", "Kamis", "Jumat" };
            HariCombo.DataSource = Hari;    
        }

        private void LoadJadwal() //Data Hari
        {
            var dataHari = _jadwalDal.ListData();
            JadwalHariGrid.DataSource = dataHari;
        }

        private void LoadJadwalDetil(int HariID) //Data Jadwal Khusus dan jadwal Jadwal Normal
        {
            var jadwalNormal = _jadwalNormalDal.ListData(HariID)
                                               .Select(x => new
                                               {
                                                   x.JadwalNormalID,
                                                   x.Waktu,
                                                   x.Keterangan
                                               });
            JadwalNormalGrid.DataSource = jadwalNormal;



            var jadwalKhusus = _jadwalKhususDal.ListData(HariID)
                                               .Select(x => new
                                               {
                                                    x.JadwalKhususID,
                                                    x.Waktu,
                                                    x.Keterangan
                                               });
            JadwalKhususGrid.DataSource = jadwalKhusus;

        }

        private void ClearForm()
        {
            HariCombo.SelectedIndex = 0;
            JadwalNormalRadio.Checked = false;
            JadwalKhususRadio.Checked = false;
            JadwalKhususGrid.DataSource = null;
            JadwalNormalGrid.DataSource = null;
        }

        private void SaveData()
        {
            if (HariCombo.SelectedIndex == 0)
            {
                MessageBox.Show("Mohon pilih hari terlebih dahulu !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!JadwalNormalRadio.Checked && !JadwalKhususRadio.Checked)
            {
                MessageBox.Show("Mohon pilih salah satu jenis jadwal !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string jenisJadwal = string.Empty;
            if (JadwalNormalRadio.Checked == true) jenisJadwal = "Jadwal Normal";
            if (JadwalKhususRadio.Checked == true) jenisJadwal = "Jadwal Khusus";

            var jadwalHari = new JadwalModel
            {
                HariID = _jadwalHariID,
                JenisJadwal = jenisJadwal,
                Hari = (string)HariCombo.SelectedItem,
            };


            if (_jadwalHariID == 0)
            {
                _jadwalHariID = _jadwalDal.Insert(jadwalHari);

            }
            else
            {
                _jadwalDal.Update(jadwalHari);
            }
        }



        #region EVENT

        private void RegisterControlEvent()
        {
            AddButton.Click += AddButton_Click;
            this.FormClosed += JadwalBelForm_FormClosed;
            SaveButton.Click += SaveButton_Click;

            TambahKhususButton.Click += TambahKhususButton_Click;
            TambahNormalButton.Click += TambahNormalButton_Click;

            JadwalHariGrid.CellMouseClick += JadwalHariGrid_CellMouseClick;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
        }

        private void DeleteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin ingin menghapus data ?","Perhatian", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)== DialogResult.OK)
            {
                _jadwalDal.Delete(_jadwalHariID);
                LoadJadwal();
                LoadJadwalDetil(_jadwalHariID);
            }
        }

        private void JadwalHariGrid_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    JadwalHariGrid.ClearSelection();
                    JadwalHariGrid.CurrentCell = JadwalHariGrid[e.ColumnIndex, e.RowIndex];
                    _jadwalHariID = Convert.ToInt32(JadwalHariGrid.CurrentRow.Cells["HariID"].Value);
                    contextMenuStrip1.Show(Cursor.Position);
                    LoadJadwalDetil(_jadwalHariID);
                }
                _jadwalHariID = Convert.ToInt32(JadwalHariGrid.CurrentRow.Cells["HariID"].Value);
                LoadJadwalDetil(_jadwalHariID);
            }

        }

        private void TambahNormalButton_Click(object? sender, EventArgs e)
        {
            InputJadwalForm inputJadwalForm = new InputJadwalForm("Jadwal Normal", _jadwalHariID);
            inputJadwalForm.ShowDialog();
        }

        private void TambahKhususButton_Click(object? sender, EventArgs e)
        {
            InputJadwalForm inputJadwalForm = new InputJadwalForm("Jadwal Khusus", _jadwalHariID);
            inputJadwalForm.ShowDialog();
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            int hariId = Convert.ToInt32(JadwalHariGrid.CurrentRow.Cells["HariID"].Value);

            InsertUpdateLabel.Text = "Update Data";
            SaveData();
            LoadJadwal();
            LoadJadwalDetil(hariId);
        }

        private void JadwalBelForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AddButton_Click(object? sender, EventArgs e)
        {
            InsertUpdateLabel.Text = "Tambahkan Data Baru";
            ClearForm();
            _jadwalHariID = 0;
        }

        #endregion
    }
}
