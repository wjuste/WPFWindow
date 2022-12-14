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

namespace FormationWPF.Binding
{
    /// <summary>
    /// Logique d'interaction pour _02_UpdateSourceTrigger.xaml
    /// </summary>
    public partial class _02_UpdateSourceTrigger : Window
    {
        public _02_UpdateSourceTrigger()
        {
            InitializeComponent();
            //Nous attribuons la reference this au DataContext, qui indique simplement à la fenetre que nous voulons qu'elle soit 
            //elle-même le context des données
            this.DataContext = this;
        }

        private void btnUpdateSource_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bindingExpression = txtWindowTitle.GetBindingExpression(TextBox.TextProperty);
            if(bindingExpression != null)
            {
                //La méthode UpdateSource permet d'envoyer la valeur de la cible vers la propriété source 
                bindingExpression.UpdateSource();
            }
        }
    }
}
