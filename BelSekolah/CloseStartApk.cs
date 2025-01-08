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
    public partial class CloseStartApk : Form
    {
        public CloseStartApk(TimeSpan jam1, TimeSpan jam2)
        {
            InitializeComponent();
            if (jam1 == TimeSpan.Zero || jam2 == TimeSpan.Zero) return;
            jamBukaApkDT.Value = DateTime.Today.Add(jam1);
            jamTutupApkDT.Value = DateTime.Today.Add(jam2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan jamBuka = jamBukaApkDT.Value.TimeOfDay;
            TimeSpan jamTutup = jamTutupApkDT.Value.TimeOfDay;
            JadwalBelForm.jam1 = jamBuka;
            JadwalBelForm.jam2 = jamTutup;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
