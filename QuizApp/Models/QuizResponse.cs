using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public  class QuizResponse
    {
        public int? Id { get; set; }
        public string RespText { get; set; }
        public bool Correct { get; set; }

        //ManyToOne
        public QuizQuestion Question { get; set; }
        public int? QuestionId { get; set; }

        public override string ToString()
        {
            return RespText;
        }
    }
}
