using ProyectoFinal.ViewModels;
using System;
using System.Windows.Media;

namespace ProyectoFinal.Models.Graphs
{
    /// <summary>
    /// Clase de definición de un Nodo para poder generar las aristas y luego dibujar en el canvas.
    /// </summary>
    public class GraphNode : BaseViewModel
    {
        /// <summary>
        /// GUID del Nodo, se genera un ID único para evitar colisiones de ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Texto a mostrar en el Nodo.
        /// </summary>
        public string Text { get; set; }

        private double _x;

        /// <summary>
        /// Posición X en el Canvas para dibujar el Nodo.
        /// </summary>
        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        private double _y;

        /// <summary>
        /// Posición Y en el Canvas para dibujar el Nodo.
        /// </summary>
        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        public Brush Color { get; set; }

        /// <summary>
        /// Flag de selección del Nodo.
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Constructor del Nodo, se toma como parametros las posiciones en el Canvas (x, y).
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public GraphNode(string text ,double x, double y, Brush color)
        {
            Id = Guid.NewGuid();
            Text = text;
            X = x;
            Y = y;
            Color = color;
        }
    }
}
