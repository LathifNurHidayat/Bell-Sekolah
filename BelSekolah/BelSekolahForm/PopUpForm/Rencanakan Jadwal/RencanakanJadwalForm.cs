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
        }

        private void TambahButton_Click(object? sender, EventArgs e)
        {
            InputData input = new InputData("", 0, "", "", true);
            input.ShowDialog(this);
        }
    }
}
