using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class QuizTest
    {
        public int? Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }

        //ManyToOne
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? UserId { get; set; }

        //ManyToOne 
        [ForeignKey("QuizId")]
        public User Quiz { get; set; }
        public int? QuizId { get; set; }



    }
}
