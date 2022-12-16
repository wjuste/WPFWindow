using QuizApp.Contexts;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private MyDbContext db;

        public QuizRepository(MyDbContext db)
        {
            this.db = db;
        }

        public int CountQuestions(int quizId)
        {
            int nbreQuestions = db.QuizQuestions.AsNoTracking().Where(qst => qst.QuizId == quizId).Count();
            return nbreQuestions;
        }

        public QuizQuestion FindQuestion(int quizId, int numOrder)
        {
            return db.QuizQuestions.AsNoTracking().SingleOrDefault(qst => qst.QuizId == quizId && qst.NumOrder == numOrder);
        }

        public Quiz FindQuizById(int quizId)
        {
            return db.Quizzes.Find(quizId);
        }

        /// <summary>
        /// Recuperer la liste des Quiz d'une Category
        /// Eager Loading (Chargement immédiat): On charge les Quiz en incluant la Catégorie du Quiz
        ///     Utilisation de la méthode Include 
        /// </summary>
        /// <returns></returns>
        public List<Quiz> FindQuizzes()
        {
            return db.Quizzes.Include(quiz => quiz.Category).AsNoTracking().ToList();
        }

        public QuizResponse FindResponseById(int responseId)
        {
            return db.QuizResponses.Find(responseId);   
        }

        public List<QuizResponse> FindResponses(int questionId)
        {
           //Condition ==> Where 
        }
    }
}
