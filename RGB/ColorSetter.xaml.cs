using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RGB
{
    /// <summary>
    /// Interaction logic for ColorSetter.xaml
    /// </summary>
    public partial class ColorSetter : UserControl
    {
        public ColorSetter()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public string Title { get; set; }

        public delegate void TextBoxLostFocusDelegate(object sender, RoutedEventArgs e);

        public TextBoxLostFocusDelegate TextBoxLostFocus { get; set; }

        void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBoxLostFocus(sender, e);
        }
    }
}