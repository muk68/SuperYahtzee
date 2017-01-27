using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SuperYahtzee.Controls
{
    public class MarginConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var widthParent = System.Convert.ToDouble(values[0]) * 1.2;
            switch (System.Convert.ToInt32(values[1]))
            {
                case 1://top
                    return new Thickness(0, widthParent / 2 * -1, 0, 0);
                case 2://left middle
                    return new Thickness(widthParent / 2 * -1, 0, 0, 0);
                case 3://middle middle
                    return new Thickness(0, 0, 0, 0);
                case 4://right middle
                    return new Thickness(widthParent / 2, 0, 0, 0);
                case 5://bottom
                    return new Thickness(0, widthParent / 2, 0, 0);
            }
            return new Thickness(0, 0, 0, 0);
        }

        public object[] ConvertBack(object value, System.Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
