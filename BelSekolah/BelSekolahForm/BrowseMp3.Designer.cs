namespace BelSekolah.BelSekolahForm
{
    partial class BrowseMp3
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
            sound_text = new TextBox();
            browse_button = new Button();
            SoundList_box = new ListBox();
            Save_button = new Button();
            SuspendLayout();
            // 
            // sound_text
            // 
            sound_text.Location = new Point(170, 129);
            sound_text.Name = "sound_text";
            sound_text.Size = new Size(179, 23);
            sound_text.TabIndex = 0;
            // 
            // browse_button
            // 
            browse_button.Location = new Point(355, 129);
            browse_button.Name = "browse_button";
            browse_button.Size = new Size(75, 23);
            browse_button.TabIndex = 1;
            browse_button.Text = "Browse";
            browse_button.UseVisualStyleBackColor = true;
            // 
            // SoundList_box
            // 
            SoundList_box.FormattingEnabled = true;
            SoundList_box.ItemHeight = 15;
            SoundList_box.Location = new Point(107, 12);
            SoundList_box.Name = "SoundList_box";
            SoundList_box.Size = new Size(343, 94);
            SoundList_box.TabIndex = 2;
            // 
            // Save_button
            // 
            Save_button.Location = new Point(355, 174);
            Save_button.Name = "Save_button";
            Save_button.Size = new Size(75, 23);
            Save_button.TabIndex = 3;
            Save_button.Text = "save";
            Save_button.UseVisualStyleBackColor = true;
            // 
            // BrowseMp3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 443);
            Controls.Add(Save_button);
            Controls.Add(SoundList_box);
            Controls.Add(browse_button);
            Controls.Add(sound_text);
            Name = "BrowseMp3";
            Text = "BrowseMp3";
            Load += BrowseMp3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox sound_text;
        private Button browse_button;
        private ListBox SoundList_box;
        private Button Save_button;
    }
}