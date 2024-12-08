namespace BelSekolah.BelSekolahForm.PopUpForm
{
    partial class InputRencanakanJadwalUjianForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputRencanakanJadwalUjianForm));
            SaveButton = new Button();
            BrowseButton = new Button();
            PausePlayButton = new Button();
            label4 = new Label();
            SoundFileText = new TextBox();
            label3 = new Label();
            label1 = new Label();
            KeteranganText = new TextBox();
            panel1 = new Panel();
            WaktuPicker = new DateTimePicker();
            JadwalUjianGrid = new DataGridView();
            label2 = new Label();
            NewButton = new Button();
            panel2 = new Panel();
            label5 = new Label();
            label6 = new Label();
            TanggalPicker = new DateTimePicker();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)JadwalUjianGrid).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.LimeGreen;
            SaveButton.FlatAppearance.BorderColor = Color.Black;
            SaveButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(367, 446);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(115, 38);
            SaveButton.TabIndex = 87;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            // 
            // BrowseButton
            // 
            BrowseButton.BackColor = Color.Gainsboro;
            BrowseButton.FlatAppearance.BorderColor = Color.Black;
            BrowseButton.FlatStyle = FlatStyle.Flat;
            BrowseButton.Location = new Point(388, 129);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(94, 29);
            BrowseButton.TabIndex = 86;
            BrowseButton.Text = "Browse";
            BrowseButton.UseVisualStyleBackColor = false;
            // 
            // PausePlayButton
            // 
            PausePlayButton.BackColor = Color.Gainsboro;
            PausePlayButton.BackgroundImageLayout = ImageLayout.Zoom;
            PausePlayButton.FlatAppearance.BorderColor = Color.Black;
            PausePlayButton.FlatStyle = FlatStyle.Flat;
            PausePlayButton.Location = new Point(333, 128);
            PausePlayButton.Name = "PausePlayButton";
            PausePlayButton.Size = new Size(30, 30);
            PausePlayButton.TabIndex = 85;
            PausePlayButton.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(11, 102);
            label4.Name = "label4";
            label4.Size = new Size(84, 23);
            label4.TabIndex = 84;
            label4.Text = "SoundFile";
            // 
            // SoundFileText
            // 
            SoundFileText.BorderStyle = BorderStyle.FixedSingle;
            SoundFileText.Location = new Point(11, 128);
            SoundFileText.Name = "SoundFileText";
            SoundFileText.ReadOnly = true;
            SoundFileText.Size = new Size(300, 27);
            SoundFileText.TabIndex = 83;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(140, 27);
            label3.Name = "label3";
            label3.Size = new Size(112, 23);
            label3.TabIndex = 82;
            label3.Text = "Jadwal Mapel";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(11, 27);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 79;
            label1.Text = "Waktu";
            // 
            // KeteranganText
            // 
            KeteranganText.BorderStyle = BorderStyle.FixedSingle;
            KeteranganText.Location = new Point(140, 50);
            KeteranganText.MaxLength = 30;
            KeteranganText.Multiline = true;
            KeteranganText.Name = "KeteranganText";
            KeteranganText.Size = new Size(342, 30);
            KeteranganText.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(BrowseButton);
            panel1.Controls.Add(NewButton);
            panel1.Controls.Add(SoundFileText);
            panel1.Controls.Add(SaveButton);
            panel1.Controls.Add(JadwalUjianGrid);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(KeteranganText);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(WaktuPicker);
            panel1.Controls.Add(PausePlayButton);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(9, 110);
            panel1.Name = "panel1";
            panel1.Size = new Size(494, 499);
            panel1.TabIndex = 80;
            // 
            // WaktuPicker
            // 
            WaktuPicker.CustomFormat = "HH:mm";
            WaktuPicker.Format = DateTimePickerFormat.Custom;
            WaktuPicker.Location = new Point(11, 53);
            WaktuPicker.Name = "WaktuPicker";
            WaktuPicker.ShowUpDown = true;
            WaktuPicker.Size = new Size(111, 27);
            WaktuPicker.TabIndex = 0;
            // 
            // JadwalUjianGrid
            // 
            JadwalUjianGrid.BackgroundColor = Color.White;
            JadwalUjianGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JadwalUjianGrid.GridColor = Color.Black;
            JadwalUjianGrid.Location = new Point(11, 212);
            JadwalUjianGrid.Name = "JadwalUjianGrid";
            JadwalUjianGrid.RowHeadersWidth = 51;
            JadwalUjianGrid.RowTemplate.Height = 29;
            JadwalUjianGrid.Size = new Size(471, 204);
            JadwalUjianGrid.TabIndex = 88;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(11, 186);
            label2.Name = "label2";
            label2.Size = new Size(104, 23);
            label2.TabIndex = 89;
            label2.Text = "Jadwal Ujian";
            // 
            // NewButton
            // 
            NewButton.BackColor = Color.DarkGray;
            NewButton.FlatAppearance.BorderColor = Color.Black;
            NewButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NewButton.ForeColor = Color.White;
            NewButton.Location = new Point(246, 446);
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(115, 38);
            NewButton.TabIndex = 90;
            NewButton.Text = "New";
            NewButton.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Gainsboro;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(TanggalPicker);
            panel2.Controls.Add(textBox1);
            panel2.Location = new Point(9, 14);
            panel2.Name = "panel2";
            panel2.Size = new Size(494, 83);
            panel2.TabIndex = 161;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(255, 10);
            label5.Name = "label5";
            label5.Size = new Size(179, 23);
            label5.TabIndex = 170;
            label5.Text = "Keterangan (Optional)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(11, 10);
            label6.Name = "label6";
            label6.Size = new Size(69, 23);
            label6.TabIndex = 169;
            label6.Text = "Tanggal";
            // 
            // TanggalPicker
            // 
            TanggalPicker.CustomFormat = "dddd, dd-MM-yyyy";
            TanggalPicker.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TanggalPicker.Format = DateTimePickerFormat.Custom;
            TanggalPicker.Location = new Point(11, 36);
            TanggalPicker.Name = "TanggalPicker";
            TanggalPicker.Size = new Size(227, 30);
            TanggalPicker.TabIndex = 160;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(255, 36);
            textBox1.MaxLength = 30;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(227, 30);
            textBox1.TabIndex = 168;
            textBox1.TabStop = false;
            textBox1.Tag = "";
            // 
            // InputRencanakanJadwalUjianForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 620);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InputRencanakanJadwalUjianForm";
            StartPosition = FormStartPosition.CenterParent;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)JadwalUjianGrid).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button SaveButton;
        private Button BrowseButton;
        private Button PausePlayButton;
        private Label label4;
        private TextBox SoundFileText;
        private Label label3;
        private Label label1;
        private TextBox KeteranganText;
        private Panel panel1;
        private DateTimePicker WaktuPicker;
        private DataGridView JadwalUjianGrid;
        private Label label2;
        private Button NewButton;
        private Panel panel2;
        private Label label5;
        private Label label6;
        private DateTimePicker TanggalPicker;
        private TextBox textBox1;
    }
}