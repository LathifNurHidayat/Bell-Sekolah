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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JadwalBelForm));
            MainPanel = new Panel();
            JadwalkanRunBelButton = new Button();
            JadwalkanButton = new Button();
            JadwalNormalRadio = new RadioButton();
            TambahNormalButton = new Button();
            DeleteNormalButton = new Button();
            JadwalNormalGrid = new DataGridView();
            JadwalKhususGrid = new DataGridView();
            TambahKhususButton = new Button();
            DeleteKhususButton = new Button();
            JadwalKhususRadio = new RadioButton();
            StartStopButton = new Button();
            HariCombo = new ComboBox();
            panel5 = new Panel();
            label2 = new Label();
            panel1 = new Panel();
            RunningLabel = new Label();
            label3 = new Label();
            HariText = new TextBox();
            contextMenuStrip2 = new ContextMenuStrip(components);
            JadwalKhususToolStripMenuItem = new ToolStripMenuItem();
            JadwalUjianToolStripMenuItem1 = new ToolStripMenuItem();
            panel2 = new Panel();
            DetailJadwalLinkLabel = new LinkLabel();
            JamLabel = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)JadwalNormalGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)JadwalKhususGrid).BeginInit();
            panel5.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainPanel.BackColor = Color.LightGray;
            MainPanel.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Controls.Add(JadwalkanRunBelButton);
            MainPanel.Controls.Add(JadwalkanButton);
            MainPanel.Controls.Add(JadwalNormalRadio);
            MainPanel.Controls.Add(TambahNormalButton);
            MainPanel.Controls.Add(DeleteNormalButton);
            MainPanel.Controls.Add(JadwalNormalGrid);
            MainPanel.Controls.Add(JadwalKhususGrid);
            MainPanel.Controls.Add(TambahKhususButton);
            MainPanel.Controls.Add(DeleteKhususButton);
            MainPanel.Controls.Add(JadwalKhususRadio);
            MainPanel.Controls.Add(StartStopButton);
            MainPanel.Controls.Add(HariCombo);
            MainPanel.Controls.Add(panel5);
            MainPanel.Location = new Point(9, 68);
            MainPanel.Margin = new Padding(3, 2, 3, 2);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1057, 432);
            MainPanel.TabIndex = 0;
            // 
            // JadwalkanRunBelButton
            // 
            JadwalkanRunBelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            JadwalkanRunBelButton.BackColor = SystemColors.GrayText;
            JadwalkanRunBelButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            JadwalkanRunBelButton.ForeColor = Color.White;
            JadwalkanRunBelButton.Location = new Point(663, 40);
            JadwalkanRunBelButton.Name = "JadwalkanRunBelButton";
            JadwalkanRunBelButton.Size = new Size(129, 29);
            JadwalkanRunBelButton.TabIndex = 23;
            JadwalkanRunBelButton.Text = "Jadwalkan Run Bel";
            JadwalkanRunBelButton.UseVisualStyleBackColor = false;
            // 
            // JadwalkanButton
            // 
            JadwalkanButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            JadwalkanButton.BackColor = Color.DarkKhaki;
            JadwalkanButton.BackgroundImageLayout = ImageLayout.Stretch;
            JadwalkanButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            JadwalkanButton.ForeColor = Color.WhiteSmoke;
            JadwalkanButton.Image = Properties.Resources.schedule__1_;
            JadwalkanButton.ImageAlign = ContentAlignment.MiddleLeft;
            JadwalkanButton.Location = new Point(807, 40);
            JadwalkanButton.Margin = new Padding(3, 2, 3, 2);
            JadwalkanButton.Name = "JadwalkanButton";
            JadwalkanButton.Size = new Size(122, 29);
            JadwalkanButton.TabIndex = 7;
            JadwalkanButton.Text = "Jadwalkan Bel";
            JadwalkanButton.TextAlign = ContentAlignment.MiddleRight;
            JadwalkanButton.UseVisualStyleBackColor = false;
            // 
            // JadwalNormalRadio
            // 
            JadwalNormalRadio.AutoSize = true;
            JadwalNormalRadio.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            JadwalNormalRadio.Location = new Point(18, 72);
            JadwalNormalRadio.Margin = new Padding(3, 2, 3, 2);
            JadwalNormalRadio.Name = "JadwalNormalRadio";
            JadwalNormalRadio.Size = new Size(121, 23);
            JadwalNormalRadio.TabIndex = 1;
            JadwalNormalRadio.Text = "Jadwal Normal";
            JadwalNormalRadio.UseVisualStyleBackColor = true;
            // 
            // TambahNormalButton
            // 
            TambahNormalButton.Anchor = AnchorStyles.Bottom;
            TambahNormalButton.BackColor = Color.Goldenrod;
            TambahNormalButton.BackgroundImageLayout = ImageLayout.Zoom;
            TambahNormalButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TambahNormalButton.ForeColor = Color.White;
            TambahNormalButton.ImageAlign = ContentAlignment.MiddleLeft;
            TambahNormalButton.Location = new Point(18, 385);
            TambahNormalButton.Margin = new Padding(3, 2, 3, 2);
            TambahNormalButton.Name = "TambahNormalButton";
            TambahNormalButton.Size = new Size(95, 29);
            TambahNormalButton.TabIndex = 2;
            TambahNormalButton.Text = "Tambah";
            TambahNormalButton.TextImageRelation = TextImageRelation.TextAboveImage;
            TambahNormalButton.UseVisualStyleBackColor = false;
            // 
            // DeleteNormalButton
            // 
            DeleteNormalButton.Anchor = AnchorStyles.Bottom;
            DeleteNormalButton.BackColor = Color.Red;
            DeleteNormalButton.BackgroundImageLayout = ImageLayout.Zoom;
            DeleteNormalButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteNormalButton.ForeColor = Color.White;
            DeleteNormalButton.Location = new Point(118, 385);
            DeleteNormalButton.Margin = new Padding(3, 2, 3, 2);
            DeleteNormalButton.Name = "DeleteNormalButton";
            DeleteNormalButton.Size = new Size(95, 29);
            DeleteNormalButton.TabIndex = 3;
            DeleteNormalButton.Text = "Delete";
            DeleteNormalButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            DeleteNormalButton.UseVisualStyleBackColor = false;
            // 
            // JadwalNormalGrid
            // 
            JadwalNormalGrid.Anchor = AnchorStyles.Top;
            JadwalNormalGrid.BackgroundColor = SystemColors.Control;
            JadwalNormalGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JadwalNormalGrid.Location = new Point(18, 105);
            JadwalNormalGrid.Margin = new Padding(3, 2, 3, 2);
            JadwalNormalGrid.MultiSelect = false;
            JadwalNormalGrid.Name = "JadwalNormalGrid";
            JadwalNormalGrid.ReadOnly = true;
            JadwalNormalGrid.RowHeadersWidth = 51;
            JadwalNormalGrid.RowTemplate.Height = 29;
            JadwalNormalGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            JadwalNormalGrid.Size = new Size(491, 240);
            JadwalNormalGrid.TabIndex = 22;
            JadwalNormalGrid.TabStop = false;
            // 
            // JadwalKhususGrid
            // 
            JadwalKhususGrid.Anchor = AnchorStyles.Top;
            JadwalKhususGrid.BackgroundColor = SystemColors.Control;
            JadwalKhususGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JadwalKhususGrid.Location = new Point(538, 105);
            JadwalKhususGrid.Margin = new Padding(3, 2, 3, 2);
            JadwalKhususGrid.MultiSelect = false;
            JadwalKhususGrid.Name = "JadwalKhususGrid";
            JadwalKhususGrid.ReadOnly = true;
            JadwalKhususGrid.RowHeadersWidth = 51;
            JadwalKhususGrid.RowTemplate.Height = 29;
            JadwalKhususGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            JadwalKhususGrid.Size = new Size(499, 240);
            JadwalKhususGrid.TabIndex = 21;
            JadwalKhususGrid.TabStop = false;
            // 
            // TambahKhususButton
            // 
            TambahKhususButton.Anchor = AnchorStyles.Bottom;
            TambahKhususButton.BackColor = Color.Goldenrod;
            TambahKhususButton.BackgroundImageLayout = ImageLayout.Zoom;
            TambahKhususButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TambahKhususButton.ForeColor = Color.White;
            TambahKhususButton.Location = new Point(538, 385);
            TambahKhususButton.Margin = new Padding(3, 2, 3, 2);
            TambahKhususButton.Name = "TambahKhususButton";
            TambahKhususButton.Size = new Size(95, 29);
            TambahKhususButton.TabIndex = 5;
            TambahKhususButton.Text = "Tambah";
            TambahKhususButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            TambahKhususButton.UseVisualStyleBackColor = false;
            // 
            // DeleteKhususButton
            // 
            DeleteKhususButton.Anchor = AnchorStyles.Bottom;
            DeleteKhususButton.BackColor = Color.Red;
            DeleteKhususButton.BackgroundImageLayout = ImageLayout.Zoom;
            DeleteKhususButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteKhususButton.ForeColor = Color.White;
            DeleteKhususButton.Location = new Point(639, 385);
            DeleteKhususButton.Margin = new Padding(3, 2, 3, 2);
            DeleteKhususButton.Name = "DeleteKhususButton";
            DeleteKhususButton.Size = new Size(95, 29);
            DeleteKhususButton.TabIndex = 6;
            DeleteKhususButton.Text = "Delete";
            DeleteKhususButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            DeleteKhususButton.UseVisualStyleBackColor = false;
            // 
            // JadwalKhususRadio
            // 
            JadwalKhususRadio.AutoSize = true;
            JadwalKhususRadio.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            JadwalKhususRadio.Location = new Point(538, 72);
            JadwalKhususRadio.Margin = new Padding(3, 2, 3, 2);
            JadwalKhususRadio.Name = "JadwalKhususRadio";
            JadwalKhususRadio.Size = new Size(119, 23);
            JadwalKhususRadio.TabIndex = 4;
            JadwalKhususRadio.Text = "Jadwal Khusus";
            JadwalKhususRadio.UseVisualStyleBackColor = true;
            // 
            // StartStopButton
            // 
            StartStopButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StartStopButton.BackColor = Color.LimeGreen;
            StartStopButton.BackgroundImageLayout = ImageLayout.Zoom;
            StartStopButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StartStopButton.ForeColor = Color.White;
            StartStopButton.Location = new Point(942, 40);
            StartStopButton.Margin = new Padding(3, 2, 3, 2);
            StartStopButton.Name = "StartStopButton";
            StartStopButton.Size = new Size(95, 29);
            StartStopButton.TabIndex = 8;
            StartStopButton.Text = "Start";
            StartStopButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            StartStopButton.UseVisualStyleBackColor = false;
            // 
            // HariCombo
            // 
            HariCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            HariCombo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            HariCombo.FormattingEnabled = true;
            HariCombo.Location = new Point(18, 41);
            HariCombo.Margin = new Padding(3, 2, 3, 2);
            HariCombo.Name = "HariCombo";
            HariCombo.Size = new Size(133, 29);
            HariCombo.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Gainsboro;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(label2);
            panel5.Controls.Add(panel1);
            panel5.Controls.Add(RunningLabel);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(1055, 36);
            panel5.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(47, 5);
            label2.Name = "label2";
            label2.Size = new Size(155, 24);
            label2.TabIndex = 19;
            label2.Text = "SKANSABA.DEV";
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Skansaba_dev_logo_11;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(39, 34);
            panel1.TabIndex = 23;
            // 
            // RunningLabel
            // 
            RunningLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RunningLabel.AutoSize = true;
            RunningLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            RunningLabel.Location = new Point(933, 5);
            RunningLabel.Name = "RunningLabel";
            RunningLabel.Size = new Size(99, 20);
            RunningLabel.TabIndex = 15;
            RunningLabel.Text = "Stopped . . . .";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(554, 21);
            label3.Name = "label3";
            label3.Size = new Size(43, 18);
            label3.TabIndex = 17;
            label3.Text = "Hari :";
            // 
            // HariText
            // 
            HariText.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            HariText.BackColor = Color.WhiteSmoke;
            HariText.BorderStyle = BorderStyle.FixedSingle;
            HariText.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            HariText.Location = new Point(603, 19);
            HariText.Margin = new Padding(3, 2, 3, 2);
            HariText.Name = "HariText";
            HariText.ReadOnly = true;
            HariText.Size = new Size(81, 24);
            HariText.TabIndex = 16;
            HariText.TabStop = false;
            HariText.TextAlign = HorizontalAlignment.Center;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { JadwalKhususToolStripMenuItem, JadwalUjianToolStripMenuItem1 });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(173, 56);
            // 
            // JadwalKhususToolStripMenuItem
            // 
            JadwalKhususToolStripMenuItem.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            JadwalKhususToolStripMenuItem.Image = Properties.Resources.schedule;
            JadwalKhususToolStripMenuItem.Name = "JadwalKhususToolStripMenuItem";
            JadwalKhususToolStripMenuItem.Size = new Size(172, 26);
            JadwalKhususToolStripMenuItem.Text = "Jadwal Khusus";
            // 
            // JadwalUjianToolStripMenuItem1
            // 
            JadwalUjianToolStripMenuItem1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            JadwalUjianToolStripMenuItem1.Image = Properties.Resources.time;
            JadwalUjianToolStripMenuItem1.Name = "JadwalUjianToolStripMenuItem1";
            JadwalUjianToolStripMenuItem1.Size = new Size(172, 26);
            JadwalUjianToolStripMenuItem1.Text = "Jadwal Ujian";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.LightGray;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(DetailJadwalLinkLabel);
            panel2.Controls.Add(JamLabel);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(HariText);
            panel2.Location = new Point(9, 8);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1056, 57);
            panel2.TabIndex = 5;
            // 
            // DetailJadwalLinkLabel
            // 
            DetailJadwalLinkLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DetailJadwalLinkLabel.AutoSize = true;
            DetailJadwalLinkLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            DetailJadwalLinkLabel.Location = new Point(720, 21);
            DetailJadwalLinkLabel.Name = "DetailJadwalLinkLabel";
            DetailJadwalLinkLabel.Size = new Size(178, 19);
            DetailJadwalLinkLabel.TabIndex = 18;
            DetailJadwalLinkLabel.TabStop = true;
            DetailJadwalLinkLabel.Text = "Detail Jadwal Yang Diputar";
            // 
            // JamLabel
            // 
            JamLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            JamLabel.AutoSize = true;
            JamLabel.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            JamLabel.Location = new Point(934, 14);
            JamLabel.Name = "JamLabel";
            JamLabel.Size = new Size(95, 30);
            JamLabel.TabIndex = 5;
            JamLabel.Text = "00:00:00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(88, 16);
            label1.Name = "label1";
            label1.Size = new Size(259, 26);
            label1.TabIndex = 3;
            label1.Text = "BEL SMKN 1 BANTUL";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.SMKN___BANTUL;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(-17, -14);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(102, 86);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // JadwalBelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 507);
            Controls.Add(panel2);
            Controls.Add(MainPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "JadwalBelForm";
            StartPosition = FormStartPosition.CenterScreen;
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)JadwalNormalGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)JadwalKhususGrid).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            contextMenuStrip2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button TambahKhususButton;
        private Panel MainPanel;
        private Panel panel5;
        private RadioButton JadwalKhususRadio;
        private ComboBox HariCombo;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem JadwalKhususToolStripMenuItem;
        private ToolStripMenuItem JadwalUjianToolStripMenuItem1;
        private Panel panel2;
        private Label JamLabel;
        private Label label1;
        private PictureBox pictureBox1;
        private Button StartStopButton;
        private Label RunningLabel;
        private TextBox HariText;
        private Label label3;
        private Button DeleteKhususButton;
        private Button TambahNormalButton;
        private Button DeleteNormalButton;
        private Panel JadwalNormalPanel;
        private Panel JadwalKhususPanel;
        private DataGridView JadwalKhususGrid;
        private RadioButton JadwalNormalRadio;
        private Button JadwalkanButton;
        private LinkLabel DetailJadwalLinkLabel;
        private DataGridView JadwalNormalGrid;
        private Panel panel1;
        private Label label2;
        private Button JadwalkanRunBelButton;
    }
}