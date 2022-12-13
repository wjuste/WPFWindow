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

namespace FormationWPF.Controles
{
    /// <summary>
    /// Logique d'interaction pour NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        public NumericUpDown()
        {
            InitializeComponent();
        }

        private void Increase(object sender, RoutedEventArgs e)
        {
            //On récupère la valeur du textBox
            //On le convertit en entier pour pouvoir l'incrementer
           Int32 num = Convert.ToInt32(valueText.Text);

            //On incremente, puis on convertit en string
            num++;
            valueText.Text = num.ToString();
        }

        private void Decrease(object sender, RoutedEventArgs e)
        {
            //On récupère la valeur du textBox
            //On le convertit en entier pour pouvoir le decrementer
            Int32 num = Convert.ToInt32(valueText.Text);

            //On décremente, puis on convertit en string
            num--;
            valueText.Text = num.ToString();
        }
    }
}
