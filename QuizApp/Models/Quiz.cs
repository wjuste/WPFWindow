using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class Quiz
    {
        public int?  Id { get; set; }   //int? : Ce champ peut accpeter des valeurs null
        public string Title { get; set; }

        //Many Quiz to One Category 
        [ForeignKey("CategoryId")]
        public QuizCategory Category { get; set; }

        public int? CategoryId { get; set; } //int? : Ce champ peut accpeter des valeurs null

        public override string ToString()
        {
            return Title;
        }
    }
}
