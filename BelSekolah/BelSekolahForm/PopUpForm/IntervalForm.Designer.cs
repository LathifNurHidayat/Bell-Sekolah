namespace BelSekolah.BelSekolahForm.PopUpForm
{
    partial class IntervalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntervalForm));
            IntervalText = new TextBox();
            label2 = new Label();
            AturButton = new Button();
            panel1 = new Panel();
            label5 = new Label();
            JamPelajaranCombo = new ComboBox();
            label4 = new Label();
            JamIstirahat2Text = new TextBox();
            label3 = new Label();
            JamIstirahat1Text = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // IntervalText
            // 
            IntervalText.BorderStyle = BorderStyle.FixedSingle;
            IntervalText.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            IntervalText.Location = new Point(175, 66);
            IntervalText.MaxLength = 2;
            IntervalText.Name = "IntervalText";
            IntervalText.Size = new Size(102, 30);
            IntervalText.TabIndex = 169;
            IntervalText.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(84, 16);
            label2.Name = "label2";
            label2.Size = new Size(126, 28);
            label2.TabIndex = 168;
            label2.Text = "Atur Interval";
            // 
            // AturButton
            // 
            AturButton.BackColor = Color.DarkGray;
            AturButton.FlatAppearance.BorderColor = Color.Black;
            AturButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AturButton.ForeColor = Color.White;
            AturButton.Location = new Point(94, 206);
            AturButton.Name = "AturButton";
            AturButton.Size = new Size(102, 38);
            AturButton.TabIndex = 167;
            AturButton.Text = "Atur";
            AturButton.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Gainsboro;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(JamPelajaranCombo);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(JamIstirahat2Text);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(JamIstirahat1Text);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(AturButton);
            panel1.Controls.Add(IntervalText);
            panel1.Location = new Point(12, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(297, 263);
            panel1.TabIndex = 170;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(20, 17);
            label5.Name = "label5";
            label5.Size = new Size(122, 23);
            label5.TabIndex = 176;
            label5.Text = "Dari Jam ke    :";
            // 
            // JamPelajaranCombo
            // 
            JamPelajaranCombo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            JamPelajaranCombo.FormattingEnabled = true;
            JamPelajaranCombo.Location = new Point(148, 17);
            JamPelajaranCombo.Name = "JamPelajaranCombo";
            JamPelajaranCombo.Size = new Size(129, 31);
            JamPelajaranCombo.TabIndex = 175;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(20, 167);
            label4.Name = "label4";
            label4.Size = new Size(145, 23);
            label4.TabIndex = 174;
            label4.Text = "Jam Istirahat 2    :";
            // 
            // JamIstirahat2Text
            // 
            JamIstirahat2Text.BorderStyle = BorderStyle.FixedSingle;
            JamIstirahat2Text.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            JamIstirahat2Text.Location = new Point(175, 162);
            JamIstirahat2Text.MaxLength = 2;
            JamIstirahat2Text.Name = "JamIstirahat2Text";
            JamIstirahat2Text.Size = new Size(102, 30);
            JamIstirahat2Text.TabIndex = 173;
            JamIstirahat2Text.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(20, 117);
            label3.Name = "label3";
            label3.Size = new Size(145, 23);
            label3.TabIndex = 172;
            label3.Text = "Jam Istirahat 1    :";
            // 
            // JamIstirahat1Text
            // 
            JamIstirahat1Text.BorderStyle = BorderStyle.FixedSingle;
            JamIstirahat1Text.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            JamIstirahat1Text.Location = new Point(175, 114);
            JamIstirahat1Text.MaxLength = 2;
            JamIstirahat1Text.Name = "JamIstirahat1Text";
            JamIstirahat1Text.Size = new Size(102, 30);
            JamIstirahat1Text.TabIndex = 171;
            JamIstirahat1Text.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(20, 67);
            label1.Name = "label1";
            label1.Size = new Size(149, 23);
            label1.TabIndex = 170;
            label1.Text = "Masukan Interval :";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Gainsboro;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(297, 65);
            panel2.TabIndex = 171;
            // 
            // IntervalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 358);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "IntervalForm";
            StartPosition = FormStartPosition.CenterParent;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox IntervalText;
        private Label label2;
        private Button AturButton;
        private Panel panel1;
        private Label label4;
        private TextBox JamIstirahat2Text;
        private Label label3;
        private TextBox JamIstirahat1Text;
        private Label label1;
        private Panel panel2;
        private ComboBox JamPelajaranCombo;
        private Label label5;
    }
}