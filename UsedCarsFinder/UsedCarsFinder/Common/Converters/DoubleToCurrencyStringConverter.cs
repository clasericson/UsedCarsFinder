using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UsedCarsFinder.Common.Converters
{
    class DoubleToCurrencyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string language)
        {
            double val = -1d;
            if (value != null && double.TryParse(value.ToString(), out val))
            {
                return val.ToString("c");
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
