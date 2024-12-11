using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BelSekolah.BelSekolahForm.JadwalBelForm;

namespace BelSekolah.BelSekolahForm.PopUpForm
{
    public partial class DataJadwalDiputarForm : Form
    {
        public List<JadwalDto> _dataJadwalPutar { get; set; } = new List<JadwalDto>();
        public DataJadwalDiputarForm()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        public void LoadData(List<JadwalDto> jadwalList)
        {
            _dataJadwalPutar = jadwalList;
            DataDiputarGrid.DataSource = null;
            DataDiputarGrid.DataSource = _dataJadwalPutar;


            DataDiputarGrid.Columns["HariID"].Visible = false;
            DataDiputarGrid.Columns["SoundPath"].Visible = false;

            CustomStyleGrid(DataDiputarGrid);
        }

        private void CustomStyleGrid(DataGridView grid)
        {
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.EnableHeadersVisualStyles = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            grid.RowTemplate.Height = 30;
        }


    }
}
