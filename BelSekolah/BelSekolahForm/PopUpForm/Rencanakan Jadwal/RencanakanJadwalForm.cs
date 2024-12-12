using BelSekolah.BelSekolahBackEnd.Dal;
using BelSekolah.BelSekolahBackEnd.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
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
              
            CustomStyleGrid(RencanakanJadwalGrid);
        }

        private void CustomStyleGrid(DataGridView grid)
        {
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.EnableHeadersVisualStyles = false;
            grid.Columns["RencanakanJadwalID"].Visible = false;
            grid.Columns["HariID"].Visible = false;
            grid.Columns["IsUjian"].Visible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
            this.FormClosed += (s, e) => { this.DialogResult = DialogResult.OK; };

        }

        private void EditToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            int IsUjian = Convert.ToInt32(RencanakanJadwalGrid.CurrentRow.Cells["IsUjian"].Value);
            int perencanaanID = Convert.ToInt32(RencanakanJadwalGrid.CurrentRow.Cells["RencanakanJadwalID"].Value);

            if (IsUjian == 1 )
            {
                InputRencanakanJadwalUjianForm input = new InputRencanakanJadwalUjianForm(perencanaanID);
                if (input.ShowDialog(this) == DialogResult.OK) LoadData();
            }
            else
            {
                InputRencanakanJadwalForm input = new InputRencanakanJadwalForm(perencanaanID, "Jadwal Khusus", "Edit");
                if (input.ShowDialog(this) == DialogResult.OK) LoadData();
            }
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
            InputRencanakanJadwalUjianForm input = new InputRencanakanJadwalUjianForm(0);
            if (input.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void JadwalPelajaranToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            InputRencanakanJadwalForm input = new InputRencanakanJadwalForm(0, "Jadwal Khusus", "Tambah");
            if (input.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void TambahButton_Click(object? sender, EventArgs e)
        {
            contextMenuStrip2.Show(Cursor.Position);
        }
    }
}
