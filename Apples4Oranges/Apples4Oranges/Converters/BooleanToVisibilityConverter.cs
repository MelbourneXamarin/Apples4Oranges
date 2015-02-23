using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apples4Oranges.Converters
{

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public bool IsInverted { get; set; }

        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
           if(IsInversed)
               return value ? Visibility.Collapsed : Visibility.Visible;

            return value ? Visibility.Visible: Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
           throw new NotImplementedException();
        }
    }
}
