namespace BelSekolah
{
    partial class CloseStartApk
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
            button1 = new Button();
            jamBukaApkDT = new DateTimePicker();
            jamTutupApkDT = new DateTimePicker();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(245, 166);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // jamBukaApkDT
            // 
            jamBukaApkDT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            jamBukaApkDT.Format = DateTimePickerFormat.Time;
            jamBukaApkDT.Location = new Point(185, 83);
            jamBukaApkDT.Name = "jamBukaApkDT";
            jamBukaApkDT.ShowUpDown = true;
            jamBukaApkDT.Size = new Size(200, 25);
            jamBukaApkDT.TabIndex = 3;
            // 
            // jamTutupApkDT
            // 
            jamTutupApkDT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            jamTutupApkDT.Format = DateTimePickerFormat.Time;
            jamTutupApkDT.Location = new Point(185, 114);
            jamTutupApkDT.Name = "jamTutupApkDT";
            jamTutupApkDT.ShowUpDown = true;
            jamTutupApkDT.Size = new Size(200, 25);
            jamTutupApkDT.TabIndex = 4;
            // 
            // CloseStartApk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 307);
            Controls.Add(jamTutupApkDT);
            Controls.Add(jamBukaApkDT);
            Controls.Add(button1);
            Name = "CloseStartApk";
            Text = "CloseStartApk";
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private DateTimePicker jamBukaApkDT;
        private DateTimePicker jamTutupApkDT;
    }
}