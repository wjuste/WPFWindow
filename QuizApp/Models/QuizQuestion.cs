using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class QuizQuestion
    {
        public int? Id { get; set; }
        public string QstText { get; set; }
        public bool  MultipleChoice { get; set; }
        public int NumOrder { get; set; }

        //ManyToOne
        public Quiz Quiz { get; set; }
        public int? QuizId { get; set; }  
    }
}
