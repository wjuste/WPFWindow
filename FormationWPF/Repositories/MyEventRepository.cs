using FormationWPF.Contexts;
using FormationWPF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationWPF.Repositories
{
    public class MyEventRepository : IMyEventRepository
    {

        ////LINQ: Langage Integrated Query: langage propre à microsoft - permet d'intéroger
        ////n'importe quelle source de données : base de données, fichier..............
        ////2 façons d'utiliser LINQ: Soit via la syntaxe SQL- soit via des appels successifs de méthodes
        ////1-Syntaxe SQL: convient aux dev sql
        ////2- Chainage des méthodes: convient aux dev

        private MyEventDbContext db;  //null

        public MyEventRepository(MyEventDbContext db)
        {
            this.db = db;
        }

        public int Count()
        {
            //Utilisation de la syntaxe SQL : 
                    //Initialisation 
                    //Condition 
                    //Selection
           return(from evt in db.MyEvents.AsNoTracking() select evt.Id).Count();
        }

        //Avec Entry on peut avoir grace au context des informations sur l'entité par exemple état
        public void Delete(MyEvent evt)
        {
           // db.MyEvents.Remove(evt);    
           db.Entry(evt).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<MyEvent> FindAll()
        {
            return db.MyEvents.AsNoTracking().ToList();
        }

        public MyEvent FindById(int id)
        {
            return db.MyEvents.Find(id);
        }

        public void SaveOrUpdate(MyEvent evt)
        {
           if(evt.Id == 0 )  //Sauvegarder 
            {
                db.MyEvents.Add(evt);    //evt : etat Added 
            } else   //Mettre à jour
            {
                db.Entry(evt).State = EntityState.Modified;    
            }

           db.SaveChanges();
        }

        public List<MyEvent> Search(string searchStr)
        {
            return db.MyEvents.AsNoTracking().Where(evt => evt.Title.Contains(searchStr)
                        || evt.Description.Contains(searchStr)
                        || evt.StartDate.ToString().Contains(searchStr)
                        || evt.EndDate.ToString().Contains(searchStr)).ToList();
        }
    }
}
