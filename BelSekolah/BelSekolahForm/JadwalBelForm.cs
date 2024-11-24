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
        private Form mainForm;
        public JadwalBelForm(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.WindowState = FormWindowState.Maximized;

            RegisterControlEvent();
        }

        private void RegisterControlEvent()
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
