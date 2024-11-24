namespace BelSekolah.BelSekolahForm
{
    partial class JadwalBelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JadwalBelForm));
            panel1 = new Panel();
            AddNormalButton = new Button();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            JadwalBelGrid = new DataGridView();
            panel3 = new Panel();
            NormalCheckBox = new CheckBox();
            KhususCheckBox = new CheckBox();
            AddKhususButton = new Button();
            dataGridView1 = new DataGridView();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)JadwalBelGrid).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 77);
            panel1.Name = "panel1";
            panel1.Size = new Size(987, 39);
            panel1.TabIndex = 0;
            // 
            // AddNormalButton
            // 
            AddNormalButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AddNormalButton.BackColor = Color.Goldenrod;
            AddNormalButton.BackgroundImageLayout = ImageLayout.Zoom;
            AddNormalButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AddNormalButton.ForeColor = Color.White;
            AddNormalButton.Image = (Image)resources.GetObject("AddNormalButton.Image");
            AddNormalButton.Location = new Point(847, 401);
            AddNormalButton.Name = "AddNormalButton";
            AddNormalButton.Size = new Size(109, 39);
            AddNormalButton.TabIndex = 2;
            AddNormalButton.Text = "Add";
            AddNormalButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            AddNormalButton.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGray;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(987, 77);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Yi Baiti", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(73, 19);
            label1.Name = "label1";
            label1.Size = new Size(312, 40);
            label1.TabIndex = 3;
            label1.Text = "Aplikasi Bel Sekolah";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.bell;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(14, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(46, 48);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // JadwalBelGrid
            // 
            JadwalBelGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            JadwalBelGrid.BackgroundColor = SystemColors.Control;
            JadwalBelGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JadwalBelGrid.Location = new Point(5, 46);
            JadwalBelGrid.Name = "JadwalBelGrid";
            JadwalBelGrid.RowHeadersWidth = 51;
            JadwalBelGrid.RowTemplate.Height = 29;
            JadwalBelGrid.Size = new Size(951, 349);
            JadwalBelGrid.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.LightGray;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(NormalCheckBox);
            panel3.Controls.Add(KhususCheckBox);
            panel3.Controls.Add(AddKhususButton);
            panel3.Controls.Add(dataGridView1);
            panel3.Controls.Add(AddNormalButton);
            panel3.Controls.Add(JadwalBelGrid);
            panel3.Location = new Point(12, 131);
            panel3.Name = "panel3";
            panel3.Size = new Size(963, 806);
            panel3.TabIndex = 3;
            // 
            // NormalCheckBox
            // 
            NormalCheckBox.AutoSize = true;
            NormalCheckBox.Location = new Point(5, 16);
            NormalCheckBox.Name = "NormalCheckBox";
            NormalCheckBox.Size = new Size(130, 24);
            NormalCheckBox.TabIndex = 6;
            NormalCheckBox.Text = "Jadwal Normal";
            NormalCheckBox.UseVisualStyleBackColor = true;
            // 
            // KhususCheckBox
            // 
            KhususCheckBox.AutoSize = true;
            KhususCheckBox.Location = new Point(5, 457);
            KhususCheckBox.Name = "KhususCheckBox";
            KhususCheckBox.Size = new Size(125, 24);
            KhususCheckBox.TabIndex = 5;
            KhususCheckBox.Text = "Jadwal Khusus";
            KhususCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddKhususButton
            // 
            AddKhususButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AddKhususButton.BackColor = Color.Goldenrod;
            AddKhususButton.BackgroundImageLayout = ImageLayout.Zoom;
            AddKhususButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AddKhususButton.ForeColor = Color.White;
            AddKhususButton.Image = (Image)resources.GetObject("AddKhususButton.Image");
            AddKhususButton.Location = new Point(847, 758);
            AddKhususButton.Name = "AddKhususButton";
            AddKhususButton.Size = new Size(109, 39);
            AddKhususButton.TabIndex = 4;
            AddKhususButton.Text = "Add";
            AddKhususButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            AddKhususButton.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(5, 487);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(951, 265);
            dataGridView1.TabIndex = 3;
            // 
            // JadwalBelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 949);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "JadwalBelForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "JadwalBelForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)JadwalBelGrid).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private PictureBox pictureBox1;
        private Button AddNormalButton;
        private DataGridView JadwalBelGrid;
        private Panel panel3;
        private Button button2;
        private Button AddKhususButton;
        private DataGridView dataGridView1;
        private CheckBox NormalCheckBox;
        private CheckBox KhususCheckBox;
    }
}