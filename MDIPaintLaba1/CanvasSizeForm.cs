using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaintLaba1
{
    public partial class CanvasSizeForm : Form
    {
        private Form1 mainForm;
        public CanvasSizeForm(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            widthNumericUpDown.Value = ((DocumentForm)mainForm.ActiveMdiChild).CanvasWidth;
            heightNumericUpDown.Value = ((DocumentForm)mainForm.ActiveMdiChild).CanvasHeight;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ((DocumentForm)mainForm.ActiveMdiChild).CanvasWidth = (int)widthNumericUpDown.Value;
            ((DocumentForm)mainForm.ActiveMdiChild).CanvasHeight = (int)heightNumericUpDown.Value;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
