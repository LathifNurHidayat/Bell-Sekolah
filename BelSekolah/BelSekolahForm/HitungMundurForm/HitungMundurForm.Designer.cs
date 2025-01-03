namespace BelSekolah.BelSekolahForm.HitungMundurForm
{
    partial class HitungMundurForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HitungMundurForm));
            label1 = new Label();
            BatalkanButton = new Button();
            HitungMundurText = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(391, 41);
            label1.TabIndex = 3;
            label1.Text = "Aplikasi akan ditutup dalam ";
            // 
            // BatalkanButton
            // 
            BatalkanButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BatalkanButton.BackColor = Color.DarkKhaki;
            BatalkanButton.ForeColor = Color.White;
            BatalkanButton.Location = new Point(292, 169);
            BatalkanButton.Name = "BatalkanButton";
            BatalkanButton.Size = new Size(110, 35);
            BatalkanButton.TabIndex = 6;
            BatalkanButton.Text = "Batalkan";
            BatalkanButton.UseVisualStyleBackColor = false;
            // 
            // HitungMundurText
            // 
            HitungMundurText.BackColor = SystemColors.Menu;
            HitungMundurText.BorderStyle = BorderStyle.None;
            HitungMundurText.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            HitungMundurText.Location = new Point(171, 91);
            HitungMundurText.Name = "HitungMundurText";
            HitungMundurText.Size = new Size(80, 44);
            HitungMundurText.TabIndex = 8;
            HitungMundurText.Text = "30";
            HitungMundurText.TextAlign = HorizontalAlignment.Center;
            // 
            // HitungMundurForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 216);
            Controls.Add(HitungMundurText);
            Controls.Add(BatalkanButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HitungMundurForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button BatalkanButton;
        private TextBox HitungMundurText;
    }
}