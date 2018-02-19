namespace GraphEditor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.yellowColor = new System.Windows.Forms.PictureBox();
            this.redColor = new System.Windows.Forms.PictureBox();
            this.greenColor = new System.Windows.Forms.PictureBox();
            this.defaultColor = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yellowColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultColor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.yellowColor);
            this.panel1.Controls.Add(this.redColor);
            this.panel1.Controls.Add(this.greenColor);
            this.panel1.Controls.Add(this.defaultColor);
            this.panel1.Location = new System.Drawing.Point(12, 321);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 69);
            this.panel1.TabIndex = 0;
            // 
            // yellowColor
            // 
            this.yellowColor.BackColor = System.Drawing.Color.Yellow;
            this.yellowColor.Location = new System.Drawing.Point(233, 22);
            this.yellowColor.Name = "yellowColor";
            this.yellowColor.Size = new System.Drawing.Size(30, 23);
            this.yellowColor.TabIndex = 3;
            this.yellowColor.TabStop = false;
            this.yellowColor.Click += new System.EventHandler(this.yellowColor_Click);
            // 
            // redColor
            // 
            this.redColor.BackColor = System.Drawing.Color.Red;
            this.redColor.Location = new System.Drawing.Point(269, 22);
            this.redColor.Name = "redColor";
            this.redColor.Size = new System.Drawing.Size(30, 23);
            this.redColor.TabIndex = 2;
            this.redColor.TabStop = false;
            this.redColor.Click += new System.EventHandler(this.redColor_Click);
            // 
            // greenColor
            // 
            this.greenColor.BackColor = System.Drawing.Color.DarkGreen;
            this.greenColor.Location = new System.Drawing.Point(305, 22);
            this.greenColor.Name = "greenColor";
            this.greenColor.Size = new System.Drawing.Size(30, 23);
            this.greenColor.TabIndex = 1;
            this.greenColor.TabStop = false;
            this.greenColor.Click += new System.EventHandler(this.greenColor_Click);
            // 
            // defaultColor
            // 
            this.defaultColor.BackColor = System.Drawing.Color.Black;
            this.defaultColor.Location = new System.Drawing.Point(12, 13);
            this.defaultColor.Name = "defaultColor";
            this.defaultColor.Size = new System.Drawing.Size(34, 35);
            this.defaultColor.TabIndex = 0;
            this.defaultColor.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(405, 300);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(491, 300);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(405, 323);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 17);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(491, 323);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(80, 17);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(405, 348);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(80, 17);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(612, 402);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yellowColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox yellowColor;
        private System.Windows.Forms.PictureBox redColor;
        private System.Windows.Forms.PictureBox greenColor;
        private System.Windows.Forms.PictureBox defaultColor;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
    }
}

