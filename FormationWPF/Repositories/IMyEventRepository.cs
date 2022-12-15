using FormationWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationWPF.Repositories
{
    public  interface IMyEventRepository
    {
        List<MyEvent> FindAll();
        MyEvent FindById(int id);
        void SaveOrUpdate(MyEvent evt);
        int Count();
        void Delete(MyEvent evt);
        List<MyEvent> Search(string searchStr);
    }
}
