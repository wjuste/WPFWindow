using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
    public interface IQuizService
    {
        List<Quiz> FindQuizzes();
        Quiz FindQuizById(int quizId);
        QuizQuestion FindQuestion(int quizId, int numOrder);
        List<QuizResponse> FindResponses(int questionId);
        QuizResponse FindResponseById(int responseId);
        int CountQuestions(int quizId);
    }
}
