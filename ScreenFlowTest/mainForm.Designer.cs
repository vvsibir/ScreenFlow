namespace ScreenFlowTest
{
    partial class mainForm
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
            this.pic = new System.Windows.Forms.PictureBox();
            this.pnl = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.screenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разВСекундуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разВСекундуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.разВСекундуToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.разВСекундуToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.разВСекундуToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.showMouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFormIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToNextDiaplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMainDisplayNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.pnl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(3, 55);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(269, 103);
            this.pic.TabIndex = 1;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.Black;
            this.pnl.Controls.Add(this.pic);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(0, 24);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(284, 238);
            this.pnl.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.screenToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // screenToolStripMenuItem
            // 
            this.screenToolStripMenuItem.Name = "screenToolStripMenuItem";
            this.screenToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.screenToolStripMenuItem.Text = "Screen";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.showMouseToolStripMenuItem,
            this.alwaysTopToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.autoShowToolStripMenuItem,
            this.showFormIconToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.разВСекундуToolStripMenuItem,
            this.разВСекундуToolStripMenuItem1,
            this.разВСекундуToolStripMenuItem2,
            this.разВСекундуToolStripMenuItem3,
            this.разВСекундуToolStripMenuItem4});
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // разВСекундуToolStripMenuItem
            // 
            this.разВСекундуToolStripMenuItem.Name = "разВСекундуToolStripMenuItem";
            this.разВСекундуToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.разВСекундуToolStripMenuItem.Tag = "1000";
            this.разВСекундуToolStripMenuItem.Text = "1 раз в секунду";
            this.разВСекундуToolStripMenuItem.Click += new System.EventHandler(this.разВСекундуToolStripMenuItem_Click);
            // 
            // разВСекундуToolStripMenuItem1
            // 
            this.разВСекундуToolStripMenuItem1.Name = "разВСекундуToolStripMenuItem1";
            this.разВСекундуToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.разВСекундуToolStripMenuItem1.Tag = "200";
            this.разВСекундуToolStripMenuItem1.Text = "5 раз в секунду";
            this.разВСекундуToolStripMenuItem1.Click += new System.EventHandler(this.разВСекундуToolStripMenuItem_Click);
            // 
            // разВСекундуToolStripMenuItem2
            // 
            this.разВСекундуToolStripMenuItem2.Name = "разВСекундуToolStripMenuItem2";
            this.разВСекундуToolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.разВСекундуToolStripMenuItem2.Tag = "100";
            this.разВСекундуToolStripMenuItem2.Text = "10 раз в секунду";
            this.разВСекундуToolStripMenuItem2.Click += new System.EventHandler(this.разВСекундуToolStripMenuItem_Click);
            // 
            // разВСекундуToolStripMenuItem3
            // 
            this.разВСекундуToolStripMenuItem3.Name = "разВСекундуToolStripMenuItem3";
            this.разВСекундуToolStripMenuItem3.Size = new System.Drawing.Size(162, 22);
            this.разВСекундуToolStripMenuItem3.Tag = "50";
            this.разВСекундуToolStripMenuItem3.Text = "20 раз в секунду";
            this.разВСекундуToolStripMenuItem3.Click += new System.EventHandler(this.разВСекундуToolStripMenuItem_Click);
            // 
            // разВСекундуToolStripMenuItem4
            // 
            this.разВСекундуToolStripMenuItem4.Name = "разВСекундуToolStripMenuItem4";
            this.разВСекундуToolStripMenuItem4.Size = new System.Drawing.Size(162, 22);
            this.разВСекундуToolStripMenuItem4.Tag = "33";
            this.разВСекундуToolStripMenuItem4.Text = "30 раз в секунду";
            this.разВСекундуToolStripMenuItem4.Click += new System.EventHandler(this.разВСекундуToolStripMenuItem_Click);
            // 
            // showMouseToolStripMenuItem
            // 
            this.showMouseToolStripMenuItem.Name = "showMouseToolStripMenuItem";
            this.showMouseToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.showMouseToolStripMenuItem.Text = "Show mouse";
            this.showMouseToolStripMenuItem.Click += new System.EventHandler(this.showMouseToolStripMenuItem_Click);
            // 
            // alwaysTopToolStripMenuItem
            // 
            this.alwaysTopToolStripMenuItem.Name = "alwaysTopToolStripMenuItem";
            this.alwaysTopToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.alwaysTopToolStripMenuItem.Text = "Always top";
            this.alwaysTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysTopToolStripMenuItem_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.resizeToolStripMenuItem.Text = "Resize";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
            // 
            // autoShowToolStripMenuItem
            // 
            this.autoShowToolStripMenuItem.Name = "autoShowToolStripMenuItem";
            this.autoShowToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.autoShowToolStripMenuItem.Text = "AutoShow";
            this.autoShowToolStripMenuItem.Click += new System.EventHandler(this.autoShowToolStripMenuItem_Click);
            // 
            // showFormIconToolStripMenuItem
            // 
            this.showFormIconToolStripMenuItem.Name = "showFormIconToolStripMenuItem";
            this.showFormIconToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.showFormIconToolStripMenuItem.Text = "Show form icon";
            this.showFormIconToolStripMenuItem.Click += new System.EventHandler(this.showFormIconToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // deleteSettingsToolStripMenuItem
            // 
            this.deleteSettingsToolStripMenuItem.Name = "deleteSettingsToolStripMenuItem";
            this.deleteSettingsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.deleteSettingsToolStripMenuItem.Text = "Delete settings...";
            this.deleteSettingsToolStripMenuItem.Click += new System.EventHandler(this.deleteSettingsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToNextDiaplayToolStripMenuItem,
            this.setMainDisplayNextToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // moveToNextDiaplayToolStripMenuItem
            // 
            this.moveToNextDiaplayToolStripMenuItem.Name = "moveToNextDiaplayToolStripMenuItem";
            this.moveToNextDiaplayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Right)));
            this.moveToNextDiaplayToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.moveToNextDiaplayToolStripMenuItem.Text = "Move to next display";
            this.moveToNextDiaplayToolStripMenuItem.Click += new System.EventHandler(this.moveToNextDisplayToolStripMenuItem_Click);
            // 
            // setMainDisplayNextToolStripMenuItem
            // 
            this.setMainDisplayNextToolStripMenuItem.Name = "setMainDisplayNextToolStripMenuItem";
            this.setMainDisplayNextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Right)));
            this.setMainDisplayNextToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.setMainDisplayNextToolStripMenuItem.Text = "Set Main display next";
            this.setMainDisplayNextToolStripMenuItem.Click += new System.EventHandler(this.setMainDisplayNextToolStripMenuItem_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.menuStrip1);
            this.Name = "mainForm";
            this.Text = "Flow";
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.pnl.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem screenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разВСекундуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разВСекундуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem разВСекундуToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem разВСекундуToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem разВСекундуToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem showMouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFormIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToNextDiaplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setMainDisplayNextToolStripMenuItem;
    }
}

