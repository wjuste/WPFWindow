using QuizApp.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace QuizApp.Contexts
{
    public class MyDbContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « MyDbContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « QuizApp.Contexts.MyDbContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « MyDbContext » dans le fichier de configuration de l'application.
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        //1er DbSet ===>  Quiz
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<QuizCategory> QuizCategories { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }
        public virtual DbSet<QuizResponse> QuizResponses { get; set; }
        public virtual DbSet<QuizTest> QuizTests { get; set; }

        public virtual DbSet<User> Users { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}