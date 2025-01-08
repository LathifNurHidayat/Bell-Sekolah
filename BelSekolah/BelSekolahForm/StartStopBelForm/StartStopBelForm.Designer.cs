namespace BelSekolah
{
    partial class StartStopBelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartStopBelForm));
            StopBelPicker = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            SaveButton = new Button();
            StartBelPicker = new DateTimePicker();
            SuspendLayout();
            // 
            // StopBelPicker
            // 
            StopBelPicker.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            StopBelPicker.Format = DateTimePickerFormat.Time;
            StopBelPicker.Location = new Point(178, 78);
            StopBelPicker.Name = "StopBelPicker";
            StopBelPicker.ShowUpDown = true;
            StopBelPicker.Size = new Size(95, 25);
            StopBelPicker.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(160, 17);
            label1.TabIndex = 5;
            label1.Text = "Run otomatis setiap jam  :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(161, 17);
            label2.TabIndex = 6;
            label2.Text = "Stop otomatis setiap jam :";
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom;
            SaveButton.BackColor = Color.DarkKhaki;
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(96, 135);
            SaveButton.Margin = new Padding(3, 2, 3, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(96, 35);
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            // 
            // StartBelPicker
            // 
            StartBelPicker.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            StartBelPicker.Format = DateTimePickerFormat.Time;
            StartBelPicker.Location = new Point(178, 26);
            StartBelPicker.Name = "StartBelPicker";
            StartBelPicker.ShowUpDown = true;
            StartBelPicker.Size = new Size(95, 25);
            StartBelPicker.TabIndex = 8;
            // 
            // CloseStartBelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 181);
            Controls.Add(StartBelPicker);
            Controls.Add(SaveButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(StopBelPicker);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CloseStartBelForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Jadwalkan Running Bel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private DateTimePicker jamBukaApkDT;
        private DateTimePicker StopBelPicker;
        private Label label1;
        private Label label2;
        private Button SaveButton;
        private DateTimePicker StartBelPicker;
    }
}