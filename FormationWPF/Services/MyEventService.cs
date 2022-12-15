using FormationWPF.Models;
using FormationWPF.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationWPF.Services
{
    public class MyEventService : IMyEventService
    {
        private IMyEventRepository repository;

        public MyEventService(IMyEventRepository repository)
        {
            this.repository = repository;
        }

        public int Count()
        {
            return repository.Count();
        }

        public void Delete(MyEvent evt)
        {
            repository.Delete(evt);
        }

        public List<MyEvent> FindAll()
        {
            return repository.FindAll();
        }

        public MyEvent FindById(int id)
        {
            return repository.FindById(id);
        }


        public void SaveOrUpdate(MyEvent evt)
        {
            repository.SaveOrUpdate(evt);
        }

        public List<MyEvent> Search(string searchStr)
        {
            return repository.Search(searchStr);
        }

        public void ToCSV(List<MyEvent> events, string filePath, bool append, char separator, Encoding enc)
        {
            string ext = ".csv";
            if (!filePath.EndsWith(ext))
            {
                filePath += ext;
            }

            using (StreamWriter writer = new StreamWriter(filePath, append, enc))
            {
                //Titre;Description;Date de début; Date de fin
                writer.Write($"Titre{separator}Decription{separator}Date de début{separator}Date de fin");

                foreach (MyEvent v in events)
                {
                    writer.Write($"{v.Title}{separator}{v.Description}{separator}{v.StartDate}{separator}{v.EndDate}");
                }

            }

        }


        public List<MyEvent> FromCSV(string filePath, char separator, Encoding enc, bool containsHeaderLine, out List<String> ignoredLines)
        {
            List<MyEvent> events = new List<MyEvent>();
            ignoredLines = new List<string>();

            using(StreamReader reader = new StreamReader(filePath))
            {
                if(containsHeaderLine)
                {
                    reader.ReadLine();
                }

                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();

                    if(!line.Equals(""))
                    {
                        try
                        {
                            //toto;tata;titi;tutu  ==> [toto, tata, titi tutu]
                            string[] arr = line.Split(separator);
                            if (arr.Length == 4)  //titre description début fin
                            {
                                events.Add(new MyEvent
                                {
                                    Title = arr[0],
                                    Description = arr[1],
                                    StartDate = Convert.ToDateTime(arr[2]),
                                    EndDate = Convert.ToDateTime(arr[3]),
                                });
                            }  else
                            {
                                ignoredLines.Add(line); 
                            }

                        }
                        catch (Exception)
                        {
                            ignoredLines.Add(line);
                        }
                    }
                }
            }
            return events;
        }

    }
}
