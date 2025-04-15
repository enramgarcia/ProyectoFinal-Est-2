using ProyectoFinal.ViewModels;

namespace ProyectoFinal.Models.Graphs
{
    /// <summary>
    /// Clase para definir aristas entre nodos y poder dibujar las mismas en el Canvas luego.
    /// </summary>
    public class GraphEdge : BaseViewModel
    {
        /// <summary>
        /// Nodo principal.
        /// </summary>
        public GraphNode From { get; set; }

        /// <summary>
        /// Nodo al que apunta la arista.
        /// </summary>
        public GraphNode To { get; set; }

        /// <summary>
        /// Distancia entre cada nodo.
        /// </summary>
        public double Distance { get; set; }

        private bool _isHighlighted;

        /// <summary>
        /// Flag para indicar si una arista esta seleccionada en busqueda de rutas.
        /// </summary>
        public bool IsHighLighted
        {
            get => _isHighlighted;
            set
            {
                _isHighlighted = value;
                OnPropertyChanged(nameof(IsHighLighted));
            }
        }

        public GraphEdge(GraphNode from, GraphNode to, double distance)
        {
            From = from;
            To = to;
            Distance = distance;
        }
    }
}
