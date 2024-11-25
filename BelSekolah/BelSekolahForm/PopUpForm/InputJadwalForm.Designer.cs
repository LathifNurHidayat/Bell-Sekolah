namespace BelSekolah.BelSekolahForm.PopUpForm
{
    partial class InputJadwalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputJadwalForm));
            JenisJadwalLabel = new Label();
            CancleButton = new Button();
            SaveButton = new Button();
            BrowseButton = new Button();
            PausePlayButton = new Button();
            label4 = new Label();
            SoundFileText = new TextBox();
            label3 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            BatasInputText = new Label();
            KeteranganText = new TextBox();
            panel1 = new Panel();
            WaktuPicker = new DateTimePicker();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // JenisJadwalLabel
            // 
            JenisJadwalLabel.AutoSize = true;
            JenisJadwalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            JenisJadwalLabel.Location = new Point(175, 14);
            JenisJadwalLabel.Name = "JenisJadwalLabel";
            JenisJadwalLabel.Size = new Size(96, 23);
            JenisJadwalLabel.TabIndex = 89;
            JenisJadwalLabel.Text = "JenisJadwal";
            // 
            // CancleButton
            // 
            CancleButton.BackColor = Color.Silver;
            CancleButton.FlatAppearance.BorderColor = Color.Black;
            CancleButton.Location = new Point(186, 397);
            CancleButton.Name = "CancleButton";
            CancleButton.Size = new Size(115, 38);
            CancleButton.TabIndex = 88;
            CancleButton.Text = "Cancle";
            CancleButton.UseVisualStyleBackColor = false;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.LimeGreen;
            SaveButton.FlatAppearance.BorderColor = Color.Black;
            SaveButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(317, 397);
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
            BrowseButton.Location = new Point(338, 303);
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
            PausePlayButton.Location = new Point(292, 303);
            PausePlayButton.Name = "PausePlayButton";
            PausePlayButton.Size = new Size(30, 30);
            PausePlayButton.TabIndex = 85;
            PausePlayButton.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(20, 274);
            label4.Name = "label4";
            label4.Size = new Size(84, 23);
            label4.TabIndex = 84;
            label4.Text = "SoundFile";
            // 
            // SoundFileText
            // 
            SoundFileText.BorderStyle = BorderStyle.FixedSingle;
            SoundFileText.Location = new Point(20, 304);
            SoundFileText.Name = "SoundFileText";
            SoundFileText.ReadOnly = true;
            SoundFileText.Size = new Size(251, 27);
            SoundFileText.TabIndex = 83;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(20, 153);
            label3.Name = "label3";
            label3.Size = new Size(98, 23);
            label3.TabIndex = 82;
            label3.Text = "Keterangan";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(20, 45);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 79;
            label1.Text = "Waktu";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gainsboro;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(BatasInputText);
            panel3.Controls.Add(KeteranganText);
            panel3.Location = new Point(20, 179);
            panel3.Name = "panel3";
            panel3.Size = new Size(412, 78);
            panel3.TabIndex = 81;
            // 
            // BatasInputText
            // 
            BatasInputText.AutoSize = true;
            BatasInputText.BackColor = Color.White;
            BatasInputText.Location = new Point(348, 42);
            BatasInputText.Name = "BatasInputText";
            BatasInputText.Size = new Size(47, 20);
            BatasInputText.TabIndex = 5;
            BatasInputText.Text = "30/30";
            // 
            // KeteranganText
            // 
            KeteranganText.BorderStyle = BorderStyle.FixedSingle;
            KeteranganText.Location = new Point(3, 4);
            KeteranganText.Multiline = true;
            KeteranganText.Name = "KeteranganText";
            KeteranganText.Size = new Size(404, 68);
            KeteranganText.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(WaktuPicker);
            panel1.Location = new Point(20, 71);
            panel1.Name = "panel1";
            panel1.Size = new Size(412, 59);
            panel1.TabIndex = 80;
            // 
            // WaktuPicker
            // 
            WaktuPicker.CustomFormat = "HH:mm";
            WaktuPicker.Format = DateTimePickerFormat.Custom;
            WaktuPicker.Location = new Point(14, 16);
            WaktuPicker.Name = "WaktuPicker";
            WaktuPicker.ShowUpDown = true;
            WaktuPicker.Size = new Size(83, 27);
            WaktuPicker.TabIndex = 0;
            // 
            // InputJadwalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 449);
            Controls.Add(JenisJadwalLabel);
            Controls.Add(CancleButton);
            Controls.Add(SaveButton);
            Controls.Add(BrowseButton);
            Controls.Add(PausePlayButton);
            Controls.Add(label4);
            Controls.Add(SoundFileText);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InputJadwalForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += InputJadwalForm_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label JenisJadwalLabel;
        private Button CancleButton;
        private Button SaveButton;
        private Button BrowseButton;
        private Button PausePlayButton;
        private Label label4;
        private TextBox SoundFileText;
        private Label label3;
        private Label label1;
        private Panel panel3;
        private Label BatasInputText;
        private TextBox KeteranganText;
        private Panel panel1;
        private DateTimePicker WaktuPicker;
    }
}