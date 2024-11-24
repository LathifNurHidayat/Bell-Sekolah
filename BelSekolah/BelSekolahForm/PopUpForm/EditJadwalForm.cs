using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah.BelSekolahForm.PopUpForm
{
    public partial class EditJadwalForm : Form
    {
        public EditJadwalForm()
        {
            InitializeComponent();
            PausePlayButton.Text = "▶";
            PausePlayButton.Text = "■";

        }

        private void EditJadwalForm_Load(object sender, EventArgs e)
        {
        
        }
    }
}
