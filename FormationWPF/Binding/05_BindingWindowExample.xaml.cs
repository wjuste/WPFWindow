using FormationWPF.Contexts;
using FormationWPF.Models;
using FormationWPF.Repositories;
using FormationWPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FormationWPF.Binding
{
    /// <summary>
    /// Logique d'interaction pour _05_BindingWindowExample.xaml
    /// </summary>
    public partial class _05_BindingWindowExample : Window
    {
        public ObservableCollection<MyEvent> EvtLst { get; set; }
      private MyEventDbContext db;
        private IMyEventService eventService;


        public _05_BindingWindowExample()
        {
            db = new MyEventDbContext();
            eventService = new MyEventService(new MyEventRepository(db));
            List<MyEvent> listEvents = eventService.FindAll();
            EvtLst = new ObservableCollection<MyEvent>(listEvents);
            InitializeComponent();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MyEvent evt = new MyEvent { Title = "event10", Description = "blabla", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) };
            
            eventService.SaveOrUpdate(evt); //Sauvegarde l'evenement dans la base de données
           
            //Ajouter l'evenement dans la listView
            EvtLst.Add(evt);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*
           *  Supprime le contexte et  réinitialiser les ressources non gérées, 
           *  telles que  les connexions à la base de données. 
           *  Dispose améliore les performances et optimise la mémoire en libérant des objets ingérables 
           */
            db.Dispose();
        }

        private void BtnSaveOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            MyEvent evtSel = null;

            if(lstView1.SelectedItem != null)
            {
                evtSel = lstView1.SelectedItem as MyEvent;
                evtSel.Title = TBoxTitle2.Text;
            } else
            {
                evtSel = new MyEvent { Title = "event25", Description = "bla", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) };
            }

            eventService.SaveOrUpdate(evtSel);
            EvtLst.Add(evtSel); 
        }
    }
}
