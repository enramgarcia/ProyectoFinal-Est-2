using ProyectoFinal.Models.Graphs;
using ProyectoFinal.ViewModels.Graphs;
using ProyectoFinal.ViewModels;
using ProyectoFinal.Windows.Graphs;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace ProyectoFinal.Commands.Graphs
{
    /// <summary>
    /// Comando para editar una arista.
    /// </summary>
    public class EditEdgeCmd : BaseCommand
    {
        private GraphViewModel _viewModel;

        public EditEdgeCmd(GraphViewModel viewModel)
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
        /// Cambiar estado de boton si existen nodos y arista.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanExecute(object parameter)
        {
            return _viewModel.Nodes.Count > 0 && base.CanExecute(parameter);
        }

        /// <summary>
        /// Editar una arista.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(GraphEdge))
            {
                return;
            }

            GraphEdge edge = parameter as GraphEdge;
            GraphNode from = edge.From;
            GraphNode to = edge.To;

            List<GraphNode> locations = _viewModel.Nodes.Where(x => x.Id != from.Id)
                .ToList();

            // No existen nodos ajenos al actual.
            if (locations.Count() == 0)
            {
                MessageBox.Show("No se puede agregar una conexión, ya que no existen más ubicaciones.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            AddEdgeLocationWindow window = new AddEdgeLocationWindow(_viewModel.MainVm.Owner, from, locations, to, edge.Distance);

            // No se confirmo el formulario.
            if (window.ShowDialog() != true)
            {
                return;
            }

            EdgeLocationViewModel locationVm = window.DataContext as EdgeLocationViewModel;

            int index = _viewModel.Edges.IndexOf(edge);

            // No se pudo encontrar index de la arista.
            if (index == -1)
            {
                MessageBox.Show("Ocurrió un error inesperado al agregar la conexión, no se pudo encontrar el registro.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            _viewModel.Edges[index].Distance = locationVm.Distance;
        }
    }
}
