using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CryptoCloud.Converters
{
    public class ProgressMirroringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length > 1)
            {
                if (values[0] is double)
                {
                    double maximum = (double)values[0];
                    double valueDouble = (double)values[1];

                    return Math.Abs((maximum - valueDouble));
                }
            }

            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
