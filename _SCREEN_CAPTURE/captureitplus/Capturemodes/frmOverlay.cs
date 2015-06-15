using _SCREEN_CAPTURE;
namespace CaptureItPlus.Capturemodes
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Threading;
    using System;
    using System.Runtime.InteropServices;

    public partial class frmOverlay : Form
    {
        //自动保存的设置参数
        public string path;
        public bool savechecked;
        public string saveformat;
        //鼠标指针
        System.Windows.Forms.Cursor curWrite = null;

        private bool _isDrawing = false;
        private Point _endPoint = default(Point);
        private Point _starting = default(Point);
        private Common.CaptureModes _captureMode = Common.CaptureModes.Rectangle;
        private Pen _pen;
        private GraphicsPath _freeformPath;
        private int _x;
        private int _y;
        private bool _gridLines = false;

        public frmOverlay(string fileName, Common.CaptureModes captureMode)
        {
            InitializeComponent();
            Common.IsCaptureIsActive = true;
            CreateOverlayAllScreens();
            //减少画面的闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            FileName = fileName;
            _captureMode = captureMode;
            _pen = new Pen(Color.Cyan, 3);
            _pen.DashStyle = DashStyle.Dash;
            //curWrite = FrmCapture.getCursorFromResource(Properties.Resources.Handwriting);
            this.Cursor = curWrite;
            switch (captureMode)
            {
               
                case Common.CaptureModes.FreeForm:
                    _gridLines = true;
                    _freeformPath = new GraphicsPath();
                    break;
            
                default:
                    break;
            }
        }

        public string FileName
        {
            get;
            private set;
        }
        
        private void CaptureImage()
        {
            Opacity = 0;
            switch (_captureMode)
            {
                case Common.CaptureModes.FreeForm:
                    var freeformRegion = Rectangle.Round(_freeformPath.GetBounds());
                    using (var bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb))
                    {
                        using (var graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.CopyFromScreen(Left, Top, 0, 0, Size);
                            graphics.DrawImage(bitmap, new Point(0, 0));

                            using (Bitmap transparent = new Bitmap(bitmap))
                            {
                                using (Graphics transparentGp = Graphics.FromImage(transparent))
                                {
                                    using (Graphics originalGp = Graphics.FromImage(bitmap))
                                    {
                                        transparentGp.FillRectangle(Brushes.Pink, new Rectangle(0, 0, transparent.Width, transparent.Height));
                                        transparentGp.FillPath(Brushes.LimeGreen, _freeformPath);
                                        transparent.MakeTransparent(Color.LimeGreen);
                                        originalGp.DrawImage(transparent, new Rectangle(0, 0, transparent.Width, transparent.Height));
                                      
                                        using (Bitmap tempBitmap = new Bitmap(bitmap))
                                        {
                                            //保存所需要的地方
                                            tempBitmap.MakeTransparent(Color.Pink);
                                            DateTime time = DateTime.Now;
                                            FileName = "CAPTURE_" + time.Date.ToShortDateString().Replace("/", "") + "_" + time.ToLongTimeString().Replace(":", "");
                                            if (!savechecked)
                                            {
                                                SaveFileDialog saveDlg = new SaveFileDialog();
                                                saveDlg.Title = "图片保存";
                                                saveDlg.Filter = "BMP(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|PNG(*.png)|*.png";
                                                saveDlg.FilterIndex = 1;
                                                saveDlg.FileName = FileName;
                                                if (saveDlg.ShowDialog() == DialogResult.OK)
                                                {
                                                    switch (saveDlg.FilterIndex)
                                                    {
                                                        case 1:
                                                            Copy(tempBitmap, freeformRegion).Save(saveDlg.FileName);
                                                            this.Close();
                                                            break;
                                                        case 2:
                                                            Copy(tempBitmap, freeformRegion).Save(saveDlg.FileName);
                                                            this.Close();
                                                            break;
                                                        case 3:
                                                            Copy(tempBitmap, freeformRegion).Save(saveDlg.FileName);
                                                            this.Close();
                                                            break;
                                                        default:
                                                            Copy(tempBitmap, freeformRegion).Save(saveDlg.FileName);
                                                            this.Close();
                                                            break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                string autopath = @path;
                                                if (autopath.Substring(autopath.Length - 1, 1) != @"/")
                                                    autopath = autopath + @"/";
                                                try
                                                {
                                                    switch (saveformat)
                                                    {
                                                        case ".png":
                                                            Copy(tempBitmap, freeformRegion).Save(autopath + "//" + FileName + ".png");
                                                            this.Close();
                                                            break;
                                                        case ".bmp":
                                                            Copy(tempBitmap, freeformRegion).Save(autopath + "//" + FileName + ".bmp");
                                                            this.Close();
                                                            break;
                                                        case ".jpg":
                                                            Copy(tempBitmap, freeformRegion).Save(autopath + "//" + FileName + ".jpg");
                                                            this.Close();
                                                            break;
                                                        default:
                                                            Copy(tempBitmap, freeformRegion).Save(autopath + "//" + FileName + ".png");
                                                            this.Close();
                                                            break;
                                                    }
                                                }
                                                catch (Exception exp) { MessageBox.Show("自动保存失败，请正确设置路径！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning); throw exp; }
                                            }
                                           
                                            
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
              
                default:
                    break;
            }

            DialogResult = DialogResult.OK;
            Common.IsCaptureIsActive = false;
            Close();
        }

        public Bitmap Copy(Bitmap srcBitmap, Rectangle section)
        {
            if (section.Width <= 0 || section.Height <= 0)
            {
                section.Width = 5;
                section.Height = 5;
            }

            Bitmap bmp = new Bitmap(section.Width, section.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        private void DrawShape(Graphics graphics)
        {
           
               graphics.DrawPath(_pen, _freeformPath);
           
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            Rectangle rectangle = new Rectangle();
            if (p1.X < p2.X)
            {
                rectangle.X = p1.X;
                rectangle.Width = p2.X - p1.X;
            }
            else
            {
                rectangle.X = p2.X;
                rectangle.Width = p1.X - p2.X;
            }
            if (p1.Y < p2.Y)
            {
                rectangle.Y = p1.Y;
                rectangle.Height = p2.Y - p1.Y;
            }
            else
            {
                rectangle.Y = p2.Y;
                rectangle.Height = p1.Y - p2.Y;
            }
            return rectangle;
        }

        private void DrawLine(Point point1, Point point2)
        {
            Graphics graphics = this.CreateGraphics();
            graphics.DrawLine(_pen, point1, point2);
        }

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDrawing = true;
                _starting = e.Location;
                switch (_captureMode)
                {
                    case Common.CaptureModes.FreeForm:
                        _freeformPath.StartFigure();
                        break;
                }
            }
            else
            {
                 this.Hide();
            }
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            _x = e.X;
            _y = e.Y;
            if (_isDrawing)
            {
                switch (_captureMode)
                {
                    case Common.CaptureModes.FreeForm:
                        _freeformPath.AddLine(e.X, e.Y, e.X, e.Y);
                        break;
                }
                _endPoint = e.Location;
            }
            Invalidate();
        }

        private void onPaint(object sender, PaintEventArgs e)
        {
            //   十字交叉线
            DrawShape(e.Graphics);
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            if (_isDrawing)
            {
                _isDrawing = false;
                CaptureImage();
            }
        }

        private void frmOverlay_Load(object sender, System.EventArgs e)
        {
            this.KeyPreview = true;
            //curWrite = FrmCapture.getCursorFromResource(Properties.Resources.Handwriting);
        }

        private void CreateOverlayAllScreens()
        {
            int h = 0;
            int w = 0;
            int x = 0;
            int y = 0;

            foreach (Screen s in Screen.AllScreens)
            {
                if (s.Bounds.X < x)
                    x = s.Bounds.X;
                if (s.Bounds.Y < y)
                    y = s.Bounds.Y;
                h += s.Bounds.Height;
                w += s.Bounds.Width;
            }

            this.Height = h;
            this.Width = w;
            this.Left = x;
            this.Top = y;
        }

        private void frmOverlay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
