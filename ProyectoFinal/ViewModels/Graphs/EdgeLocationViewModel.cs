using ProyectoFinal.Commands.Graphs;
using ProyectoFinal.Models.Graphs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ProyectoFinal.ViewModels.Graphs
{
    public class EdgeLocationViewModel : BaseViewModel
    {
        /// <summary>
        /// Ventana padre del ViewModel.
        /// </summary>
        public Window Owner { get; set; }

        private GraphNode _from;

        /// <summary>
        /// Nodo origen.
        /// </summary>
        public GraphNode From
        {
            get => _from;
            set
            {
                _from = value;
                OnPropertyChanged(nameof(From));
            }
        }

        private GraphNode _to;

        /// <summary>
        /// Nodo destino.
        /// </summary>
        public GraphNode To
        {
            get => _to;
            set
            {
                _to = value;
                OnPropertyChanged(nameof(To));
            }
        }

        private ObservableCollection<GraphNode> _options;

        /// <summary>
        /// Lista de nodos.
        /// </summary>
        public IList<GraphNode> Options => _options;

        private double _distance;

        /// <summary>
        /// Distancia entre nodos.
        /// </summary>
        public double Distance
        {
            get => _distance;
            set
            {
                _distance = value;
                OnPropertyChanged(nameof(Distance));
            }
        }

        private bool _enableOptions;

        /// <summary>
        /// Flag para validar si el destino es editable.
        /// </summary>
        public bool EnableOptions
        {
            get => _enableOptions;
            set
            {
                _enableOptions = value;
                OnPropertyChanged(nameof(EnableOptions));
            }
        }

        /// <summary>
        /// Comando para confirmar form.
        /// </summary>
        public ICommand AddEdge { get; set; }

        /// <summary>
        /// Constructor para crear arista.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="from"></param>
        /// <param name="locations"></param>
        public EdgeLocationViewModel(Window owner, GraphNode from, IList<GraphNode> locations)
        {
            Owner = owner;
            From = from;
            EnableOptions = true;

            _options = new ObservableCollection<GraphNode>();

            foreach (GraphNode location in locations)
            {
                Options.Add(location);
            }

            AddEdge = new AddEdgeCmd(this);
        }

        /// <summary>
        /// Constructor para editar arista.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="from"></param>
        /// <param name="locations"></param>
        /// <param name="to"></param>
        /// <param name="distance"></param>
        public EdgeLocationViewModel(Window owner, GraphNode from, IList<GraphNode> locations, GraphNode to, double distance)
        {
            Owner = owner;
            From = from;
            To = to;
            Distance = distance;
            EnableOptions = false;

            _options = new ObservableCollection<GraphNode>();

            foreach (GraphNode location in locations)
            {
                Options.Add(location);
            }

            AddEdge = new AddEdgeCmd(this);
        }
    }
}
