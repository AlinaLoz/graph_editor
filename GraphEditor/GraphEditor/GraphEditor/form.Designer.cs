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
            this.toolFrame = new System.Windows.Forms.PictureBox();
            this.toolDelete = new System.Windows.Forms.PictureBox();
            this.toolTreangle = new System.Windows.Forms.PictureBox();
            this.toolElipse = new System.Windows.Forms.PictureBox();
            this.toolRectangle = new System.Windows.Forms.PictureBox();
            this.toolLine = new System.Windows.Forms.PictureBox();
            this.toolCircle = new System.Windows.Forms.PictureBox();
            this.pictureDrawing = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTreangle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolElipse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolRectangle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolCircle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDrawing)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTools
            // 
            this.panelTools.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTools.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTools.Controls.Add(this.toolFrame);
            this.panelTools.Controls.Add(this.toolDelete);
            this.panelTools.Controls.Add(this.toolTreangle);
            this.panelTools.Controls.Add(this.toolElipse);
            this.panelTools.Controls.Add(this.toolRectangle);
            this.panelTools.Controls.Add(this.toolLine);
            this.panelTools.Controls.Add(this.toolCircle);
            this.panelTools.Location = new System.Drawing.Point(1, 27);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(83, 301);
            this.panelTools.TabIndex = 6;
            // 
            // toolFrame
            // 
            this.toolFrame.BackColor = System.Drawing.Color.Transparent;
            this.toolFrame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolFrame.BackgroundImage")));
            this.toolFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolFrame.Location = new System.Drawing.Point(6, 170);
            this.toolFrame.Name = "toolFrame";
            this.toolFrame.Size = new System.Drawing.Size(30, 34);
            this.toolFrame.TabIndex = 20;
            this.toolFrame.TabStop = false;
            this.toolFrame.Click += new System.EventHandler(this.toolFrame_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.BackColor = System.Drawing.Color.Transparent;
            this.toolDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolDelete.BackgroundImage")));
            this.toolDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolDelete.Location = new System.Drawing.Point(42, 130);
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(30, 34);
            this.toolDelete.TabIndex = 19;
            this.toolDelete.TabStop = false;
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            this.toolDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolDelete_MouseUp);
            // 
            // toolTreangle
            // 
            this.toolTreangle.BackColor = System.Drawing.Color.Transparent;
            this.toolTreangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolTreangle.BackgroundImage")));
            this.toolTreangle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolTreangle.Location = new System.Drawing.Point(42, 90);
            this.toolTreangle.Name = "toolTreangle";
            this.toolTreangle.Size = new System.Drawing.Size(30, 34);
            this.toolTreangle.TabIndex = 17;
            this.toolTreangle.TabStop = false;
            this.toolTreangle.Click += new System.EventHandler(this.toolTreangle_Click);
            // 
            // toolElipse
            // 
            this.toolElipse.BackColor = System.Drawing.Color.Transparent;
            this.toolElipse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolElipse.BackgroundImage")));
            this.toolElipse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolElipse.Location = new System.Drawing.Point(6, 90);
            this.toolElipse.Name = "toolElipse";
            this.toolElipse.Size = new System.Drawing.Size(30, 34);
            this.toolElipse.TabIndex = 16;
            this.toolElipse.TabStop = false;
            this.toolElipse.Click += new System.EventHandler(this.toolElipse_Click);
            // 
            // toolRectangle
            // 
            this.toolRectangle.BackColor = System.Drawing.Color.Transparent;
            this.toolRectangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolRectangle.BackgroundImage")));
            this.toolRectangle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolRectangle.Location = new System.Drawing.Point(42, 50);
            this.toolRectangle.Name = "toolRectangle";
            this.toolRectangle.Size = new System.Drawing.Size(30, 34);
            this.toolRectangle.TabIndex = 15;
            this.toolRectangle.TabStop = false;
            this.toolRectangle.Click += new System.EventHandler(this.toolRectangle_Click);
            // 
            // toolLine
            // 
            this.toolLine.BackColor = System.Drawing.Color.Transparent;
            this.toolLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolLine.BackgroundImage")));
            this.toolLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolLine.Location = new System.Drawing.Point(6, 130);
            this.toolLine.Name = "toolLine";
            this.toolLine.Size = new System.Drawing.Size(30, 34);
            this.toolLine.TabIndex = 14;
            this.toolLine.TabStop = false;
            this.toolLine.Click += new System.EventHandler(this.toolLine_Click);
            // 
            // toolCircle
            // 
            this.toolCircle.BackColor = System.Drawing.Color.Transparent;
            this.toolCircle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolCircle.BackgroundImage")));
            this.toolCircle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolCircle.Location = new System.Drawing.Point(6, 50);
            this.toolCircle.Name = "toolCircle";
            this.toolCircle.Size = new System.Drawing.Size(30, 34);
            this.toolCircle.TabIndex = 12;
            this.toolCircle.TabStop = false;
            this.toolCircle.Click += new System.EventHandler(this.toolCircle_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.toolFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTreangle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolElipse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolRectangle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolCircle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDrawing)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.PictureBox toolTreangle;
        private System.Windows.Forms.PictureBox toolElipse;
        private System.Windows.Forms.PictureBox toolRectangle;
        private System.Windows.Forms.PictureBox toolLine;
        private System.Windows.Forms.PictureBox toolCircle;
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

