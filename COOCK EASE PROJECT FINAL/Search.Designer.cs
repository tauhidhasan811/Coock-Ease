namespace COOCK_EASE_PROJECT_FINAL
{
    partial class Search
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
            panel4 = new Panel();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            panel2 = new Panel();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            panel3 = new Panel();
            button1 = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(92, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(725, 327);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(button3);
            panel4.Location = new Point(3, 68);
            panel4.Name = "panel4";
            panel4.Size = new Size(547, 100);
            panel4.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(175, 56);
            label3.Name = "label3";
            label3.Size = new Size(81, 24);
            label3.TabIndex = 3;
            label3.Text = "recipeid";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(175, 14);
            label2.Name = "label2";
            label2.Size = new Size(139, 27);
            label2.TabIndex = 2;
            label2.Text = "Recipe Name";
            label2.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(147, 94);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Location = new Point(3, 3);
            button3.Name = "button3";
            button3.Size = new Size(541, 94);
            button3.TabIndex = 0;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label1);
            panel2.Font = new Font("Trebuchet MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(719, 59);
            panel2.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(481, 7);
            button2.Name = "button2";
            button2.Size = new Size(133, 45);
            button2.TabIndex = 2;
            button2.Text = "Enter";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(208, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(217, 32);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 13);
            label1.Name = "label1";
            label1.Size = new Size(143, 27);
            label1.TabIndex = 1;
            label1.Text = "You Searched";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Crimson;
            panel3.Controls.Add(button1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(899, 50);
            panel3.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.Crimson;
            button1.Dock = DockStyle.Left;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(153, 50);
            button1.TabIndex = 0;
            button1.Text = "COOK EASE";
            button1.UseVisualStyleBackColor = false;
            // 
            // Search
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 439);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "Search";
            Text = "Search";
            Load += Search_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Button button1;
        private Panel panel4;
        private PictureBox pictureBox1;
        private Button button3;
        private Button button2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
    }
}