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
            label_status = new Label();
            cb_auto_ctrl = new CheckBox();
            btn_start = new Button();
            cb_auto_qwer = new CheckBox();
            gb_options = new GroupBox();
            txt_box_delay = new TextBox();
            lbl_delay_pots = new Label();
            lbl_title_rmb = new Label();
            gb_status = new GroupBox();
            label_rmb_status = new Label();
            lbl_title_status = new Label();
            gb_options.SuspendLayout();
            gb_status.SuspendLayout();
            SuspendLayout();
            // 
            // label_status
            // 
            label_status.AutoSize = true;
            label_status.Font = new Font("Segoe UI", 9F);
            label_status.Location = new Point(63, 23);
            label_status.Name = "label_status";
            label_status.Size = new Size(51, 15);
            label_status.TabIndex = 1;
            label_status.Text = "Stopped";
            // 
            // cb_auto_ctrl
            // 
            cb_auto_ctrl.AutoSize = true;
            cb_auto_ctrl.Location = new Point(6, 47);
            cb_auto_ctrl.Name = "cb_auto_ctrl";
            cb_auto_ctrl.Size = new Size(106, 19);
            cb_auto_ctrl.TabIndex = 2;
            cb_auto_ctrl.Text = "Hold Left CTRL";
            cb_auto_ctrl.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            btn_start.BackColor = Color.FromArgb(192, 255, 192);
            btn_start.FlatAppearance.BorderSize = 0;
            btn_start.FlatStyle = FlatStyle.Flat;
            btn_start.Location = new Point(69, 99);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(75, 23);
            btn_start.TabIndex = 4;
            btn_start.Text = "Start (F8)";
            btn_start.UseVisualStyleBackColor = false;
            btn_start.Click += btn_start_Click;
            // 
            // cb_auto_qwer
            // 
            cb_auto_qwer.AutoSize = true;
            cb_auto_qwer.Location = new Point(6, 22);
            cb_auto_qwer.Name = "cb_auto_qwer";
            cb_auto_qwer.Size = new Size(89, 19);
            cb_auto_qwer.TabIndex = 3;
            cb_auto_qwer.Text = "Loop QWER";
            cb_auto_qwer.UseVisualStyleBackColor = true;
            // 
            // gb_options
            // 
            gb_options.Controls.Add(txt_box_delay);
            gb_options.Controls.Add(lbl_delay_pots);
            gb_options.Controls.Add(cb_auto_qwer);
            gb_options.Controls.Add(cb_auto_ctrl);
            gb_options.Location = new Point(12, 12);
            gb_options.Name = "gb_options";
            gb_options.Size = new Size(150, 128);
            gb_options.TabIndex = 5;
            gb_options.TabStop = false;
            gb_options.Text = "Macro Settings";
            // 
            // txt_box_delay
            // 
            txt_box_delay.Location = new Point(91, 66);
            txt_box_delay.Name = "txt_box_delay";
            txt_box_delay.Size = new Size(49, 23);
            txt_box_delay.TabIndex = 5;
            // 
            // lbl_delay_pots
            // 
            lbl_delay_pots.AutoSize = true;
            lbl_delay_pots.Location = new Point(6, 69);
            lbl_delay_pots.Name = "lbl_delay_pots";
            lbl_delay_pots.Size = new Size(79, 15);
            lbl_delay_pots.TabIndex = 4;
            lbl_delay_pots.Text = "Delay (in ms):";
            // 
            // lbl_title_rmb
            // 
            lbl_title_rmb.AutoSize = true;
            lbl_title_rmb.Location = new Point(6, 48);
            lbl_title_rmb.Name = "lbl_title_rmb";
            lbl_title_rmb.Size = new Size(70, 15);
            lbl_title_rmb.TabIndex = 5;
            lbl_title_rmb.Text = "RMB Status:";
            // 
            // gb_status
            // 
            gb_status.Controls.Add(label_rmb_status);
            gb_status.Controls.Add(lbl_title_status);
            gb_status.Controls.Add(lbl_title_rmb);
            gb_status.Controls.Add(label_status);
            gb_status.Controls.Add(btn_start);
            gb_status.Location = new Point(172, 12);
            gb_status.Name = "gb_status";
            gb_status.Size = new Size(150, 128);
            gb_status.TabIndex = 6;
            gb_status.TabStop = false;
            gb_status.Text = "Activation";
            // 
            // label_rmb_status
            // 
            label_rmb_status.AutoSize = true;
            label_rmb_status.Location = new Point(76, 48);
            label_rmb_status.Name = "label_rmb_status";
            label_rmb_status.Size = new Size(51, 15);
            label_rmb_status.TabIndex = 7;
            label_rmb_status.Text = "Stopped";
            // 
            // lbl_title_status
            // 
            lbl_title_status.AutoSize = true;
            lbl_title_status.Location = new Point(6, 23);
            lbl_title_status.Name = "lbl_title_status";
            lbl_title_status.Size = new Size(57, 15);
            lbl_title_status.TabIndex = 6;
            lbl_title_status.Text = "F8 Status:";
            // 
            // main_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(334, 152);
            Controls.Add(gb_status);
            Controls.Add(gb_options);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "main_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Basic - Auto Potion V1.0";
            gb_options.ResumeLayout(false);
            gb_options.PerformLayout();
            gb_status.ResumeLayout(false);
            gb_status.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label_status;
        private CheckBox cb_auto_ctrl;
        private CheckBox cb_auto_qwer;
        private Button btn_start;
        private GroupBox gb_options;
        private Label lbl_title_rmb;
        private GroupBox gb_status;
        private Label lbl_title_status;
        private Label label_rmb_status;
        private TextBox txt_box_delay;
        private Label lbl_delay_pots;
    }
}
