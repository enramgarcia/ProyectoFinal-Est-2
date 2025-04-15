using System;
using System.Globalization;
using System.Windows.Data;

namespace ProyectoFinal.Misc
{
    /// <summary>
    /// Clase para generar la posición correcta del inicio de una línea de arista entre nodos.
    /// </summary>
    public class OffsetConverter : IValueConverter
    {
        /// <summary>
        /// El diametro de cada nodo es de 40 px, agarramos el radio r = d/2 para poder dibujar correctamente 
        /// las lineas de las aristas.
        /// </summary>
        private const double NodeRadius = 20;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double coordinate)
            {
                return coordinate + NodeRadius;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
