using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FormationWPF.Converters
{
    /// <summary>
    /// Convertisseur  :
    /// Traduit une valeur entre la "Source" et la "Cible"
    /// Il prend une chaine de caractère entrée puis retourne un booléen, et inversement
    /// </summary>
    public class YesNoToBooleanConverter : IValueConverter
    {

        /// <summary>
        /// La méthode Convert() récoit une chaine en entrée ("yes" ou "oui") 
        /// puis la convertit en une valeur booléenne (true ou false)
        /// </summary>
        /// <param name="value">Represente l'objet source, qui doit être converti en un autre type</param>
        /// <param name="targetType">Symbolise le type cible</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isConvert = false;
            switch (value.ToString().ToLower()) 
            {
                case "yes":
                case "oui":
                    isConvert = true;
                    break;
                case "no":
                case "non":
                    isConvert = false;
                    break;
                default:
                    break;
            }

            return isConvert;
        }


        /// <summary>
        /// La méthode convertBack : 
        /// Elle prend une valeur entrée, qui est de type Booléen et retourne le mot en angles "yes" ou "no"
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((bool)value)
            {
                return "yes";
            } else
            {
                return "no";
            }
        }
    }
}
