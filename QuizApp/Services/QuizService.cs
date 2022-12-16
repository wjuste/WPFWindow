using QuizApp.Models;
using QuizApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
    public class QuizService : IQuizService
    {

        private IQuizRepository quizRepository;


        public QuizService(IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
        }

        public int CountQuestions(int quizId)
        {
          return quizRepository.CountQuestions(quizId);    
        }

        public QuizQuestion FindQuestion(int quizId, int numOrder)
        {
            return quizRepository.FindQuestion(quizId, numOrder); 
        }

        public Quiz FindQuizById(int quizId)
        {
            return quizRepository.FindQuizById(quizId);
        }

        public List<Quiz> FindQuizzes()
        {
            return quizRepository.FindQuizzes();
        }

        public QuizResponse FindResponseById(int responseId)
        {
            return quizRepository.FindResponseById(responseId);
        }

        public List<QuizResponse> FindResponses(int questionId)
        {
            return quizRepository.FindResponses(questionId);
        }
    }
}
