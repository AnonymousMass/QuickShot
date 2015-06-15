using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace DllTest
{
    public partial class MenuSet : Form
    {
        //public string defaultpath;
        /// <summary>
        /// 设置快捷键
        /// </summary>
        /// 
        public int HKMode1=Properties.Settings.Default.hotkeymode1;
        public int HKMode2 = Properties.Settings.Default.hotkeymode2;
        public int HKMode3 = Properties.Settings.Default.hotkeymode3;
        public int StartNum;
        public MenuSet()
        {
            InitializeComponent();
        }
        //设置菜单取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //实现开机启动
        public void RunWhenStart(bool Started, string name, string path)
        {
            try
            {
                RegistryKey HKLM = Registry.LocalMachine;
                RegistryKey Run = HKLM.CreateSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\");
                Run.SetValue(name, path);
                HKLM.Close();
                Properties.Settings.Default.autostart = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("开机启动设置失败，请以管理员身份运行!","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Properties.Settings.Default.autostart = false;
                throw e;
            }
            Properties.Settings.Default.Save();
        }

        //关闭开机启动
        private void closeWhenStart()
        {
            try
            {
                RegistryKey loca = Registry.LocalMachine;
                RegistryKey run = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                run.DeleteValue("Screenshoot");
                Properties.Settings.Default.autostart = false;
                loca.Close();
            }
            catch (Exception exce)
            {
                MessageBox.Show("设置失败，请以管理员身份运行!\n或者在电脑管理软件(如360)中允许开机自启","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw exce;
            }
            Properties.Settings.Default.Save();
        }


        //点击确认按钮，保存参数
        private void button1_Click(object sender, EventArgs e)
        {
            //快捷键HKMode判断
            if (comboBox2.Text == "Alt")
            {
                if (comboBox3.Text == "A")
                {
                    HKMode1 = 0;
                }
                else if (comboBox3.Text == "S")
                {
                    HKMode1 = 2;
                }
            }
            if (comboBox2.Text == "Shift")
            {
                if (comboBox3.Text == "A")
                {
                    HKMode1 = 1;
                }
                else if (comboBox3.Text == "S")
                {
                    HKMode1 = 3;
                }
            }
            if (comboBox4.Text == "Alt")
            {
                if (comboBox5.Text == "X")
                {
                    HKMode2 = 4;
                }
                else if (comboBox5.Text == "Z")
                {
                    HKMode2 = 6;
                }
            }
            if (comboBox4.Text == "Shift")
            {
                if (comboBox5.Text == "X")
                {
                    HKMode2 = 5;
                }
                else if (comboBox5.Text == "Z")
                {
                    HKMode2 = 7;
                }
            }
            if (comboBox6.Text == "Alt")
            {
                if (comboBox7.Text == "D")
                {
                    HKMode3 = 8;
                }
                else if (comboBox7.Text == "C")
                {
                    HKMode3 = 10;
                }
            }
            if (comboBox6.Text == "Shift")
            {
                if (comboBox7.Text == "D")
                {
                    HKMode3 = 9;
                }
                else if (comboBox7.Text == "C")
                {
                    HKMode3 = 11;
                }
            }

            if(checkBox2.Checked && textBox1.Text == "")
            {
                string path1 = Application.StartupPath;
                MessageBox.Show("您未选择自动保存路径\n图片将自动保存到"+path1+"\\CapturePic","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox1.Text = path1 + "\\CapturePic";
                Properties.Settings.Default.savepath = path1 + "\\CapturePic";
            }
            if (!checkBox2.Checked && textBox1.Text == "")
            {
                string path1 = Application.StartupPath;
                textBox1.Text = path1 + "\\CapturePic";
                Properties.Settings.Default.savepath = path1 + "\\CapturePic";
            }
            if (!Directory.Exists(textBox1.Text))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(textBox1.Text);
                directoryInfo.Create();
            }
            //开机启动
            if (checkBox1.Checked == true)
            {
                string path = Application.ExecutablePath;
                RunWhenStart(true, "Screenshoot", path);
                StartNum = 1;
                Properties.Settings.Default.StartNum = StartNum;
                Properties.Settings.Default.Save();
            }
            if(checkBox1.Checked==false)
            {
                if (StartNum == 1)
                {
                    closeWhenStart();
                    StartNum++;
                    Properties.Settings.Default.StartNum = StartNum;
                    Properties.Settings.Default.Save();
                }
            }
            Properties.Settings.Default.hotkeymode1 = HKMode1;
            Properties.Settings.Default.hotkeymode2 = HKMode2;
            Properties.Settings.Default.hotkeymode3 = HKMode3;
            Properties.Settings.Default.savepath = textBox1.Text;
            Properties.Settings.Default.autosave = checkBox2.Checked;
            Properties.Settings.Default.savaformat = comboBox1.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void MenuSet_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.hotkeymode1 = HKMode1;
            Properties.Settings.Default.hotkeymode2 = HKMode2;
            Properties.Settings.Default.hotkeymode3 = HKMode3;
            checkBox1.Checked = Properties.Settings.Default.autostart;
            checkBox2.Checked = Properties.Settings.Default.autosave;
            comboBox1.Text = Properties.Settings.Default.savaformat;
            textBox1.Text = Properties.Settings.Default.savepath;
            StartNum = Properties.Settings.Default.StartNum;
            //快捷键设置
            switch (HKMode1)
            {
                case 0: 
                    comboBox2.Text = "Alt";
                    comboBox3.Text = "A";
                    break;
                case 1:
                    comboBox2.Text = "Shift";
                    comboBox3.Text = "A";
                    break;
                case 2:
                    comboBox2.Text = "Alt";
                    comboBox3.Text = "S";
                    break;
                case 3:
                    comboBox2.Text = "Shift";
                    comboBox3.Text = "S";
                    break;
            }
            switch (HKMode2)
            {
                case 4:
                    comboBox4.Text = "Alt";
                    comboBox5.Text = "X";
                    break;
                case 5:
                    comboBox4.Text = "Shift";
                    comboBox5.Text = "X";
                    break;
                case 6:
                    comboBox4.Text = "Alt";
                    comboBox5.Text = "Z";
                    break;
                case 7:
                    comboBox4.Text = "Shift";
                    comboBox5.Text = "Z";
                    break;
            }
            switch (HKMode3)
            {
                case 8:
                    comboBox6.Text = "Alt";
                    comboBox7.Text = "D";
                    break;
                case 9:
                    comboBox6.Text = "Shift";
                    comboBox7.Text = "D";
                    break;
                case 10:
                    comboBox6.Text = "Alt";
                    comboBox7.Text = "C";
                    break;
                case 11:
                    comboBox6.Text = "Shift";
                    comboBox7.Text = "C";
                    break;
            }
            if (checkBox2.Checked == true)
            {
                textBox1.Enabled = true;
                comboBox1.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox1.Enabled = true;
                textBox1.Text = Properties.Settings.Default.savepath;
                comboBox1.Enabled = true;
                comboBox1.Text = Properties.Settings.Default.savaformat;
                button3.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowsingDialog = new FolderBrowserDialog())
            {
                folderBrowsingDialog.ShowNewFolderButton = true;
                if (folderBrowsingDialog.ShowDialog(this) == DialogResult.OK)
                {
                    textBox1.Text = folderBrowsingDialog.SelectedPath;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.savaformat = comboBox1.Text;
        }
    }
}
