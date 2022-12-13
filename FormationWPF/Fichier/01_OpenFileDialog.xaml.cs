using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FormationWPF.Fichier
{
    /// <summary>
    /// Logique d'interaction pour _01_OpenFileDialog.xaml
    /// </summary>
    public partial class _01_OpenFileDialog : Window
    {
        public _01_OpenFileDialog()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Definir le repertoire initial 
            openFileDialog.InitialDirectory = @"C:\Users\Admin stagiaire.DESKTOP-8967908\Desktop\MiseEnPratique\FormationWPF_12_12_2022\Docs";

            //Definir un filtre pour l'extension du fichier 
            openFileDialog.Filter = "Text file(*txt) | *.txt| All files(*.*) | *.*";

            if (openFileDialog.ShowDialog() == true)
            {
                //Contient le  chemin du fichier 
                FileNameTextBox.Text = openFileDialog.FileName;

                TextBlock.Text = File.ReadAllText(openFileDialog.FileName, Encoding.GetEncoding("iso-8859-1"));
            } else
            {
                MessageBox.Show("Import fichier txt Annulé");
            }
        }
    }
}
