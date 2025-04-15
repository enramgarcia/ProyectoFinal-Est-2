using ProyectoFinal.ViewModels;

namespace ProyectoFinal.Models.Misc
{
    /// <summary>
    /// Class para manejar textos legibles de enumeradores.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumList<T> : BaseViewModel
    {
        private T _value;

        /// <summary>
        /// Valor de enumador.
        /// </summary>
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        private string _text;

        /// <summary>
        /// Texto de enumador de forma legible para el usuario final.
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public EnumList(T value, string text)
        {
            Value = value;
            Text = text;
        }
    }
}
