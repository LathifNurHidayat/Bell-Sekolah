using BelSekolah.BelSekolahBackEnd.Dal;
using BelSekolah.BelSekolahBackEnd.Model;
using BelSekolah.BelSekolahDatabase;
using BelSekolah.BelSekolahDatabase.Helper;
using BelSekolah.BelSekolahForm.PopUpForm;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah.BelSekolahForm
{
    public partial class JadwalBelForm : Form
    {
        private enum GridAktif { None, JadwalNormal, JadwalKhusus };
        private GridAktif _gridAktif = GridAktif.None;

        private Form mainForm;
        private readonly JadwalDal _jadwalDal;
        private readonly JadwalKhususDal _jadwalKhususDal;
        private readonly JadwalNormalDal _jadwalNormalDal;

        private readonly JadwalModel _jadwalModel;
        private readonly JadwalKhususModel _jadwalKhususModel;
        private readonly JadwalNormalModel _jadwalNormalModel;

        private int _jadwalHariID;

        private DateTime _waktuSekarang;
        private string _hariSekarang;

        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _jam;


        public JadwalBelForm(Form mainForm)
        {   
            InitializeComponent();
            _jadwalDal = new JadwalDal();
            _jadwalKhususDal = new JadwalKhususDal();
            _jadwalNormalDal = new JadwalNormalDal();

            _jadwalModel = new JadwalModel();
            _jadwalKhususModel = new JadwalKhususModel();
            _jadwalNormalModel = new JadwalNormalModel();

            _timer = new System.Windows.Forms.Timer();
            _jam = new System.Windows.Forms.Timer();


            this.mainForm = mainForm;
            this.WindowState = FormWindowState.Maximized;
            RegisterControlEvent();
            InsertUpdateLabel.Text = "Update Data"; 

            InitialCombo();
            LoadJadwal();
            LoadJadwalDetil(_jadwalHariID);

            _timer.Interval = 10000; 
            _timer.Tick += _timer_Tick;
            _timer.Start();

            _jam.Interval = 1000;
            _jam.Tick += _jam_Tick;
            _jam.Start();

        }

        private void _jam_Tick(object? sender, EventArgs e)
        {
            JamLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            _hariSekarang = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));
            _waktuSekarang = DateTime.Now;

            if (_jadwalModel.Hari == _hariSekarang)
            {
                var jenisJadwal = _jadwalModel.JenisJadwal;
                if (jenisJadwal == "Jadwal Normal")
                {
                    MessageBox.Show("normal");
                }
                if (jenisJadwal == "Jadwal Khusus")
                {
                    MessageBox.Show("khusus");

                }
            }
        }

        private void PlaySound(string soundPath)
        {
            if (System.IO.File.Exists(soundPath))
            {
                var player = new System.Media.SoundPlayer(soundPath);
                player.Play();
            }
            else
            {
                MessageBox.Show($"Sound file not found: {soundPath}");
            }
        }

            
        private void InitialCombo() 
        {
            List<string> Hari = new List<string>() {"Pilih Hari", "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu", "Minggu"};
            HariCombo.DataSource = Hari;    
        }

        private void LoadJadwal() //Data Hari
        {
            var dataHari = _jadwalDal.ListData();
            JadwalHariGrid.DataSource = dataHari;

            JadwalHariGrid.Columns["Waktu"].Visible = false;
            JadwalHariGrid.Columns["Keterangan"].Visible = false;
            JadwalHariGrid.Columns["SoundName"].Visible = false;
            JadwalHariGrid.Columns["SoundPath"].Visible = false;
        }

        private void LoadJadwalDetil(int HariID) //Data Jadwal Khusus dan jadwal Jadwal Normal
        {
            var jadwalNormal = _jadwalNormalDal.ListData(HariID);
            JadwalNormalGrid.DataSource = jadwalNormal;
            JadwalNormalGrid.Columns["JadwalNormalID"].Visible = false;
            JadwalNormalGrid.Columns["HariID"].Visible = false;
            JadwalNormalGrid.Columns["SoundPath"].Visible = false;
            JadwalNormalGrid.Columns["SoundName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            JadwalNormalGrid.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            var jadwalKhusus = _jadwalKhususDal.ListData(HariID);
            JadwalKhususGrid.DataSource = jadwalKhusus;
            JadwalKhususGrid.Columns["JadwalKhususID"].Visible = false;
            JadwalKhususGrid.Columns["HariID"].Visible = false;
            JadwalKhususGrid.Columns["SoundPath"].Visible = false;
            JadwalKhususGrid.Columns["SoundName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            JadwalKhususGrid.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void GetData()
        {
            var hari = JadwalHariGrid.CurrentRow.Cells["Hari"].Value.ToString();
            var jenis = JadwalHariGrid.CurrentRow.Cells["JenisJadwal"].Value.ToString();

            if (HariCombo.Items.Contains(hari))
            {
                HariCombo.SelectedItem = hari;
            }

            if (jenis == "Jadwal Normal")
            {
                JadwalNormalRadio.Checked = true;
                JadwalKhususRadio.Checked = false;
            }
            else
            {
                JadwalNormalRadio.Checked = false;
                JadwalKhususRadio.Checked = true;
            }
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
            JadwalHariGrid.SelectionChanged += JadwalHariGrid_SelectionChanged;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;

            JadwalNormalGrid.CellMouseClick += JadwalNormalGrid_CellMouseClick;
            JadwalKhususGrid.CellMouseClick += JadwalKhususGrid_CellMouseClick;
            deleteToolStripMenuItem1.Click += DeleteToolStripMenuItem1_Click;
            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;

            HariCombo.SelectedIndexChanged += HariCombo_SelectedIndexChanged;
        }

        private void HariCombo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (JadwalHariGrid.CurrentRow != null && JadwalHariGrid.CurrentRow.Cells["Hari"].Value != null && _jadwalHariID == 0)
            {
                List<string> hari = new List<string>();

                if (hari.Contains(HariCombo.SelectedItem.ToString()))
                {
                    MessageBox.Show("Data hari sudah ada, mohon pilih hari yang lain!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    HariCombo.SelectedIndex = 0;
                }
            }
        }


        private void EditToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (_gridAktif == GridAktif.JadwalNormal)
            {
                int jadwalNormalID = Convert.ToInt32(JadwalNormalGrid.CurrentRow.Cells["JadwalNormalID"].Value);
                EditJadwalForm editJadwalForm = new EditJadwalForm("Jadwal Normal", jadwalNormalID);
                editJadwalForm.ShowDialog();
            }
            else if (_gridAktif == GridAktif.JadwalKhusus)
            {
                int jadwalKhususID = Convert.ToInt32(JadwalKhususGrid.CurrentRow.Cells["JadwalKhususID"].Value);
                EditJadwalForm editJadwalForm = new EditJadwalForm("Jadwal Khusus", jadwalKhususID);
                editJadwalForm.ShowDialog();
            }

            LoadJadwalDetil(_jadwalHariID);
        }

        private void DeleteToolStripMenuItem1_Click(object? sender, EventArgs e)
        {
            if (_gridAktif == GridAktif.JadwalNormal)
            {
                if (MessageBox.Show("Anda yakin ingin menghapus data Jadwal Normal?", "Perhatian", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int jadwalNormalID = Convert.ToInt32(JadwalNormalGrid.CurrentRow.Cells["JadwalNormalID"].Value);
                    _jadwalNormalDal.Delete(jadwalNormalID);
                    LoadJadwalDetil(_jadwalHariID);
                }
            }
            else if (_gridAktif == GridAktif.JadwalKhusus)
            {
                if (MessageBox.Show("Anda yakin ingin menghapus data Jadwal Khusus?", "Perhatian", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int jadwalKhususID = Convert.ToInt32(JadwalKhususGrid.CurrentRow.Cells["JadwalKhususID"].Value);
                    _jadwalKhususDal.Delete(jadwalKhususID);
                    LoadJadwalDetil(_jadwalHariID);
                }
            }
        }

        private void JadwalKhususGrid_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex  >= 0)
            {
                _gridAktif = GridAktif.JadwalKhusus;

                JadwalKhususGrid.ClearSelection();
                JadwalKhususGrid.CurrentCell = JadwalKhususGrid[e.ColumnIndex, e.RowIndex];
                contextMenuStrip2.Show(Cursor.Position);

                if (JadwalKhususGrid.CurrentRow?.Cells["JadwalKhususID"].Value != null)
                {
                    GetData();
                }
            }
        }

        private void JadwalNormalGrid_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _gridAktif = GridAktif.JadwalNormal;

                JadwalNormalGrid.ClearSelection();
                JadwalNormalGrid.CurrentCell = JadwalNormalGrid[e.ColumnIndex, e.RowIndex];
                contextMenuStrip2.Show(Cursor.Position);

                if (JadwalNormalGrid.CurrentRow?.Cells["JadwalNormalID"].Value != null)
                {
                    GetData();
                }
            }
        }

        private void JadwalHariGrid_SelectionChanged(object? sender, EventArgs e)
        {
            if (JadwalHariGrid.CurrentRow?.Cells["HariID"].Value != null)
            {
                _jadwalHariID = Convert.ToInt32(JadwalHariGrid.CurrentRow.Cells["HariID"].Value);

                GetData();
                LoadJadwalDetil(_jadwalHariID);
            }
        }

        private void DeleteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin ingin menghapus data?", "Perhatian", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                _jadwalDal.Delete(_jadwalHariID);
                LoadJadwal();

                if (JadwalHariGrid.Rows.Count > 0)
                {
                    _jadwalHariID = Convert.ToInt32(JadwalHariGrid.Rows[0].Cells["HariID"].Value);
                    LoadJadwalDetil(_jadwalHariID);
                }
                else
                {
                    _jadwalHariID = 0; 
                }
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

                    if (JadwalHariGrid.CurrentRow?.Cells["HariID"].Value != null)
                    {
                        _jadwalHariID = Convert.ToInt32(JadwalHariGrid.CurrentRow.Cells["HariID"].Value);
                        contextMenuStrip1.Show(Cursor.Position);
                        LoadJadwalDetil(_jadwalHariID);
                        GetData();
                    }
                }
            }
        }


        private void TambahNormalButton_Click(object? sender, EventArgs e)
        {
            if (HariCombo.SelectedIndex == 0)
            {
                MessageBox.Show("Pilih hari terlebih dahulu !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_jadwalHariID ==  0 )
            {
                SaveData();
            }


            InputJadwalForm inputJadwalForm = new InputJadwalForm("Jadwal Normal", _jadwalHariID);
            inputJadwalForm.ShowDialog();
            LoadJadwalDetil(_jadwalHariID);            

        }

        private void TambahKhususButton_Click(object? sender, EventArgs e)
        {
            if (HariCombo.SelectedIndex == 0)
            {
                MessageBox.Show("Pilih hari terlebih dahulu !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InputJadwalForm inputJadwalForm = new InputJadwalForm("Jadwal Khusus", _jadwalHariID);
            inputJadwalForm.ShowDialog();
            LoadJadwalDetil(_jadwalHariID);
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
