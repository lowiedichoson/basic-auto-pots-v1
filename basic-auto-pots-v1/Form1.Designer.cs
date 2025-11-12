namespace basic_auto_pots_v1
{
    partial class main_form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            label1 = new Label();
            label_status = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(36, 29);
            label1.MaximumSize = new Size(400, 0);
            label1.Name = "label1";
            label1.Size = new Size(318, 28);
            label1.TabIndex = 0;
            label1.Text = "Press right click to start QWER keys";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_status
            // 
            label_status.AutoSize = true;
            label_status.Font = new Font("Segoe UI", 11F);
            label_status.Location = new Point(125, 93);
            label_status.Name = "label_status";
            label_status.Size = new Size(140, 25);
            label_status.TabIndex = 1;
            label_status.Text = "Status: Stopped";
            // 
            // main_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 203);
            Controls.Add(label_status);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "main_form";
            Text = "Basic - Auto Potion V1.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label_status;
    }
}
