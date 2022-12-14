using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationWPF.Models
{
    public class User : INotifyPropertyChanged
    {
        //1er et 2ème étape
        //  public string UserName { get; set; }

        //3ème étape 
        //Par convention de nommage on préfixe les champs d'un underscore 
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            
            set {
                    _userName = value;
                //Méthode appelée chaque fois que la propriété UserName est mise à jour 
                NotifyPropertyChanged("UserName");
            }
        }

    
        //Permet de créer automatiquement un évenement : PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Méthode est appelée par le setter de la propriété UserName
        /// L'évenement PropertyChanged est appelé dans cette méthode, lorsque 
        /// la propriété UserName est modifiée
        /// </summary>
        /// <param name="propertyName">UserName</param>
        /// <exception cref="NotImplementedException"></exception>
        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                //Nous executons cet évenement en passant le nom de la propriété 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
