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
    public partial class DrawStarForm : Form
    {
        public DrawStarForm(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        private Form1 mainForm;
        public decimal NumberOfRays { get { return rayNumericUpDown.Value; } }
        public decimal InnerRadius { get { return innerRadNumericUpDown.Value; } }
        public decimal OutherRadius { get { return outherRadNumericUpDown.Value; } }
        public decimal Angle { get { return angleNumericUpDown.Value; } }
        private bool penChangedClose = false;
        public void PenChangeClose()
        {
            penChangedClose = true;
            Close();
        }

        private void DrawStarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.DrawStarFormClosed(penChangedClose);
        }
    }
}
