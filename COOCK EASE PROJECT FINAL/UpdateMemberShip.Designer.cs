namespace COOCK_EASE_PROJECT_FINAL
{
    partial class UpdateMemberShip
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
            panel2 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            panel5 = new Panel();
            dateTimePicker2 = new DateTimePicker();
            label6 = new Label();
            button1 = new Button();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(12, 91);
            panel2.Name = "panel2";
            panel2.Size = new Size(696, 58);
            panel2.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(268, 14);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(277, 26);
            dateTimePicker1.TabIndex = 1;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 18);
            label3.Name = "label3";
            label3.Size = new Size(218, 22);
            label3.TabIndex = 0;
            label3.Text = "Start Date of Member Ship :";
            // 
            // panel5
            // 
            panel5.Controls.Add(dateTimePicker2);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(12, 175);
            panel5.Name = "panel5";
            panel5.Size = new Size(696, 58);
            panel5.TabIndex = 11;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(268, 14);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(277, 26);
            dateTimePicker2.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 18);
            label6.Name = "label6";
            label6.Size = new Size(208, 22);
            label6.TabIndex = 0;
            label6.Text = "End Date of Member Ship :";
            // 
            // button1
            // 
            button1.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(308, 292);
            button1.Name = "button1";
            button1.Size = new Size(98, 38);
            button1.TabIndex = 13;
            button1.Text = "Enter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UpdateMemberShip
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 419);
            Controls.Add(button1);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Name = "UpdateMemberShip";
            Text = "UpdateMemberShip";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Panel panel5;
        private DateTimePicker dateTimePicker2;
        private Label label6;
        private Button button1;
    }
}