namespace BelSekolah.BelSekolahForm.PopUpForm.PopUp_Input_Lagu
{
    partial class InputLaguForm
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
            panel1 = new Panel();
            label4 = new Label();
            JamIstirahat2Text = new TextBox();
            label3 = new Label();
            JamIstirahat1Text = new TextBox();
            label1 = new Label();
            AturButton = new Button();
            IntervalText = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Gainsboro;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(JamIstirahat2Text);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(JamIstirahat1Text);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(AturButton);
            panel1.Controls.Add(IntervalText);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 322);
            panel1.TabIndex = 174;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(20, 167);
            label4.Name = "label4";
            label4.Size = new Size(102, 23);
            label4.TabIndex = 174;
            label4.Text = "Lagu Ke - 3 ";
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
            label3.Size = new Size(97, 23);
            label3.TabIndex = 172;
            label3.Text = "Lagu Ke - 2";
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
            label1.Size = new Size(97, 23);
            label1.TabIndex = 170;
            label1.Text = "Lagu Ke - 1";
            // 
            // AturButton
            // 
            AturButton.BackColor = Color.DarkGray;
            AturButton.FlatAppearance.BorderColor = Color.Black;
            AturButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AturButton.ForeColor = Color.White;
            AturButton.Location = new Point(235, 198);
            AturButton.Name = "AturButton";
            AturButton.Size = new Size(102, 38);
            AturButton.TabIndex = 167;
            AturButton.Text = "Atur";
            AturButton.UseVisualStyleBackColor = false;
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
            // InputLaguForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 346);
            Controls.Add(panel1);
            Name = "InputLaguForm";
            StartPosition = FormStartPosition.CenterParent;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private TextBox JamIstirahat2Text;
        private Label label3;
        private TextBox JamIstirahat1Text;
        private Label label1;
        private Button AturButton;
        private TextBox IntervalText;
    }
}