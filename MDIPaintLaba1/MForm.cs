using System.Drawing.Imaging;

namespace MDIPaintLaba1
{
    public enum PenTypes
    {
        Pen,
        Line, 
        Ellipse, 
        Eraser,
        Star
    }
    public partial class Form1 : Form
    {
        public Color PenColor { get; set; }
        public PenTypes PenType { get; set; }
        private int _PenWidth;
        public int PenWidth 
        {
            get { return _PenWidth; } 
            set 
            { 
                if (value >= 1 & value <= 50) 
                    _PenWidth = value;
                penWidthProgressBar.Value = _PenWidth;
                penWidthLabel.Text = _PenWidth.ToString();
            }
        }
        private const int StandartCanvasWidth = 300;
        private const int StandartCanvasHeight = 300;
        public DrawStarForm StarSettingsForm;
        private bool StarSettingsFormClosed = true;

        public Form1()
        {
            InitializeComponent();
            blackToolStripMenuItem_Click(blackToolStripMenuItem, new());
            ручкаToolStripMenuItem_Click(ручкаToolStripMenuItem, new());
            PenWidth = 3;
        }


        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAbout = new AboutBox1();
            frmAbout.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new DocumentForm(StandartCanvasWidth, StandartCanvasHeight, this);
            frm.MdiParent = this;
            frm.Show();
        }

        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CanvasSizeForm(this).Show();
        }

        private void picToolStripMenuItem_Click(object sender, EventArgs e)
        {
            размерХолстаToolStripMenuItem.Enabled = ActiveMdiChild != null;
            уменьшитьToolStripMenuItem.Enabled = ActiveMdiChild != null;
            увеличитьToolStripMenuItem.Enabled = ActiveMdiChild != null;
            стандартныйМасштабToolStripMenuItem.Enabled = ActiveMdiChild != null;
            updateScaleInfoTextBox();
        }
        private void setupColor(Color color, object sender)
        {
            PenColor = color;
            foreach (ToolStripMenuItem toolStripMenuItem in penColorDropDownButton.DropDownItems)
            {
                toolStripMenuItem.Checked = false;
            }
            ((ToolStripMenuItem)sender).Checked = true;
            penColorDropDownButton.Image = ((ToolStripMenuItem)sender).Image;
        }
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupColor(Color.Red, sender);
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupColor(Color.Blue, sender);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupColor(Color.FromArgb(0,255,0), sender);
        }
        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupColor(Color.Black, sender);
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupColor(Color.White, sender);
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // LABA3
            //ColorDialog cd = new ColorDialog();
            //if (cd.ShowDialog() == DialogResult.OK)
            //    setupColor(cd.Color, sender);
            var f = new RGB.MainWindow(PenColor.R, PenColor.G, PenColor.B).ShowDialogRgb();
            if (f.isSaved)
                setupColor(Color.FromArgb(f.r, f.g, f.b), sender);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((ActiveMdiChild != null))
                ((DocumentForm)ActiveMdiChild).Save();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((ActiveMdiChild != null))
                ((DocumentForm)ActiveMdiChild).SaveAs();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp|Файлы JPEG (*.jpeg, *.jpg)|*.jpeg;*.jpg|Файлы PNG (*.png)|*.png";
            ImageFormat[] ff = { ImageFormat.Bmp, ImageFormat.Jpeg, ImageFormat.Png };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var frm = new DocumentForm(Image.FromFile(dlg.FileName), ff[dlg.FilterIndex - 1], dlg.FileName, this);
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem.Enabled = (ActiveMdiChild != null);
            сохранитьКакToolStripMenuItem.Enabled = (ActiveMdiChild != null);
        }

        private void penWidthButtonLow_Click(object sender, EventArgs e)
        {
            PenWidth -= 1;
        }

        private void penWidthButtonUp_Click(object sender, EventArgs e)
        {
            PenWidth += 1;
        }

        private void ручкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupPen(PenTypes.Pen, sender);
        }

        private void линияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupPen(PenTypes.Line, sender);
        }

        private void эллипсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupPen(PenTypes.Ellipse, sender);
        }

        private void ластикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupPen(PenTypes.Eraser, sender);
        }
        private void setupPen(PenTypes penType, object sender)
        {
            if ((penType != PenTypes.Star) & (!StarSettingsFormClosed))
            {
                StarSettingsForm.PenChangeClose();
            }
            PenType = penType;
            foreach (ToolStripMenuItem toolStripMenuItem in penTypeDropDownButton.DropDownItems)
            {
                toolStripMenuItem.Checked = false;
            }
            ((ToolStripMenuItem)sender).Checked = true;
            penTypeDropDownButton.Image = ((ToolStripMenuItem)sender).Image;
        }

        private void увеличитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((DocumentForm)ActiveMdiChild).BitmapScale *= 1.25;
            updateScaleInfoTextBox();
        }

        private void уменьшитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((DocumentForm)ActiveMdiChild).BitmapScale /= 1.25;
            updateScaleInfoTextBox();
        }

        private void стандартныйМасштабToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((DocumentForm)ActiveMdiChild).BitmapScale = 1;
            updateScaleInfoTextBox();
        }
        private void updateScaleInfoTextBox()
        {
            if (ActivateMdiChild != null)
            {
                scaleInfoTextBox.Text = $"{(int)(((DocumentForm)ActiveMdiChild).BitmapScale * 10000) / 100.0}";
            }
        }

        private void scaleInfoTextBox_TextChanged(object sender, EventArgs e)
        {
            double scale;
            if (double.TryParse(scaleInfoTextBox.Text, out scale))
            {
                ((DocumentForm)ActiveMdiChild).BitmapScale = scale / 100.0;
            }
            else
            {
                updateScaleInfoTextBox();
            }
        }

        private void звездаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupPen(PenTypes.Star, sender);
            if (StarSettingsFormClosed)
            {
                StarSettingsForm = new(this);
                StarSettingsForm.MdiParent = this;
                StarSettingsForm.Show();
                StarSettingsFormClosed = false;
            }
        }

        public void DrawStarFormClosed(bool penChanged)
        {
            if (!penChanged)
            {
                ручкаToolStripMenuItem_Click(ручкаToolStripMenuItem, new());
            }
            StarSettingsFormClosed = true;
        }

    }
}