using ProyectoFinal.Models.Graphs;
using ProyectoFinal.ViewModels;
using ProyectoFinal.ViewModels.Graphs;
using ProyectoFinal.Windows.Graphs;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace ProyectoFinal.Commands.Graphs
{
    /// <summary>
    /// Comando para agregar arista.
    /// </summary>
    public class OpenEdgeCmd : BaseCommand
    {
        private GraphViewModel _viewModel;

        public OpenEdgeCmd(GraphViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnChanged;
        }

        /// <summary>
        /// Escucha de cambio de propiedades.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(_viewModel.Nodes))
            {
                OnCanExecuteChanged();
            }
        }
        /// <summary>
        /// Cambiar estado de boton.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanExecute(object parameter)
        {
            return _viewModel.Nodes.Count > 0 && base.CanExecute(parameter);
        }

        /// <summary>
        /// Ejecuar comando para agregar una arista.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(GraphNode))
            {
                return;
            }

            GraphNode from = parameter as GraphNode;
            List<GraphNode> locations = _viewModel.Nodes.Where(x => x.Id != from.Id)
                .ToList();

            // No existen mas nodos.
            if (locations.Count() == 0)
            {
                MessageBox.Show("No se puede agregar una conexión, ya que no existen más ubicaciones.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            AddEdgeLocationWindow window = new AddEdgeLocationWindow(_viewModel.MainVm.Owner, from, locations);

            // No se confirmo el form.
            if (window.ShowDialog() != true)
            {
                return;
            }

            EdgeLocationViewModel locationVm = window.DataContext as EdgeLocationViewModel;

            GraphEdge edge = new GraphEdge(from, locationVm.To, locationVm.Distance);

            _viewModel.Edges.Add(edge);
        }
    }
}
