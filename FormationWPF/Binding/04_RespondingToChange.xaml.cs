using FormationWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour _04_RespondingToChange.xaml
    /// </summary>
    public partial class _04_RespondingToChange : Window
    {
        //1er étape 
        //private List<User> users;

        //2ème étape : Toutes les données qui sont dans ObservableCollection seront affichées automatiquement 
        private ObservableCollection<User> users;

        public _04_RespondingToChange()
        {
            InitializeComponent();
            //users = new List<User>();
            users = new ObservableCollection<User>();

            //Notre liste contient deux utilisateurs...
            users.Add(new User { UserName="Andrijana Dupont"});
            users.Add(new User { UserName = "Guy Tariste" });

            //..que nous ajoutons dans la listBox
            lstUsers.ItemsSource = users;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { UserName = "New User" });
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            int postItem = lstUsers.SelectedIndex;

            if(postItem != -1)
            {
                users.RemoveAt(postItem);
            } else
            {
                MessageBox.Show("Veuillez selectionner un User");
            }
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if(lstUsers.SelectedItem != null)
            {
                (lstUsers.SelectedItem as User).UserName = "Random Name";
            } else
            {
                MessageBox.Show("Veuillez selectionner un User");
            }
        }
    }
}
