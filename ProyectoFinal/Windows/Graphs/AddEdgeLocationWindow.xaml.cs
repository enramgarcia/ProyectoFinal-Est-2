using ProyectoFinal.Models.Graphs;
using ProyectoFinal.ViewModels.Graphs;
using System.Collections.Generic;
using System.Windows;

namespace ProyectoFinal.Windows.Graphs
{
    /// <summary>
    /// Interaction logic for AddEdgeLocationWindow.xaml
    /// </summary>
    public partial class AddEdgeLocationWindow : Window
    {
        /// <summary>
        /// Clase para agregar arista a un nodo.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="from"></param>
        /// <param name="locations"></param>
        public AddEdgeLocationWindow(
            Window owner,
            GraphNode from,
            IList<GraphNode> locations)
        {
            // Cargamos libreria de FontAwesome para evitar bug de binding.
            var type = typeof(FontAwesome.WPF.FontAwesome);

            Owner = owner;
            DataContext = new EdgeLocationViewModel(this, from, locations);
            InitializeComponent();
        }

        /// <summary>
        /// Constructor para editar artisa de un nodo.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="from"></param>
        /// <param name="locations"></param>
        /// <param name="to"></param>
        /// <param name="distance"></param>
        public AddEdgeLocationWindow(
            Window owner,
            GraphNode from,
            IList<GraphNode> locations,
            GraphNode to,
            double distance)
        {
            // Cargamos libreria de FontAwesome para evitar bug de binding.
            var type = typeof(FontAwesome.WPF.FontAwesome);

            Owner = owner;
            DataContext = new EdgeLocationViewModel(this, from, locations, to, distance);
            InitializeComponent();
        }
    }
}
