using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DllTest
{
    public partial class tbxText : TextBox
    {
        public tbxText() {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e) {
            Bitmap bmp = new Bitmap(20, 50);
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.DrawString("test just", this.Font, Brushes.Red, 0, 0);
            }
            e.Graphics.DrawImage(bmp, 0, 0);
            e.Graphics.DrawString("fsffd", this.Font, Brushes.Cyan, 0, 0);
            bmp.Dispose();
            MessageBox.Show("fsdfsdfsdfsd");
            base.OnPaint(e);
        }

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x133) {
                Console.WriteLine("wm_paint");
                using (Graphics g = Graphics.FromHwnd(this.Handle)) {
                    Pen p = new Pen(Color.Cyan, 1);
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                    g.DrawRectangle(p, 0, 0, this.Width,this.Height);
                }
            }
        }
    }
}
