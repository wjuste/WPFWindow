using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Repositories
{
    public interface IUserRepository
    {
        List<User> FindAll();
    }
}
