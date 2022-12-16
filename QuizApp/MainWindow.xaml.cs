using QuizApp.Contexts;
using QuizApp.Models;
using QuizApp.Repositories;
using QuizApp.Services;
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

namespace QuizApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IQuizService quizService;
        private MyDbContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new MyDbContext();
            quizService = new QuizService(new QuizRepository(db));
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboQuizzes.ItemsSource = quizService.FindQuizzes();
        }


        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if(ComboQuizzes.SelectedItem != null)
            {
                //Récuperer le Quiz Sélectionné 
                Quiz selectedQuiz = ComboQuizzes.SelectedItem as Quiz;
                //Créer une fenêtre QuizWindow et lui transmet le Quiz 
                QuizWindow qw = new QuizWindow();
                qw.CurrentQuizTest = new QuizTest { Quiz = selectedQuiz, CreationDate = DateTime.Now};

                qw.ShowDialog();

            } else
            {
                MessageBox.Show("Vous devez selectionner un Quiz !");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}
