
using System;
using System.Globalization;
using System.Windows.Data;

namespace SuperYahtzee.Controls
{
    public class VisibilityPiceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = System.Convert.ToInt16(value);
            switch (System.Convert.ToInt16(parameter))
            {
                case 0:
                    return false;
                case 1:
                    return val > 1;
                case 2:
                    return val == 6;
                case 3:
                    return val > 3;
                case 4:
                    return val == 1 || val == 3 || val == 5;
                case 5:
                    return val > 3;
                case 6:
                    return val == 6;
                case 7:
                    return val > 1;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
