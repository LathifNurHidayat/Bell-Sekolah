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
            AddButton = new Button();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            JadwalBelGrid = new DataGridView();
            panel3 = new Panel();
            MainPanel = new Panel();
            SaveButton = new Button();
            TambahKhususButton = new Button();
            textBox1 = new TextBox();
            TambahNormalButton = new Button();
            JadwalKhususGrid = new DataGridView();
            JadwalKhususRadio = new RadioButton();
            JadwalNormalRadio = new RadioButton();
            panel5 = new Panel();
            InsertUpdateLabel = new Label();
            dataGridView2 = new DataGridView();
            JadwalNormalGrid = new DataGridView();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)JadwalBelGrid).BeginInit();
            panel3.SuspendLayout();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)JadwalKhususGrid).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)JadwalNormalGrid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 77);
            panel1.Name = "panel1";
            panel1.Size = new Size(1730, 39);
            panel1.TabIndex = 0;
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AddButton.BackColor = Color.Goldenrod;
            AddButton.BackgroundImageLayout = ImageLayout.Zoom;
            AddButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AddButton.ForeColor = Color.White;
            AddButton.Image = (Image)resources.GetObject("AddButton.Image");
            AddButton.Location = new Point(1592, 266);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(109, 39);
            AddButton.TabIndex = 2;
            AddButton.Text = "Add";
            AddButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            AddButton.UseVisualStyleBackColor = false;
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
            panel2.Size = new Size(1730, 77);
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
            JadwalBelGrid.Location = new Point(5, 5);
            JadwalBelGrid.Name = "JadwalBelGrid";
            JadwalBelGrid.RowHeadersWidth = 51;
            JadwalBelGrid.RowTemplate.Height = 29;
            JadwalBelGrid.Size = new Size(1694, 255);
            JadwalBelGrid.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.LightGray;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(AddButton);
            panel3.Controls.Add(JadwalBelGrid);
            panel3.Location = new Point(12, 131);
            panel3.Name = "panel3";
            panel3.Size = new Size(1706, 310);
            panel3.TabIndex = 3;
            // 
            // MainPanel
            // 
            MainPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainPanel.BackColor = Color.LightGray;
            MainPanel.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Controls.Add(SaveButton);
            MainPanel.Controls.Add(TambahKhususButton);
            MainPanel.Controls.Add(textBox1);
            MainPanel.Controls.Add(TambahNormalButton);
            MainPanel.Controls.Add(JadwalKhususGrid);
            MainPanel.Controls.Add(JadwalKhususRadio);
            MainPanel.Controls.Add(JadwalNormalRadio);
            MainPanel.Controls.Add(panel5);
            MainPanel.Controls.Add(JadwalNormalGrid);
            MainPanel.Location = new Point(12, 450);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1706, 457);
            MainPanel.TabIndex = 4;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveButton.BackColor = Color.LimeGreen;
            SaveButton.BackgroundImageLayout = ImageLayout.Zoom;
            SaveButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(1564, 405);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(126, 37);
            SaveButton.TabIndex = 12;
            SaveButton.Text = "Save";
            SaveButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            SaveButton.UseVisualStyleBackColor = false;
            // 
            // TambahKhususButton
            // 
            TambahKhususButton.BackColor = Color.Goldenrod;
            TambahKhususButton.BackgroundImageLayout = ImageLayout.Zoom;
            TambahKhususButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TambahKhususButton.ForeColor = Color.White;
            TambahKhususButton.Location = new Point(861, 385);
            TambahKhususButton.Name = "TambahKhususButton";
            TambahKhususButton.Size = new Size(109, 39);
            TambahKhususButton.TabIndex = 10;
            TambahKhususButton.Text = "Tambah";
            TambahKhususButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            TambahKhususButton.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(13, 79);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Masukan Hari";
            textBox1.Size = new Size(161, 38);
            textBox1.TabIndex = 5;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // TambahNormalButton
            // 
            TambahNormalButton.BackColor = Color.Goldenrod;
            TambahNormalButton.BackgroundImageLayout = ImageLayout.Zoom;
            TambahNormalButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TambahNormalButton.ForeColor = Color.White;
            TambahNormalButton.Location = new Point(13, 385);
            TambahNormalButton.Name = "TambahNormalButton";
            TambahNormalButton.Size = new Size(109, 39);
            TambahNormalButton.TabIndex = 9;
            TambahNormalButton.Text = "Tambah";
            TambahNormalButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            TambahNormalButton.UseVisualStyleBackColor = false;
            // 
            // JadwalKhususGrid
            // 
            JadwalKhususGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            JadwalKhususGrid.BackgroundColor = SystemColors.Control;
            JadwalKhususGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JadwalKhususGrid.Location = new Point(861, 156);
            JadwalKhususGrid.Name = "JadwalKhususGrid";
            JadwalKhususGrid.RowHeadersWidth = 51;
            JadwalKhususGrid.RowTemplate.Height = 29;
            JadwalKhususGrid.Size = new Size(829, 223);
            JadwalKhususGrid.TabIndex = 8;
            // 
            // JadwalKhususRadio
            // 
            JadwalKhususRadio.AutoSize = true;
            JadwalKhususRadio.Location = new Point(861, 126);
            JadwalKhususRadio.Name = "JadwalKhususRadio";
            JadwalKhususRadio.Size = new Size(124, 24);
            JadwalKhususRadio.TabIndex = 7;
            JadwalKhususRadio.TabStop = true;
            JadwalKhususRadio.Text = "Jadwal Khusus";
            JadwalKhususRadio.UseVisualStyleBackColor = true;
            // 
            // JadwalNormalRadio
            // 
            JadwalNormalRadio.AutoSize = true;
            JadwalNormalRadio.Location = new Point(13, 126);
            JadwalNormalRadio.Name = "JadwalNormalRadio";
            JadwalNormalRadio.Size = new Size(129, 24);
            JadwalNormalRadio.TabIndex = 6;
            JadwalNormalRadio.TabStop = true;
            JadwalNormalRadio.Text = "Jadwal Normal";
            JadwalNormalRadio.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Silver;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(InsertUpdateLabel);
            panel5.Controls.Add(dataGridView2);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1704, 64);
            panel5.TabIndex = 5;
            // 
            // InsertUpdateLabel
            // 
            InsertUpdateLabel.AutoSize = true;
            InsertUpdateLabel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            InsertUpdateLabel.Location = new Point(12, 12);
            InsertUpdateLabel.Name = "InsertUpdateLabel";
            InsertUpdateLabel.Size = new Size(270, 41);
            InsertUpdateLabel.TabIndex = 6;
            InsertUpdateLabel.Text = "Tambah Data Baru";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(6, 122);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(300, 188);
            dataGridView2.TabIndex = 0;
            // 
            // JadwalNormalGrid
            // 
            JadwalNormalGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            JadwalNormalGrid.BackgroundColor = SystemColors.Control;
            JadwalNormalGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JadwalNormalGrid.Location = new Point(13, 156);
            JadwalNormalGrid.Name = "JadwalNormalGrid";
            JadwalNormalGrid.RowHeadersWidth = 51;
            JadwalNormalGrid.RowTemplate.Height = 29;
            JadwalNormalGrid.Size = new Size(835, 223);
            JadwalNormalGrid.TabIndex = 0;
            // 
            // JadwalBelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1730, 916);
            Controls.Add(MainPanel);
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
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)JadwalKhususGrid).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)JadwalNormalGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private PictureBox pictureBox1;
        private Button AddButton;
        private DataGridView JadwalBelGrid;
        private Panel panel3;
        private Button TambahKhususButton;
        private Panel MainPanel;
        private DataGridView JadwalNormalGrid;
        private Panel panel5;
        private DataGridView dataGridView2;
        private TextBox textBox1;
        private DataGridView JadwalKhususGrid;
        private RadioButton JadwalKhususRadio;
        private RadioButton JadwalNormalRadio;
        private Button SaveButton;
        private Button TambahNormalButton;
        private Label InsertUpdateLabel;
    }
}