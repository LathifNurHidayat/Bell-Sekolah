namespace BelSekolah.BelSekolahForm.HitungMundurForm
{
    partial class StopBelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StopBelForm));
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
            label1.Location = new Point(31, 9);
            label1.Name = "label1";
            label1.Size = new Size(316, 32);
            label1.TabIndex = 3;
            label1.Text = "Aplikasi akan ditutup dalam ";
            // 
            // BatalkanButton
            // 
            BatalkanButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BatalkanButton.BackColor = Color.DarkKhaki;
            BatalkanButton.ForeColor = Color.White;
            BatalkanButton.Location = new Point(255, 115);
            BatalkanButton.Margin = new Padding(3, 2, 3, 2);
            BatalkanButton.Name = "BatalkanButton";
            BatalkanButton.Size = new Size(96, 35);
            BatalkanButton.TabIndex = 6;
            BatalkanButton.Text = "Batalkan";
            BatalkanButton.UseVisualStyleBackColor = false;
            // 
            // HitungMundurText
            // 
            HitungMundurText.Anchor = AnchorStyles.None;
            HitungMundurText.BackColor = SystemColors.Menu;
            HitungMundurText.BorderStyle = BorderStyle.None;
            HitungMundurText.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            HitungMundurText.Location = new Point(145, 59);
            HitungMundurText.Margin = new Padding(3, 2, 3, 2);
            HitungMundurText.Name = "HitungMundurText";
            HitungMundurText.Size = new Size(70, 39);
            HitungMundurText.TabIndex = 8;
            HitungMundurText.Text = "30";
            HitungMundurText.TextAlign = HorizontalAlignment.Center;
            // 
            // HitungMundurForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 160);
            Controls.Add(HitungMundurText);
            Controls.Add(BatalkanButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
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