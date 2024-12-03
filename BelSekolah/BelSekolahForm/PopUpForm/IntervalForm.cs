using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelSekolah.BelSekolahForm.PopUpForm
{
    public partial class IntervalForm : Form
    {
        public string mulai { get; set; }
        public int interval { get; set; }
        public int istirahat_1 { get; set; }
        public int istirahat_2 { get; set; }

        public IntervalForm()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            JamIstirahat1Text.Text = "15";
            JamIstirahat2Text.Text = "30";

            InitialCombo();
            AturButton.Click += AturButton_Click;
        }

        private void AturButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IntervalText.Text) || string.IsNullOrWhiteSpace(JamIstirahat1Text.Text) || string.IsNullOrWhiteSpace(JamIstirahat2Text.Text))
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> dataPicker = new List<string>
            {
                "Jam ke-0", "Jam ke-1", "Jam ke-2", "Jam ke-3", "Istirahat 1",
                "Jam ke-4", "Jam ke-5", "Jam ke-6", "Istirahat 2", "Jam ke-7", "Jam ke-8",
                "Jam ke-9", "Jam ke-10", "Jam Pulang"
            };

            List<string> datePickerControls = new List<string>
            {
                "Jam0Picker", "Jam1Picker", "Jam2Picker", "Jam3Picker", "JamIstirahat1Picker", "Jam4Picker",
                "Jam5Picker", "Jam6Picker", "JamIstirahat2Picker", "Jam7Picker", "Jam8Picker", "Jam9Picker",
                "Jam10Picker", "JamKepulanganPicker"
            };

            int index = JamPelajaranCombo.SelectedIndex;

            mulai = datePickerControls[index];
            interval = int.Parse(IntervalText.Text);
            istirahat_1 = int.Parse(JamIstirahat1Text.Text);
            istirahat_2 = int.Parse(JamIstirahat2Text.Text);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitialCombo()
        {
            List<string> dataPicker= new List<string>
            {
                "Jam ke-0", "Jam ke-1", "Jam ke-2", "Jam ke-3", "Istirahat 1",
                "Jam ke-4", "Jam ke-5", "Jam ke-6", "Istirahat 2", "Jam ke-7", "Jam ke-8",
                "Jam ke-9", "Jam ke-10", "Jam Pulang"
            };
            JamPelajaranCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            JamPelajaranCombo.DataSource = dataPicker;
        }

    }
}