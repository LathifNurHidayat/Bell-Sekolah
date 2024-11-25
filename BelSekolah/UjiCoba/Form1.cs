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

namespace BelSekolah.UjiCoba
{
    public partial class Form1 : Form
    {
        private readonly JadwalKhususDal jk = new JadwalKhususDal();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = jk.ListJadwalKhusus().
                Select(x => new
                {
                   waktu = x.Waktu
                }).ToList();
        }
    }
}
