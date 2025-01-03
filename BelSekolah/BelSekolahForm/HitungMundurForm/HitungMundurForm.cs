using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BelSekolah.BelSekolahForm.HitungMundurForm
{
    public partial class HitungMundurForm : Form
    {
        private System.Windows.Forms.Timer _hitungMundur;
        private Form _mainForm;
        private int _detikMundur = 29;
        public HitungMundurForm(Form mainform)
        {
            InitializeComponent();

            _hitungMundur = new System.Windows.Forms.Timer();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.TopMost = true;

            _mainForm = mainform;


            _hitungMundur.Interval = 1000;
            _hitungMundur.Start();
            _hitungMundur.Tick += _hitungMundur_Tick;
            BatalkanButton.Click += BatalkanButton_Click;
        }

        private void BatalkanButton_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin ingin membatalkan proses mematikan aplikasi ?", "Warning" , MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                _hitungMundur.Stop();
                this.Close();
            }
        }

        private void _hitungMundur_Tick(object? sender, EventArgs e)
        {
           if (_detikMundur > 0)
            {
                HitungMundurText.Text = _detikMundur.ToString();
                _detikMundur--;
            }
           else
            {
                _hitungMundur.Stop();
                _mainForm.Close();
            }
        }
    }
}