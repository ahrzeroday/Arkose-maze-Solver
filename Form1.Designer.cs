namespace Arkose_maze_Solver
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.orgimg = new System.Windows.Forms.PictureBox();
            this.solveimg = new System.Windows.Forms.PictureBox();
            this.finalimg = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.orgimg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solveimg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalimg)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load Picture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // orgimg
            // 
            this.orgimg.Location = new System.Drawing.Point(12, 29);
            this.orgimg.Name = "orgimg";
            this.orgimg.Size = new System.Drawing.Size(300, 200);
            this.orgimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.orgimg.TabIndex = 1;
            this.orgimg.TabStop = false;
            // 
            // solveimg
            // 
            this.solveimg.Location = new System.Drawing.Point(318, 29);
            this.solveimg.Name = "solveimg";
            this.solveimg.Size = new System.Drawing.Size(300, 200);
            this.solveimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.solveimg.TabIndex = 2;
            this.solveimg.TabStop = false;
            // 
            // finalimg
            // 
            this.finalimg.Location = new System.Drawing.Point(624, 29);
            this.finalimg.Name = "finalimg";
            this.finalimg.Size = new System.Drawing.Size(300, 200);
            this.finalimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.finalimg.TabIndex = 3;
            this.finalimg.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(121, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Solve";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Orginal Image :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Solved Image :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(621, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Final Image :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Solve Time :";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(317, 244);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(10, 13);
            this.TimeLabel.TabIndex = 9;
            this.TimeLabel.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 276);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.finalimg);
            this.Controls.Add(this.solveimg);
            this.Controls.Add(this.orgimg);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Arkose maze Solver";
            ((System.ComponentModel.ISupportInitialize)(this.orgimg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solveimg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalimg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox orgimg;
        private System.Windows.Forms.PictureBox solveimg;
        private System.Windows.Forms.PictureBox finalimg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TimeLabel;
    }
}

