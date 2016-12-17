using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Chaotica___LingoIO.Core
{
    class ObjectImageConverter : IValueConverter
    {
        // No need to implement converting back on a one-way binding 
        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }

        // This converts the object to ImageSource.
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            return (ImageSource)value;
        }
    }
}
