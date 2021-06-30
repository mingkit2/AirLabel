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
using System.Windows.Shapes;
using AirLabel.ViewModel;

namespace AirLabel.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PrintLabelView : UserControl
    {
        public PrintLabelView()
        {
            InitializeComponent();
            //PrintLabelViewModel vm = new PrintLabelViewModel(this);
            //this.DataContext = vm;
        }

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
