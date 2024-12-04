using BelSekolah.BelSekolahDatabase.Helper;
using BelSekolah.BelSekolahForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah
{
    public partial class LoadForm : Form
    {
        private System.Windows.Forms.Timer _opacityTimer;
        private System.Windows.Forms.Timer _delayTimer;

        private readonly BelSekolahDatabase.Database _database;
        public LoadForm()
        {
            InitializeComponent();

            _database = new BelSekolahDatabase.Database();
            this.TransparencyKey = Color.Black;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.None;

            this.Opacity = 0;
            this._opacityTimer = new System.Windows.Forms.Timer();
            this._delayTimer = new System.Windows.Forms.Timer();

            this.Load += LoadForm_Load;
            this._opacityTimer.Interval = 10;
            this._opacityTimer.Tick += _opacityTimer_Tick;
            this._delayTimer.Interval = 2000;
            this._delayTimer.Tick += _delayTimer_Tick;

            ConnStringHelper.GetConn();
            _database.CreateTable();
        }

        private void LoadForm_Load(object? sender, EventArgs e)
        {
            this._opacityTimer.Start();
        }

        private void _opacityTimer_Tick(object? sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05; 
            }
            else
            {
                this._opacityTimer.Stop();
                this._delayTimer.Start();
            }
        }

        private void _delayTimer_Tick(object? sender, EventArgs e)
        {
            this._delayTimer.Stop();
            JadwalBelForm mainForm = new JadwalBelForm(this);
            mainForm.WindowState = FormWindowState.Maximized;
            mainForm.Show();
            this.Hide();
        }

    }
}