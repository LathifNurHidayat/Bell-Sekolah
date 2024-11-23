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

namespace BelSekolah.BelSekolahForm
{
    public partial class MainForm : Form
    {
        private readonly CekDal cekDal;
        public MainForm()
        {
            InitializeComponent();
            cekDal = new CekDal();
        }
    }
}
