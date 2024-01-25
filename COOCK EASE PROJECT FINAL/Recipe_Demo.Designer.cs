namespace COOCK_EASE_PROJECT_FINAL
{
    partial class Recipe_Demo
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
            errorProvider1 = new ErrorProvider(components);
            panel6 = new Panel();
            button3 = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            button1 = new Button();
            label20 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Crimson;
            panel6.Controls.Add(button3);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1184, 50);
            panel6.TabIndex = 13;
            // 
            // button3
            // 
            button3.BackColor = Color.Crimson;
            button3.Dock = DockStyle.Left;
            button3.FlatAppearance.BorderColor = SystemColors.ButtonShadow;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonFace;
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Size = new Size(153, 50);
            button3.TabIndex = 0;
            button3.Text = "COOK EASE";
            button3.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(3, 112);
            panel1.Name = "panel1";
            panel1.Size = new Size(587, 339);
            panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.Location = new Point(71, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(449, 333);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(596, 115);
            panel2.Name = "panel2";
            panel2.Size = new Size(576, 336);
            panel2.TabIndex = 15;
            // 
            // button1
            // 
            button1.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(180, 175);
            button1.Name = "button1";
            button1.Size = new Size(212, 52);
            button1.TabIndex = 12;
            button1.Text = "Show More";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.SandyBrown;
            label20.Location = new Point(20, 67);
            label20.Name = "label20";
            label20.Size = new Size(72, 22);
            label20.TabIndex = 11;
            label20.Text = "recipeID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 101);
            label2.MaximumSize = new Size(553, 40);
            label2.MinimumSize = new Size(553, 40);
            label2.Name = "label2";
            label2.Size = new Size(553, 40);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(193, 37);
            label1.TabIndex = 0;
            label1.Text = "Recipe name";
            // 
            // Recipe_Demo
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(panel6);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Recipe_Demo";
            Text = "Recipe_Demo";
            Load += Recipe_Demo_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel6.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ErrorProvider errorProvider1;
        private Panel panel6;
        private Button button3;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label20;
        private Label label2;
        private Label label1;
        private Button button1;
    }
}