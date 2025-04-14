using BelSekolah.BelSekolahBackEnd.Dal;
using BelSekolah.BelSekolahForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace BelSekolah
{
    public partial class StartStopBelForm : Form
    {
        private readonly StartCloseBelDal _startCloseBelDal;
        public StartStopBelForm()
        {
            InitializeComponent();

            _startCloseBelDal = new StartCloseBelDal();
            SaveButton.Click += SaveButton_Click;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            GetData();
        }

        private void GetData()
        {
            var data = _startCloseBelDal.GetData();
            if (data == null) return;

            StartBelPicker.Value = DateTime.Parse(data.WaktuStartBel);
            StopBelPicker.Value = DateTime.Parse(data.WaktuStopBel);
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            string start = StartBelPicker.Value.ToString("HH:mm:ss");
            string stop = StopBelPicker.Value.ToString("HH:mm:ss");

            _startCloseBelDal.UpdateStartCloseBel(start, stop);
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
