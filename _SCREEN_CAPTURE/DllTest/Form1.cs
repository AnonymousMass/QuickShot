using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using _SCREEN_CAPTURE;
using GIFBuilder;
using CaptureItPlus;

namespace DllTest
{
    public partial class Form1 : Form
    {
        //freeform
        string fileName;
        Common.CaptureModes captureMode = Common.CaptureModes.FreeForm;
        //自动保存
        public string path;
        public bool savechecked;
        public string saveformat;

        #region 热键及背景
        /// <summary>
        /// 向全局原子表添加一个字符串，并返回这个字符串的唯一标识符（原子ATOM）。
        /// </summary>
        /// <param name="lpString">自己设定的一个字符串</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        public static extern Int32 GlobalAddAtom(string lpString);

        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

        /// <summary>
        /// 取消热键注册
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// 热键ID
        /// </summary>
        public int hotKeyId1 = 100;
        public int hotKeyId2 = 200;
        public int hotKeyId3 = 300;

        /// <summary>
        /// 热键模式:
        /// 矩形截图
        /// 0=Ctrl + Alt + A, 1=Ctrl + Shift + A
        /// 2=Ctrl + Alt + S, 3=Ctrl + Shift + S
        /// 随意截图
        /// 4=Ctrl + Alt + X, 5=Ctrl + Shift + X
        /// 6=Ctrl + Alt + Z, 7=Ctrl + Shift + Z
        /// gif截图
        /// 8=Ctrl + Alt + D, 9=Ctrl + Shift + D
        /// 10=Ctrl + Alt + C, 11=Ctrl + Shift + C
        /// </summary>
        public int HotKeyMode1 = 1;
        public int HotKeyMode2 = 5;
        public int HotKeyMode3 = 9;
     

        /// <summary>
        /// 控制键的类型
        /// </summary>
        public enum KeyModifiers : uint
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        /// <summary>
        /// 用于保存截取的整个屏幕的图片
        /// </summary>
        protected Bitmap screenImage;
        #endregion

        public Form1() {
            InitializeComponent();
            this.FormClosed += (s, e) => this.Dispose();
        }
        ~Form1() {
        }

        private void Form1_Load(object sender, EventArgs e) {

            //隐藏窗口
            this.Hide();
            //注册快捷键
            HotKeyMode1 = Properties.Settings.Default.hotkeymode1;
            HotKeyMode2 = Properties.Settings.Default.hotkeymode2;
            HotKeyMode3 = Properties.Settings.Default.hotkeymode3;
            switch (this.HotKeyMode1)
            {
             //初始快捷键注册
                case 0: RegisterHotKey(Handle, hotKeyId1, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.A);break;
                case 1: RegisterHotKey(Handle, hotKeyId1, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.A);break;
                case 2: RegisterHotKey(Handle, hotKeyId1, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.S);break;
                case 3: RegisterHotKey(Handle, hotKeyId1, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.S);break;
            }
            switch(this.HotKeyMode2)
            {
                case 4: RegisterHotKey(Handle, hotKeyId2, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.X);break;
                case 5: RegisterHotKey(Handle, hotKeyId2, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.X);break;
                case 6: RegisterHotKey(Handle, hotKeyId2, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.Z);break;
                case 7: RegisterHotKey(Handle, hotKeyId2, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.Z);break;
            }
            switch (this.HotKeyMode3)
            {
                case 8: RegisterHotKey(Handle, hotKeyId3, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.D); break;
                case 9: RegisterHotKey(Handle, hotKeyId3, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.D); break;
                case 10: RegisterHotKey(Handle, hotKeyId3, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.C); break;
                case 11: RegisterHotKey(Handle, hotKeyId3, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.C); break;
            }
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.ShowBalloonTip(5000, "提示", "截屏工具已运行！\n若要截图，请使用快捷键或右击图标。\n感谢您的使用^_^ ~~", ToolTipIcon.Info);

            //自动保存
            path = Properties.Settings.Default.savepath;
            savechecked = Properties.Settings.Default.autosave;
            saveformat = Properties.Settings.Default.savaformat;
        }

        /// <summary>
        /// 处理快捷键事件
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    ProcessHotkey(m);  
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 当窗口正在关闭时进行验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                e.Cancel = false;
                //取消快捷键的注册
                UnregisterHotKey(this.Handle, hotKeyId1);
                UnregisterHotKey(this.Handle, hotKeyId2);
                UnregisterHotKey(this.Handle, hotKeyId3);
            }
            else
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void exit_menu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void capture_menu_Click(object sender, EventArgs e)
        {
            FrmCapture frmC = new FrmCapture();
            frmC.path = path;
            frmC.savechecked = savechecked;
            frmC.saveformat = saveformat;
            frmC.ShowDialog();
        }

        private void set_menu_Click(object sender, EventArgs e)
        {
            MenuSet set = new MenuSet();
            set.ShowDialog();
            path = Properties.Settings.Default.savepath;
            savechecked = Properties.Settings.Default.autosave;
            saveformat = Properties.Settings.Default.savaformat;
            
            UnregisterHotKey(this.Handle, hotKeyId1);
            UnregisterHotKey(this.Handle, hotKeyId2);
            UnregisterHotKey(this.Handle, hotKeyId3);
            //注册快捷键
            HotKeyMode1 = set.HKMode1;
            HotKeyMode2 = set.HKMode2;
            HotKeyMode3 = set.HKMode3;
            switch (this.HotKeyMode1)
            {
                //初始快捷键注册
                case 0: RegisterHotKey(Handle, hotKeyId1, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.A); break;
                case 1: RegisterHotKey(Handle, hotKeyId1, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.A); break;
                case 2: RegisterHotKey(Handle, hotKeyId1, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.S); break;
                case 3: RegisterHotKey(Handle, hotKeyId1, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.S); break;
            }
            switch (this.HotKeyMode2)
            {
                case 4: RegisterHotKey(Handle, hotKeyId2, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.X); break;
                case 5: RegisterHotKey(Handle, hotKeyId2, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.X); break;
                case 6: RegisterHotKey(Handle, hotKeyId2, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.Z); break;
                case 7: RegisterHotKey(Handle, hotKeyId2, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.Z); break;
            }
            switch (this.HotKeyMode3)
            {
                case 8: RegisterHotKey(Handle, hotKeyId3, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.D); break;
                case 9: RegisterHotKey(Handle, hotKeyId3, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.D); break;
                case 10: RegisterHotKey(Handle, hotKeyId3, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.C); break;
                case 11: RegisterHotKey(Handle, hotKeyId3, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.C); break;
            }
        }

        private void about_menu_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void gIF动图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GIFBuilderUI gif = new GIFBuilderUI();
            gif.ShowDialog();
        }

        private void 自由截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureItPlus.Capturemodes.frmOverlay free = new CaptureItPlus.Capturemodes.frmOverlay(fileName, captureMode);
            free.path=path;
            free.savechecked = savechecked;
            free.saveformat = saveformat;
            free.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //左键双击
            if (e.Button == MouseButtons.Left)
            {
                FrmCapture frmC = new FrmCapture();
                frmC.path = path;
                frmC.savechecked = savechecked;
                frmC.saveformat = saveformat;
                frmC.ShowDialog();
            }
        }

        //设置快捷键
        private void ProcessHotkey(Message m)
        {
            IntPtr id = m.WParam; //IntPtr用于表示指针或句柄的平台特定类型                     
            int sid = id.ToInt32();
            switch (sid)
            {
                case 100: 
                    FrmCapture frmC = new FrmCapture();
                    frmC.path = path;
                    frmC.savechecked = savechecked;
                    frmC.saveformat = saveformat;
                    frmC.ShowDialog();
                    break; 
                case 200:
                    CaptureItPlus.Capturemodes.frmOverlay free = new CaptureItPlus.Capturemodes.frmOverlay(fileName, captureMode);
                    free.path=path;
                    free.savechecked = savechecked;
                    free.saveformat = saveformat;
                    free.Show();
                    break;
                case 300:
                    GIFBuilderUI gif = new GIFBuilderUI();
                    gif.ShowDialog();
                    break;
            }        
        }
    }
}
