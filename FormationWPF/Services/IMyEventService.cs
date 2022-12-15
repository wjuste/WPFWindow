using FormationWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationWPF.Services
{
    public interface IMyEventService
    {
        List<MyEvent> FindAll();
        MyEvent FindById(int id);
        void SaveOrUpdate(MyEvent evt);
        int Count();
        void Delete(MyEvent evt);
        List<MyEvent> Search(string searchStr);

        void ToCSV(List<MyEvent> events, string filePath, bool append, char separator, Encoding enc);

        List<MyEvent> FromCSV(string filePath, char separator, Encoding enc, bool containsHeaderLine, out List<String> ignoredLines);
    }
}
