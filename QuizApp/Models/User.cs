using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public int TotalPoints { get; set; }

        public static implicit operator User(Quiz v)
        {
            throw new NotImplementedException();
        }
    }
}
