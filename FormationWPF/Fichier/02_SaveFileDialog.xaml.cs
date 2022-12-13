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
    /// Logique d'interaction pour _02_SaveFileDialog.xaml
    /// </summary>
    public partial class _02_SaveFileDialog : Window
    {

        public _02_SaveFileDialog()
        {
            InitializeComponent();
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Text file(*txt) | *.txt| All files(*.*) | *.*";

            if(saveFileDialog.ShowDialog() == true)
            {
                using(StreamWriter sw = new StreamWriter(saveFileDialog.FileName, true))
                {
                    sw.WriteLine(txtEditor.Text);
                }
                MessageBox.Show("Enregistrement effectué");
            }else
            {
                MessageBox.Show("Enregistrement annulé");
            }
        }

    }
}
