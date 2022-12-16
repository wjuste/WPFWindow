using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class QuizCategory
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        //One (QuizCategory) to Many (Quiz)
       // public ICollection<Quiz> Quizzes { get; set; }
    }
}
