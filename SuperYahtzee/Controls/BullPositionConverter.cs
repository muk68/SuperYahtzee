using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SuperYahtzee.Controls
{
    public class BullPositionConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValue = System.Convert.ToDouble(value[0]);
            var par = System.Convert.ToInt16(value[1]);
            var factor = System.Convert.ToDouble(value[2]);
            if (doubleValue > 0 && factor > 0)
            {
                switch (par)
                {
                    case 0://top
                        return doubleValue / 15;
                    case 1: //center
                        return doubleValue / 2 - (doubleValue * factor / 2);
                    case 2://bottom
                        return (doubleValue / 15 * 14) - (doubleValue * factor);
                }
            }
            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }




}
