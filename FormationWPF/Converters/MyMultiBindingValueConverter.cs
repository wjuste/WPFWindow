using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FormationWPF.Converters
{
    public class MyMultiBindingValueConverter : IMultiValueConverter
    {

        /// <summary>
        /// La méthode Convert reçoit un tableau de chaine de caractère en entrée 
        /// puis la converti en chaine de caractè
        /// ex : ["Ella" "Debonsyeux"]   ==>  "Ella \t Debonsyeux"
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values.Count() <= 0)
            {
                return string.Empty;
            }

            string res = string.Empty;

            foreach (var item in values)
            {
                res += item + "\t";
            }

            return res;

        }


        /// <summary>
        /// La méthode ConvertBack reçoit une chaine de caractère en entrée puis la converti en tableau de chaine de caractère
        /// ex : "Ella \t Debonsyeux"  ==>  ["Ella" "Debonsyeux"]  
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string str = value as string;
            char separator = '\t';
            if(str == string.Empty)
            {
                return null;
            }
            return str.Split(separator);
        }
    }
}
