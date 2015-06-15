namespace DllTest
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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gIF动图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自由截图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capture_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.set_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.about_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exit_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "屏幕截图工具";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capture_menu,
            this.自由截图ToolStripMenuItem,
            this.gIF动图ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.set_menu,
            this.about_menu,
            this.toolStripMenuItem3,
            this.exit_menu});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 170);
            // 
            // gIF动图ToolStripMenuItem
            // 
            this.gIF动图ToolStripMenuItem.Name = "gIF动图ToolStripMenuItem";
            this.gIF动图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gIF动图ToolStripMenuItem.Text = "GIF动图";
            this.gIF动图ToolStripMenuItem.Click += new System.EventHandler(this.gIF动图ToolStripMenuItem_Click);
            // 
            // 自由截图ToolStripMenuItem
            // 
            this.自由截图ToolStripMenuItem.Name = "自由截图ToolStripMenuItem";
            this.自由截图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.自由截图ToolStripMenuItem.Text = "自由截图";
            this.自由截图ToolStripMenuItem.Click += new System.EventHandler(this.自由截图ToolStripMenuItem_Click);
            // 
            // capture_menu
            // 
            this.capture_menu.Name = "capture_menu";
            this.capture_menu.Size = new System.Drawing.Size(152, 22);
            this.capture_menu.Text = "矩形截屏";
            this.capture_menu.Click += new System.EventHandler(this.capture_menu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // set_menu
            // 
            this.set_menu.Name = "set_menu";
            this.set_menu.Size = new System.Drawing.Size(152, 22);
            this.set_menu.Text = "设置";
            this.set_menu.Click += new System.EventHandler(this.set_menu_Click);
            // 
            // about_menu
            // 
            this.about_menu.Name = "about_menu";
            this.about_menu.Size = new System.Drawing.Size(152, 22);
            this.about_menu.Text = "关于";
            this.about_menu.Click += new System.EventHandler(this.about_menu_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // exit_menu
            // 
            this.exit_menu.Name = "exit_menu";
            this.exit_menu.Size = new System.Drawing.Size(152, 22);
            this.exit_menu.Text = "退出";
            this.exit_menu.Click += new System.EventHandler(this.exit_menu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 247);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem set_menu;
        private System.Windows.Forms.ToolStripMenuItem capture_menu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exit_menu;
        private System.Windows.Forms.ToolStripMenuItem 自由截图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gIF动图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem about_menu;


    }
}

