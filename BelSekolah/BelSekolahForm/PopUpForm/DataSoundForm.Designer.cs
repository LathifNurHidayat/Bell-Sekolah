namespace BelSekolah.BelSekolahForm.PopUpForm
{
    partial class DataSoundForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataSoundForm));
            panel2 = new Panel();
            label1 = new Label();
            DataSoundGrid = new DataGridView();
            panel1 = new Panel();
            AddButton = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataSoundGrid).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGray;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(555, 63);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Yi Baiti", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(184, 10);
            label1.Name = "label1";
            label1.Size = new Size(187, 40);
            label1.TabIndex = 3;
            label1.Text = "Data Sound";
            // 
            // DataSoundGrid
            // 
            DataSoundGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataSoundGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataSoundGrid.Location = new Point(16, 15);
            DataSoundGrid.Name = "DataSoundGrid";
            DataSoundGrid.RowHeadersWidth = 51;
            DataSoundGrid.RowTemplate.Height = 29;
            DataSoundGrid.Size = new Size(498, 310);
            DataSoundGrid.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(AddButton);
            panel1.Controls.Add(DataSoundGrid);
            panel1.Location = new Point(12, 81);
            panel1.Name = "panel1";
            panel1.Size = new Size(531, 401);
            panel1.TabIndex = 4;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.FromArgb(0, 192, 0);
            AddButton.BackgroundImageLayout = ImageLayout.Zoom;
            AddButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AddButton.ForeColor = Color.White;
            AddButton.ImageAlign = ContentAlignment.TopLeft;
            AddButton.Location = new Point(405, 347);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(109, 35);
            AddButton.TabIndex = 4;
            AddButton.Text = "Add";
            AddButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            AddButton.UseVisualStyleBackColor = false;
            // 
            // DataSoundForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 494);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DataSoundForm";
            StartPosition = FormStartPosition.CenterParent;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataSoundGrid).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label1;
        private DataGridView DataSoundGrid;
        private Panel panel1;
        private Button AddButton;
    }
}