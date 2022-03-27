using System;
using System.Windows.Data;

namespace Traffic.Tools
{
    /// <summary>
    /// Конвертер, сравнивающий текущий объект с заданным
    /// </summary>
    public class ComparisonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => 
            value?.Equals(parameter);

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) =>
            value?.Equals(true) == true ? parameter : Binding.DoNothing;
    }
}
