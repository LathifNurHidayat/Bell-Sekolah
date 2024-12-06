using BelSekolah.BelSekolahBackEnd.Dal;
using BelSekolah.BelSekolahBackEnd.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah.BelSekolahForm.PopUpForm.Jadwalkan_Form
{
    public partial class RencanakanJadwalForm : Form
    {
        private readonly RencanakanJadwalDal _rencanakanJadwalDal;
        private int _hariID;

        public RencanakanJadwalForm()
        {
            InitializeComponent();
            _rencanakanJadwalDal = new RencanakanJadwalDal();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            LoadData();
            RegisterControlEvent();
        }

        private void LoadData() 
        {
            var data = _rencanakanJadwalDal.ListData();
            RencanakanJadwalGrid.DataSource = data;

            RencanakanJadwalGrid.Columns["RencanakanJadwalID"].Visible = false;
            CustomStyleGrid(RencanakanJadwalGrid);
        }

        private void CustomStyleGrid(DataGridView grid)
        {
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.EnableHeadersVisualStyles = false;

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            grid.RowTemplate.Height = 30;
        }

        private void RegisterControlEvent()
        {
            TambahButton.Click += TambahButton_Click;

            JadwalPelajaranToolStripMenuItem.Click += JadwalPelajaranToolStripMenuItem_Click;
            JadwalUjianToolStripMenuItem1.Click += JadwalUjianToolStripMenuItem1_Click;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;

            RencanakanJadwalGrid.CellMouseClick += RencanakanJadwalGrid_CellMouseClick;

        }

        private void EditToolStripMenuItem_Click(object? sender, EventArgs e)
        {
          /*  InputData input = new InputData(0, 0, "Jadwal Khusus", "Edit", true);
            if (input.ShowDialog(this) == DialogResult.OK)
                LoadData();*/
        }

        private void DeleteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin akan menghapus data ?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int rencanakanJadwalID = Convert.ToInt32(RencanakanJadwalGrid.CurrentRow.Cells["RencanakanJadwalID"].Value);
                _rencanakanJadwalDal.Delete(rencanakanJadwalID);
                LoadData();
            }
        }

        private void RencanakanJadwalGrid_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right  && e.RowIndex >=  0 && e.ColumnIndex >= 0)
            {
                RencanakanJadwalGrid.ClearSelection();
                RencanakanJadwalGrid.CurrentCell = RencanakanJadwalGrid[e.ColumnIndex, e.RowIndex];
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void JadwalUjianToolStripMenuItem1_Click(object? sender, EventArgs e)
        {
            InputData input = new InputData(0, 0, "Jadwal Khusus", "Tambah", true);
            if (input.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void JadwalPelajaranToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            InputData input = new InputData(0, 0, "Jadwal Khusus", "Tambah", false);
            if (input.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void TambahButton_Click(object? sender, EventArgs e)
        {
            contextMenuStrip2.Show(Cursor.Position);
        }
    }
}
