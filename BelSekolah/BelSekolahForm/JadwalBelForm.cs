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
        public JadwalBelForm()
        {
            InitializeComponent();
        }

        private void JadwalBelForm_Load(object sender, EventArgs e)
        {
            evenbutton();
        }
        private void evenbutton()
        {
            AddButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object? sender, EventArgs e)
        {
            InputJadwalForm tambah = new InputJadwalForm();
            tambah.Show();
        }

    }
}
