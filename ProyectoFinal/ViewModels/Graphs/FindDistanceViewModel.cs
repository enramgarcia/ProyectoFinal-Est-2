using ProyectoFinal.Commands.Graphs;
using ProyectoFinal.Models.Graphs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ProyectoFinal.ViewModels.Graphs
{
    public class FindDistanceViewModel : BaseViewModel
    {
        public Window Owner { get; set; }

        private ObservableCollection<GraphNode> _locations;

        public ObservableCollection<GraphNode> Locations => _locations;

        private ObservableCollection<GraphNode> _toLocations;

        public IList<GraphNode> ToLocations => _toLocations;

        private GraphNode _from;

        public GraphNode From
        {
            get => _from;
            set
            {
                _from = value;
                OnPropertyChanged(nameof(From));
                UpdateToLocations(value);
            }
        }

        private GraphNode _to;

        public GraphNode To
        {
            get => _to;
            set
            {
                _to = value;
                OnPropertyChanged(nameof(To));
            }
        }

        private bool _optionsEnabled;

        public bool OptionsEnabled
        {
            get => _optionsEnabled;
            set
            {
                _optionsEnabled = value;
                OnPropertyChanged(nameof(OptionsEnabled));
            }
        }

        public ICommand FindDistance { get; set; }

        public FindDistanceViewModel(Window owner, IList<GraphNode> locations)
        {
            Owner = owner;
            OptionsEnabled = false;

            _locations = new ObservableCollection<GraphNode>();
            _toLocations = new ObservableCollection<GraphNode>();

            foreach (GraphNode location in locations)
            {
                Locations.Add(location);
            }

            FindDistance = new FindDistanceCmd(this);
        }

        private void UpdateToLocations(GraphNode from)
        {
            if (from == null)
            {
                ToLocations.Clear();
                To = null;
                OptionsEnabled = false;
                return;
            }

            ToLocations.Clear();

            IList<GraphNode> nodes = Locations.Where(x => x != from).ToList();

            foreach (GraphNode node in nodes)
            {
                ToLocations.Add(node);
            }

            OptionsEnabled = true;
        }
    }
}
