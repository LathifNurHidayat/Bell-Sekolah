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
            panel4 = new Panel();
            JamKhususRadio = new RadioButton();
            JamNormalRadio = new RadioButton();
            HariText = new Label();
            JamKhususGrid = new DataGridView();
            JamNormalGrid = new DataGridView();
            UbahWaktuNormalButton = new Button();
            UbahWaktuKhususButton = new Button();
            TambahNormalButton = new Button();
            TambahKhususButton = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)JadwalBelGrid).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)JamKhususGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)JamNormalGrid).BeginInit();
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
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AddButton.BackColor = Color.Goldenrod;
            AddButton.BackgroundImageLayout = ImageLayout.Zoom;
            AddButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AddButton.ForeColor = Color.White;
            AddButton.Image = (Image)resources.GetObject("AddButton.Image");
            AddButton.Location = new Point(847, 166);
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
            JadwalBelGrid.Location = new Point(5, 5);
            JadwalBelGrid.Name = "JadwalBelGrid";
            JadwalBelGrid.RowHeadersWidth = 51;
            JadwalBelGrid.RowTemplate.Height = 29;
            JadwalBelGrid.Size = new Size(951, 156);
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
            panel3.Size = new Size(963, 210);
            panel3.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.LightGray;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(TambahKhususButton);
            panel4.Controls.Add(TambahNormalButton);
            panel4.Controls.Add(UbahWaktuKhususButton);
            panel4.Controls.Add(UbahWaktuNormalButton);
            panel4.Controls.Add(JamKhususRadio);
            panel4.Controls.Add(JamNormalRadio);
            panel4.Controls.Add(HariText);
            panel4.Controls.Add(JamKhususGrid);
            panel4.Controls.Add(JamNormalGrid);
            panel4.Location = new Point(12, 353);
            panel4.Name = "panel4";
            panel4.Size = new Size(963, 375);
            panel4.TabIndex = 4;
            // 
            // JamKhususRadio
            // 
            JamKhususRadio.AutoSize = true;
            JamKhususRadio.Location = new Point(482, 79);
            JamKhususRadio.Name = "JamKhususRadio";
            JamKhususRadio.Size = new Size(101, 24);
            JamKhususRadio.TabIndex = 7;
            JamKhususRadio.TabStop = true;
            JamKhususRadio.Text = "JamKhusus";
            JamKhususRadio.UseVisualStyleBackColor = true;
            // 
            // JamNormalRadio
            // 
            JamNormalRadio.AutoSize = true;
            JamNormalRadio.Location = new Point(21, 79);
            JamNormalRadio.Name = "JamNormalRadio";
            JamNormalRadio.Size = new Size(110, 24);
            JamNormalRadio.TabIndex = 6;
            JamNormalRadio.TabStop = true;
            JamNormalRadio.Text = "Jam Normal";
            JamNormalRadio.UseVisualStyleBackColor = true;
            // 
            // HariText
            // 
            HariText.AutoSize = true;
            HariText.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            HariText.Location = new Point(21, 11);
            HariText.Name = "HariText";
            HariText.Size = new Size(106, 46);
            HariText.TabIndex = 5;
            HariText.Text = "Senin";
            // 
            // JamKhususGrid
            // 
            JamKhususGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            JamKhususGrid.BackgroundColor = SystemColors.Control;
            JamKhususGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JamKhususGrid.Location = new Point(492, 109);
            JamKhususGrid.Name = "JamKhususGrid";
            JamKhususGrid.RowHeadersWidth = 51;
            JamKhususGrid.RowTemplate.Height = 29;
            JamKhususGrid.Size = new Size(449, 156);
            JamKhususGrid.TabIndex = 4;
            // 
            // JamNormalGrid
            // 
            JamNormalGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            JamNormalGrid.BackgroundColor = SystemColors.Control;
            JamNormalGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JamNormalGrid.Location = new Point(21, 109);
            JamNormalGrid.Name = "JamNormalGrid";
            JamNormalGrid.RowHeadersWidth = 51;
            JamNormalGrid.RowTemplate.Height = 29;
            JamNormalGrid.Size = new Size(449, 156);
            JamNormalGrid.TabIndex = 3;
            // 
            // UbahWaktuNormalButton
            // 
            UbahWaktuNormalButton.BackColor = Color.Gray;
            UbahWaktuNormalButton.FlatAppearance.BorderColor = Color.White;
            UbahWaktuNormalButton.FlatStyle = FlatStyle.Flat;
            UbahWaktuNormalButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            UbahWaktuNormalButton.ForeColor = Color.White;
            UbahWaktuNormalButton.ImageAlign = ContentAlignment.MiddleRight;
            UbahWaktuNormalButton.Location = new Point(137, 71);
            UbahWaktuNormalButton.Name = "UbahWaktuNormalButton";
            UbahWaktuNormalButton.Size = new Size(118, 32);
            UbahWaktuNormalButton.TabIndex = 5;
            UbahWaktuNormalButton.Text = "Ubah Waktu";
            UbahWaktuNormalButton.UseVisualStyleBackColor = false;
            // 
            // UbahWaktuKhususButton
            // 
            UbahWaktuKhususButton.BackColor = Color.Gray;
            UbahWaktuKhususButton.FlatAppearance.BorderColor = Color.White;
            UbahWaktuKhususButton.FlatStyle = FlatStyle.Flat;
            UbahWaktuKhususButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            UbahWaktuKhususButton.ForeColor = Color.White;
            UbahWaktuKhususButton.ImageAlign = ContentAlignment.MiddleRight;
            UbahWaktuKhususButton.Location = new Point(589, 71);
            UbahWaktuKhususButton.Name = "UbahWaktuKhususButton";
            UbahWaktuKhususButton.Size = new Size(118, 32);
            UbahWaktuKhususButton.TabIndex = 9;
            UbahWaktuKhususButton.Text = "Ubah Waktu";
            UbahWaktuKhususButton.UseVisualStyleBackColor = false;
            // 
            // TambahNormalButton
            // 
            TambahNormalButton.BackColor = Color.Gray;
            TambahNormalButton.FlatAppearance.BorderColor = Color.White;
            TambahNormalButton.FlatStyle = FlatStyle.Flat;
            TambahNormalButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TambahNormalButton.ForeColor = Color.White;
            TambahNormalButton.ImageAlign = ContentAlignment.MiddleRight;
            TambahNormalButton.Location = new Point(352, 271);
            TambahNormalButton.Name = "TambahNormalButton";
            TambahNormalButton.Size = new Size(118, 33);
            TambahNormalButton.TabIndex = 10;
            TambahNormalButton.Text = "Ubah Waktu";
            TambahNormalButton.UseVisualStyleBackColor = false;
            // 
            // TambahKhususButton
            // 
            TambahKhususButton.BackColor = Color.Gray;
            TambahKhususButton.FlatAppearance.BorderColor = Color.White;
            TambahKhususButton.FlatStyle = FlatStyle.Flat;
            TambahKhususButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TambahKhususButton.ForeColor = Color.White;
            TambahKhususButton.ImageAlign = ContentAlignment.MiddleRight;
            TambahKhususButton.Location = new Point(823, 271);
            TambahKhususButton.Name = "TambahKhususButton";
            TambahKhususButton.Size = new Size(118, 33);
            TambahKhususButton.TabIndex = 11;
            TambahKhususButton.Text = "Ubah Waktu";
            TambahKhususButton.UseVisualStyleBackColor = false;
            // 
            // JadwalBelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 739);
            Controls.Add(panel4);
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
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)JamKhususGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)JamNormalGrid).EndInit();
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
        private Panel panel4;
        private DataGridView JamNormalGrid;
        private Label HariText;
        private DataGridView JamKhususGrid;
        private RadioButton JamKhususRadio;
        private RadioButton JamNormalRadio;
        private Button button2;
        private Button UbahWaktuNormalButton;
        private Button UbahWaktuKhususButton;
        private Button TambahNormalButton;
        private Button TambahKhususButton;
    }
}