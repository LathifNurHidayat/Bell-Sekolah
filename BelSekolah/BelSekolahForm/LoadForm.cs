using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah
{
    public partial class LoadForm : Form
    {
        public LoadForm()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {
            Opacity = 0;

            for (double i =  0; i <= 1; i += 0.1)
            {
                Opacity = i;
            }
        }
    }
}
