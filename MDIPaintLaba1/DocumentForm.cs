using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaintLaba1
{
    interface IWidthHeight
    {
        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }
    }
    public partial class DocumentForm : Form, IWidthHeight
    {
        private int x, y;
        private Bitmap bitmap;
        public Bitmap Bitmap { get { return bitmap; } }
        private int _CanvasWidth;
        private int _CanvasHeight;
        private Form1 mainForm;
        public string FileSave { get; set; }
        public ImageFormat ImageFormat { get; set; }
        private bool edited = false; 
        public bool Edited { get { return edited; } }
        private (int x, int y) LineStartPosition = (0, 0);
        private bool LineStart = true;
        private (int x, int y) EllipseStartPosition = (0, 0);
        private bool EllipseStart = true;
        private Bitmap StartPositionBitmap;
        private double bitmapScale = 1;
        public double BitmapScale 
        { 
            get { return bitmapScale; } 
            set 
            { 
                if (value > 0)
                    bitmapScale = value;
                Invalidate();
            } 
        }
        public int CanvasWidth
        {
            get { return _CanvasWidth; }
            set
            {
                _CanvasWidth = value;
                UpdateBitmap();
            }
        }
        public int CanvasHeight 
        { 
            get { return _CanvasHeight; }
            set 
            { 
                _CanvasHeight = value;
                UpdateBitmap();
            } 
        }
        private int scale(int x) { return (int)(x / bitmapScale); }
        private void DocumentForm_MouseDown(object sender, MouseEventArgs e)
        {
            bitmap = (Bitmap)StartPositionBitmap.Clone();
            if (mainForm.PenType != PenTypes.Line)
            {
                LineStart = true;
            }
            if (mainForm.PenType != PenTypes.Ellipse)
            {
                EllipseStart = true;
            }
            switch (mainForm.PenType)
            {
                case PenTypes.Pen:
                    x = scale(e.X);
                    y = scale(e.Y);
                    break;
                case PenTypes.Line:
                    if (LineStart)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            LineStartPosition = (scale(e.X), scale(e.Y));
                            StartPositionBitmap = (Bitmap)bitmap.Clone();
                            LineStart = false;
                        }
                    }
                    else
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            bitmap = (Bitmap)StartPositionBitmap.Clone();
                            Graphics g = Graphics.FromImage(bitmap);
                            g.DrawLine(new Pen(mainForm.PenColor, mainForm.PenWidth), LineStartPosition.x, LineStartPosition.y, scale(e.X), scale(e.Y));
                            Invalidate();
                            StartPositionBitmap = (Bitmap)bitmap.Clone();
                            LineStartPosition = (scale(e.X), scale(e.Y));
                            edited = true;
                            LineStart = true;
                        }
                    }
                    break;
                case PenTypes.Ellipse:
                    if (EllipseStart)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            EllipseStartPosition = (scale(e.X), scale(e.Y));
                            StartPositionBitmap = (Bitmap)bitmap.Clone();
                            EllipseStart = false;
                        }
                    }
                    else
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            bitmap = (Bitmap)StartPositionBitmap.Clone();
                            Graphics g = Graphics.FromImage(bitmap);
                            // EllipseStartPosition.x, EllipseStartPosition.y, scale(e.X), scale(e.Y)
                            g.DrawEllipse(new Pen(mainForm.PenColor, mainForm.PenWidth), EllipseStartPosition.x, EllipseStartPosition.y, 
                                scale(e.X) - EllipseStartPosition.x, scale(e.Y) - EllipseStartPosition.y);
                            Invalidate();
                            StartPositionBitmap = (Bitmap)bitmap.Clone();
                            EllipseStartPosition = (scale(e.X), scale(e.Y));
                            edited = true;
                            EllipseStart = true;
                        }
                    }
                    break;
                case PenTypes.Eraser:
                    x = scale(e.X);
                    y = scale(e.Y);
                    break;
                case PenTypes.Star:
                    if (e.Button == MouseButtons.Left)
                    {
                        bitmap = (Bitmap)StartPositionBitmap.Clone();
                        Graphics g = Graphics.FromImage(bitmap);
                        DrawStar(
                            mainForm.StarSettingsForm.NumberOfRays,
                            mainForm.StarSettingsForm.InnerRadius,
                            mainForm.StarSettingsForm.OutherRadius,
                            mainForm.StarSettingsForm.Angle,
                            scale(e.X), scale(e.Y),
                            g);
                        Invalidate();
                        StartPositionBitmap = (Bitmap)bitmap.Clone();
                        edited = true;
                    }
                    break;
            }
        }

        private void DocumentForm_MouseMove(object sender, MouseEventArgs e)
        {
            bitmap = (Bitmap)StartPositionBitmap.Clone();
            if (mainForm.PenType != PenTypes.Line)
            {
                LineStart = true;
            }
            if (mainForm.PenType != PenTypes.Ellipse)
            {
                EllipseStart = true;
            }
            switch (mainForm.PenType)
            {
                case PenTypes.Pen:
                    if (e.Button == MouseButtons.Left)
                    {
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawLine(new Pen(mainForm.PenColor, mainForm.PenWidth), x, y, scale(e.X), scale(e.Y));
                        Invalidate();
                        StartPositionBitmap = (Bitmap)bitmap.Clone();
                        x = scale(e.X);
                        y = scale(e.Y);
                        edited = true;
                    }
                    break;
                case PenTypes.Line:
                    if (!LineStart)
                    {
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawLine(new Pen(mainForm.PenColor, mainForm.PenWidth), LineStartPosition.x, LineStartPosition.y, scale(e.X), scale(e.Y));
                        Invalidate();
                    }
                    break;
                case PenTypes.Ellipse:
                    if (!EllipseStart)
                    {
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawEllipse(new Pen(mainForm.PenColor, mainForm.PenWidth), EllipseStartPosition.x, EllipseStartPosition.y, 
                            scale(e.X) - EllipseStartPosition.x, scale(e.Y) - EllipseStartPosition.y);
                        Invalidate();
                    }
                    break;
                case PenTypes.Eraser:
                    if (e.Button == MouseButtons.Left)
                    {
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawLine(new Pen(Color.FromArgb(0xab, 0xab, 0xab), mainForm.PenWidth), x, y, scale(e.X), scale(e.Y));
                        bitmap.MakeTransparent(Color.FromArgb(0xab, 0xab, 0xab));
                        Invalidate();
                        StartPositionBitmap = (Bitmap)bitmap.Clone();
                        x = scale(e.X);
                        y = scale(e.Y) ;
                        edited = true;
                    }
                    break;
                case PenTypes.Star:
                    {
                        Graphics g = Graphics.FromImage(bitmap);
                        DrawStar(
                            mainForm.StarSettingsForm.NumberOfRays,
                            mainForm.StarSettingsForm.InnerRadius,
                            mainForm.StarSettingsForm.OutherRadius,
                            mainForm.StarSettingsForm.Angle,
                            scale(e.X), scale(e.Y),
                            g);
                        Invalidate();
                    }
                    break;
            }
        }
        private void DocumentForm_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (bitmapScale != 1)
                e.Graphics.DrawImage(new Bitmap(bitmap, new Size((int)(CanvasWidth * bitmapScale), (int)(CanvasHeight * bitmapScale))), 0, 0);
            else
                e.Graphics.DrawImage(bitmap, 0, 0);
        }

        public DocumentForm(int width, int height, Form1 mainForm)
        {
            InitializeComponent();
            bitmap = new Bitmap(width, height);
            bitmap.MakeTransparent(Color.FromArgb(0xab, 0xab, 0xab));
            StartPositionBitmap = (Bitmap)bitmap.Clone();
            _CanvasWidth = width;
            _CanvasHeight = height;
            this.mainForm = mainForm;
            FileSave = "";
            ImageFormat = ImageFormat.Jpeg;
        }
        public DocumentForm(Image image, ImageFormat imageFormat, string fileSave, Form1 mainForm)
        {
            InitializeComponent();
            bitmap = new Bitmap(image);
            bitmap.MakeTransparent(Color.FromArgb(0xab, 0xab, 0xab));
            StartPositionBitmap = (Bitmap)bitmap.Clone();
            _CanvasWidth = image.Width;
            _CanvasHeight = image.Height;
            this.mainForm = mainForm;
            FileSave = fileSave;
            ImageFormat = imageFormat;
        }

        private void DocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (edited)
            {
                switch (MessageBox.Show("В файле есть несохраненые изменения. Сохранить?", "Внимание!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        if (!Save())
                        {
                            e.Cancel = true; 
                        }
                        break;
                }
            }
        }

        public void UpdateBitmap()
        {
            Bitmap oldBitmap = (Bitmap)StartPositionBitmap.Clone();
            bitmap = new Bitmap(CanvasWidth, CanvasHeight);
            Graphics grph = Graphics.FromImage(bitmap);
            grph.DrawImage(oldBitmap, 0, 0);
            StartPositionBitmap = (Bitmap)bitmap.Clone();
            Invalidate();
        }

        private bool save(string fileName, ImageFormat imageFormat)
        {
            try
            { 
                StartPositionBitmap.Save(fileName, imageFormat);
                edited = false;
                return true;
            }
            catch
            {
                MessageBox.Show("Процесс сохранения закончился ошибкой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool Save()
        {
            if (FileSave != "")
            {
                save(FileSave, ImageFormat);
                return true;
            }
            else
                return SaveAs();
        }

        public bool SaveAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp|Файлы JPEG (*.jpeg, *.jpg)|*.jpeg;*.jpg|Файлы PNG (*.png)|*.png";
            ImageFormat[] ff = { ImageFormat.Bmp, ImageFormat.Jpeg, ImageFormat.Png };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (save(dlg.FileName, ff[dlg.FilterIndex - 1]))
                {
                    FileSave = dlg.FileName;
                    ImageFormat = ff[dlg.FilterIndex - 1];
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public void DrawStar(decimal NumberOfRays, decimal InnerRadius, decimal OutherRadius, decimal Angle, int x, int y, Graphics graphics)
        {
            int n = (int)NumberOfRays;
            double R = (double)OutherRadius;
            double r = (double)InnerRadius;
            double alpha = (double)Angle / 180 * Math.PI;
            double x0 = x, y0 = y;

            PointF[] points = new PointF[2 * n + 1];
            double a = alpha, da = Math.PI / n, l;
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));
                a += da;
            }

            graphics.DrawLines(new Pen(mainForm.PenColor, mainForm.PenWidth), points);
        }
    }
}
