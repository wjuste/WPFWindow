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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace QuizApp
{
    /// <summary>
    /// Logique d'interaction pour QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        public QuizTest CurrentQuizTest { get; set; }
        private int nbQuestions;
        private IQuizService quizService;
        private MyDbContext db;
        private int numQst = 1; //Les questions commencent à 1
        private QuizQuestion currentQst;
        private DispatcherTimer myTimer;

        public QuizWindow()
        {
            InitializeComponent();
            db = new MyDbContext();
            quizService = new QuizService(new QuizRepository(db));

            myTimer = new DispatcherTimer(); //On crée le timer
            myTimer.Interval = TimeSpan.FromSeconds(1);  //On fixe l'interval
            myTimer.Tick += TimerJob; //On associe la méthode qui sera déclenchée à chaque Tick
        }

        /// <summary>
        /// Méthode qui sera déclenchée à chaque Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerJob(object sender, EventArgs e)
        {
            int nb = Convert.ToInt32(TBTimer.Text);

            //Si le temps est superieur à zero on met à jour le timer
            if(nb > 0)
            {
                TBTimer.Text = Convert.ToString(nb - 1);
            } else   //Sinon on passe à la question suivante 
            {
                //sender : déclenche l'évenement
                //EventArgs : Aucun argument à ajouter donc à null
                BtnNext_Click(sender, null);
            }
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Récuperer le nombre de question
            nbQuestions = quizService.CountQuestions(CurrentQuizTest.Quiz.Id.Value);

            //Mets à jours le titre du Quiz
            TBQuizTitle.Text = CurrentQuizTest.Quiz.Title;

            LoadQuestion();
        }



        /// <summary>
        /// Charger une Question
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadQuestion()
        {
            myTimer.Stop();
            TBTimer.Text = "10";
            myTimer.Start();

            //Recherche la question du Quiz 
            currentQst = quizService.FindQuestion(CurrentQuizTest.Quiz.Id.Value, numQst);

            //Mets à jour le titre de a question 
            TBQuestionTitle.Text = currentQst.QstText;

            //Récupère la liste des reponses de la question 
            List<QuizResponse> responses = quizService.FindResponses(currentQst.Id.Value);

            //On effacer le panerReponse
            PanelResponses.Children.Clear();

            //Si c'est une question à choix multiple
            if(currentQst.MultipleChoice)
            {
                foreach (QuizResponse r in responses)
                {
                    //Pour chaque reponse on crée un checkBon
                    CheckBox cb = new CheckBox();
                    cb.Content = r;
                    PanelResponses.Children.Add(cb);    
                }
            }else //SInon si c'est une question à choix unique
            {
                foreach (QuizResponse r in responses)
                {
                    //Pour chaque reponse on crée un checkBon
                    RadioButton rb = new RadioButton();
                    rb.Content = r;
                    PanelResponses.Children.Add(rb);
                }
            }
        }


        /// <summary>
        /// Permet de passer à la question suivante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            //Avant passer à la question suivante on va verifier si la reponse de l'utilisateur est correcte 
            if(currentQst.MultipleChoice)
            {
                foreach (var item in PanelResponses.Children)
                {
                    CheckBox cb = item as CheckBox;
                    if(cb.IsChecked.Value == true)
                    {
                        if((cb.Content as QuizResponse).Correct)
                        {
                            //Si la reponse est correcte 
                            CurrentQuizTest.Score++;  //On augment sont score de 1
                        } else
                        {
                            CurrentQuizTest.Score--;
                        }
                    }
                }
            } else
            {
                foreach (var item in PanelResponses.Children)
                {
                    RadioButton rb = item as RadioButton;
                    if(rb.IsChecked.Value == true)
                    {
                        if((rb.Content as QuizResponse).Correct)
                        {
                            CurrentQuizTest.Score++;
                        }
                    }
                }
            }

            if(numQst < nbQuestions)
            {
                numQst++;
                LoadQuestion();  //On charge la nouvelle question

            } else
            {
                myTimer.Stop();
                PanelResponses.Visibility = Visibility.Hidden;
                BtnNext.Visibility = Visibility.Hidden;
                TBQuestionTitle.Text = "Votre score = " + CurrentQuizTest.Score;
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}
