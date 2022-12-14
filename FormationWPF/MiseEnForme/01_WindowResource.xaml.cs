using FormationWPF.Properties;
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

namespace FormationWPF.MiseEnForme
{
    /// <summary>
    /// Logique d'interaction pour _01_WindowResource.xaml
    /// </summary>
    public partial class _01_WindowResource : Window
    {
        public _01_WindowResource()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Resources["backgroundBrushDyn"] = new SolidColorBrush(Colors.Red);
        }
    }
}
