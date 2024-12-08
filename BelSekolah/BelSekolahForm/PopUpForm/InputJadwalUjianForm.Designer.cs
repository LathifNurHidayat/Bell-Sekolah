namespace BelSekolah.BelSekolahForm.PopUpForm
{
    partial class InputJadwalUjianForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputJadwalUjianForm));
            SaveButton = new Button();
            BrowseButton = new Button();
            PausePlayButton = new Button();
            label4 = new Label();
            SoundFileText = new TextBox();
            label3 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            KeteranganText = new TextBox();
            panel1 = new Panel();
            WaktuPicker = new DateTimePicker();
            label2 = new Label();
            JadwalUjianGrid = new DataGridView();
            NewButton = new Button();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)JadwalUjianGrid).BeginInit();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.LimeGreen;
            SaveButton.FlatAppearance.BorderColor = Color.Black;
            SaveButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(309, 550);
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
            BrowseButton.Location = new Point(330, 279);
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
            PausePlayButton.Location = new Point(284, 279);
            PausePlayButton.Name = "PausePlayButton";
            PausePlayButton.Size = new Size(30, 30);
            PausePlayButton.TabIndex = 85;
            PausePlayButton.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 250);
            label4.Name = "label4";
            label4.Size = new Size(84, 23);
            label4.TabIndex = 84;
            label4.Text = "SoundFile";
            // 
            // SoundFileText
            // 
            SoundFileText.BorderStyle = BorderStyle.FixedSingle;
            SoundFileText.Location = new Point(12, 280);
            SoundFileText.Name = "SoundFileText";
            SoundFileText.ReadOnly = true;
            SoundFileText.Size = new Size(251, 27);
            SoundFileText.TabIndex = 83;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 129);
            label3.Name = "label3";
            label3.Size = new Size(98, 23);
            label3.TabIndex = 82;
            label3.Text = "Keterangan";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 79;
            label1.Text = "Waktu";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gainsboro;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(KeteranganText);
            panel3.Location = new Point(12, 155);
            panel3.Name = "panel3";
            panel3.Size = new Size(412, 78);
            panel3.TabIndex = 81;
            // 
            // KeteranganText
            // 
            KeteranganText.BorderStyle = BorderStyle.FixedSingle;
            KeteranganText.Location = new Point(3, 4);
            KeteranganText.MaxLength = 30;
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
            panel1.Location = new Point(12, 47);
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 324);
            label2.Name = "label2";
            label2.Size = new Size(104, 23);
            label2.TabIndex = 91;
            label2.Text = "Jadwal Ujian";
            // 
            // JadwalUjianGrid
            // 
            JadwalUjianGrid.BackgroundColor = Color.White;
            JadwalUjianGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JadwalUjianGrid.GridColor = Color.White;
            JadwalUjianGrid.Location = new Point(12, 350);
            JadwalUjianGrid.Name = "JadwalUjianGrid";
            JadwalUjianGrid.RowHeadersWidth = 51;
            JadwalUjianGrid.RowTemplate.Height = 29;
            JadwalUjianGrid.Size = new Size(412, 182);
            JadwalUjianGrid.TabIndex = 90;
            // 
            // NewButton
            // 
            NewButton.BackColor = Color.DarkGray;
            NewButton.FlatAppearance.BorderColor = Color.Black;
            NewButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NewButton.ForeColor = Color.White;
            NewButton.Location = new Point(188, 550);
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(115, 38);
            NewButton.TabIndex = 92;
            NewButton.Text = "New";
            NewButton.UseVisualStyleBackColor = false;
            // 
            // InputJadwalUjianForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 605);
            Controls.Add(NewButton);
            Controls.Add(label2);
            Controls.Add(JadwalUjianGrid);
            Controls.Add(SaveButton);
            Controls.Add(BrowseButton);
            Controls.Add(PausePlayButton);
            Controls.Add(label4);
            Controls.Add(SoundFileText);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InputJadwalUjianForm";
            StartPosition = FormStartPosition.CenterParent;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)JadwalUjianGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button SaveButton;
        private Button BrowseButton;
        private Button PausePlayButton;
        private Label label4;
        private TextBox SoundFileText;
        private Label label3;
        private Label label1;
        private Panel panel3;
        private TextBox KeteranganText;
        private Panel panel1;
        private DateTimePicker WaktuPicker;
        private Label label2;
        private DataGridView JadwalUjianGrid;
        private Button NewButton;
    }
}