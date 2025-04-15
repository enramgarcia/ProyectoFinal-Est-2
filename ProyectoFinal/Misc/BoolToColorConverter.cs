using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ProyectoFinal.Misc
{
    /// <summary>
    /// Convertir un bool a un color. - Deprecado.
    /// </summary>
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Brushes.Red : Brushes.Blue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
