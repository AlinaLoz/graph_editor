namespace GraphEditor
{
    partial class Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.panelTools = new System.Windows.Forms.Panel();
            this.toolDelete = new System.Windows.Forms.PictureBox();
            this.pictureDrawing = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFrame = new System.Windows.Forms.PictureBox();
            this.panelTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDrawing)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTools
            // 
            this.panelTools.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTools.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTools.Controls.Add(this.toolFrame);
            this.panelTools.Controls.Add(this.toolDelete);
            this.panelTools.Location = new System.Drawing.Point(1, 27);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(83, 301);
            this.panelTools.TabIndex = 6;
            // 
            // toolDelete
            // 
            this.toolDelete.BackColor = System.Drawing.Color.Transparent;
            this.toolDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolDelete.BackgroundImage")));
            this.toolDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolDelete.Location = new System.Drawing.Point(9, 18);
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(30, 34);
            this.toolDelete.TabIndex = 19;
            this.toolDelete.TabStop = false;
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            this.toolDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolDelete_MouseUp);
            // 
            // pictureDrawing
            // 
            this.pictureDrawing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureDrawing.Location = new System.Drawing.Point(85, 27);
            this.pictureDrawing.Name = "pictureDrawing";
            this.pictureDrawing.Size = new System.Drawing.Size(527, 372);
            this.pictureDrawing.TabIndex = 7;
            this.pictureDrawing.TabStop = false;
            this.pictureDrawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureDrawing_MouseDown);
            this.pictureDrawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureDrawing_MouseMove);
            this.pictureDrawing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureDrawing_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(612, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creatToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // creatToolStripMenuItem
            // 
            this.creatToolStripMenuItem.Name = "creatToolStripMenuItem";
            this.creatToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.creatToolStripMenuItem.Text = "Create";
            this.creatToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            this.creatToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.creatToolStripMenuItem_MouseUp);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsКакToolStripMenuItem_Click);
            // 
            // toolFrame
            // 
            this.toolFrame.BackColor = System.Drawing.Color.Transparent;
            this.toolFrame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolFrame.BackgroundImage")));
            this.toolFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolFrame.Location = new System.Drawing.Point(9, 58);
            this.toolFrame.Name = "toolFrame";
            this.toolFrame.Size = new System.Drawing.Size(30, 34);
            this.toolFrame.TabIndex = 20;
            this.toolFrame.TabStop = false;
            this.toolFrame.Click += new System.EventHandler(this.toolFrame_Click);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(612, 402);
            this.Controls.Add(this.pictureDrawing);
            this.Controls.Add(this.panelTools);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(628, 441);
            this.MinimumSize = new System.Drawing.Size(628, 441);
            this.Name = "Paint";
            this.Text = "GraphicReader";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Paint_KeyDown);
            this.panelTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDrawing)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.PictureBox toolDelete;
        private System.Windows.Forms.PictureBox pictureDrawing;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.PictureBox toolFrame;
    }
}

