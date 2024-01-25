namespace COOCK_EASE_PROJECT_FINAL
{
    partial class Coocking_Step
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
            label1 = new Label();
            button1 = new Button();
            button3 = new Button();
            label2 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            panel2 = new Panel();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(361, 64);
            label1.Name = "label1";
            label1.Size = new Size(34, 27);
            label1.TabIndex = 0;
            label1.Text = "00";
            // 
            // button1
            // 
            button1.Location = new Point(89, 163);
            button1.Name = "button1";
            button1.Size = new Size(89, 34);
            button1.TabIndex = 1;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(512, 163);
            button3.Name = "button3";
            button3.Size = new Size(121, 34);
            button3.TabIndex = 3;
            button3.Text = "Stop Music";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 64);
            label2.Name = "label2";
            label2.Size = new Size(203, 27);
            label2.TabIndex = 4;
            label2.Text = "Now you are in Step ";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button3);
            panel1.Location = new Point(57, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(865, 223);
            panel1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(271, 163);
            button2.Name = "button2";
            button2.Size = new Size(89, 34);
            button2.TabIndex = 5;
            button2.Text = "Next";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label6);
            panel2.Location = new Point(57, 261);
            panel2.Name = "panel2";
            panel2.Size = new Size(865, 532);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(13, 11);
            label6.MaximumSize = new Size(750, 350);
            label6.MinimumSize = new Size(750, 350);
            label6.Name = "label6";
            label6.Size = new Size(750, 350);
            label6.TabIndex = 8;
            label6.Text = "label6";
            // 
            // Coocking_Step
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 661);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Coocking_Step";
            Text = "Coocking_Step";
            Load += Coocking_Step_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button3;
        private Label label2;
        private Panel panel1;
        private Panel panel2;
        private Label label6;
        private Button button2;
    }
}