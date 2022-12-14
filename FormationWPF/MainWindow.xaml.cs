using FormationWPF.Binding;
using FormationWPF.Controles;
using FormationWPF.Fichier;
using FormationWPF.MiseEnForme;
using FormationWPF.MiseEnPage;
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

namespace FormationWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         * Les boites de dialiogue sont des fenêtres d'affichages
         * Elles peuvent s'afficher en mode  "Modal" ou "Non Modal"
         * Il existe deux méthodes permettant d'afficher une fenêtre soient en mode modal ou non modal: 
         *          - La méthode Show : permet d'afficher une fenêtre en mode "non modal "
         *                                             Cela signifie que vous pouvez basculer ou activer les autres fenêtre  de l'application 
         *                                              même lorsque la fenêtre actuelle est une fenêtre active
         *          - La méthode ShowDialog : Ouvre une fenêtre en tant que fenêtre "modale"
         *                                                      Cela signifie que lorsque la fenêtre est active, tous les autres fenêtre de l'application sont 
         *                                                      desactivées. On ne peut pas basculer vers d'autres fenêtres tant que la fenêtre actuelle 
         *                                                      n'est pas fermée.
         */

        private void miModale_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow w = new NavigationWindow();
            w.ShowDialog();
        }

        private void miNonModale_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow w = new NavigationWindow();
            w.Show();
        }

        private void miBoiteSimpte_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WPF, c'est facile!");
        }

        private void miBoiteP_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rs =  MessageBox.Show("Etes vous prêt à sauter ? ", "Titre", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(rs == MessageBoxResult.Yes)
            {
                MessageBox.Show("Vous n'auriez pas dû!!!");
            } else
            {
                MessageBox.Show("Excellente décision!!!");
            }
        }

        private void miQuitter_Click(object sender, RoutedEventArgs e)
        {
            // this.Close();
            //  ou
            Application.Current.Shutdown();
        }

        private void miAncrage_Click(object sender, RoutedEventArgs e)
        {
            _01_Ancrage ancrage = new _01_Ancrage();
            ancrage.ShowDialog();
        }

        private void miStackP_Click(object sender, RoutedEventArgs e)
        {
            _02_StackPanel stackPanel = new _02_StackPanel();   
            stackPanel.ShowDialog();
        }

        private void miWrapPanel_Click(object sender, RoutedEventArgs e)
        {
            _03_WrapPanel wp = new _03_WrapPanel();  
            wp.ShowDialog();
        }

        private void miDockPanel_Click(object sender, RoutedEventArgs e)
        {
            _04_DockPanel dockPanel = new _04_DockPanel();
            dockPanel.ShowDialog();   
        }

        private void miGrid_Click(object sender, RoutedEventArgs e)
        {
            _05_Grid grid = new _05_Grid();
            grid.ShowDialog();
        }

        private void miCanvas_Click(object sender, RoutedEventArgs e)
        {
            _06_Canvas canvas = new _06_Canvas();
            canvas.ShowDialog();
        }

        private void miControleCommun_Click(object sender, RoutedEventArgs e)
        {
            _01_ControlesCommunsWPF  cm = new _01_ControlesCommunsWPF();
            cm.ShowDialog();    
        }

        private void miOuvrir_Click(object sender, RoutedEventArgs e)
        {
            _01_OpenFileDialog openFileDialog = new _01_OpenFileDialog();
            openFileDialog.ShowDialog();
        }

        private void miEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            _02_SaveFileDialog saveFileDialog = new _02_SaveFileDialog();
            saveFileDialog.ShowDialog();
        }

        private void miMedia_Click(object sender, RoutedEventArgs e)
        {
            _02_Media media = new _02_Media();
            media.ShowDialog();
        }

        private void miBinding_Click(object sender, RoutedEventArgs e)
        {
            _01_Binding  binding = new _01_Binding();
            binding.ShowDialog();
        }

        private void miUpdateSourceTrigger_Click(object sender, RoutedEventArgs e)
        {
            _02_UpdateSourceTrigger updateSourceTrigger = new _02_UpdateSourceTrigger();
            updateSourceTrigger.ShowDialog();
        }

        private void miValueConverter_Click(object sender, RoutedEventArgs e)
        {
            _03_ValueConverter converter = new _03_ValueConverter();
            converter.ShowDialog();
        }

        private void miRespondingToChange_Click(object sender, RoutedEventArgs e)
        {
            _04_RespondingToChange respondingToChange = new _04_RespondingToChange();
            respondingToChange.ShowDialog();
        }

        private void mRessourceBase_Click(object sender, RoutedEventArgs e)
        {
            _01_WindowResource resource =  new _01_WindowResource();
            resource.ShowDialog();
        }

        private void mMiseEnFormeApp_Click(object sender, RoutedEventArgs e)
        {
            _02_MiseEnFormeApp styleTemplate = new _02_MiseEnFormeApp();
            styleTemplate.ShowDialog();
        }
    }
}
