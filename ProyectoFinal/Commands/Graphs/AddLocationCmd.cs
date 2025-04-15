using ProyectoFinal.Models.Graphs;
using ProyectoFinal.ViewModels;
using ProyectoFinal.Windows.Graphs;
using System;
using System.ComponentModel;
using System.Windows.Media;

namespace ProyectoFinal.Commands.Graphs
{
    /// <summary>
    /// Clase del comando para agregar un nodo al grafo.
    /// </summary>
    public class AddLocationCmd : BaseCommand
    {
        /// <summary>
        /// Variable del ViewModel desde el cual se llama el comando para poder acceder a las variables del mismo.
        /// </summary>
        private GraphViewModel _viewModel;

        public AddLocationCmd(GraphViewModel viewModel)
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
            if (args.PropertyName == nameof(GraphViewModel.Name))
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
            return !string.IsNullOrEmpty(_viewModel.Name) && base.CanExecute(parameter);
        }

        /// <summary>
        /// Ejecución del comando de agregar Node al Grafo.
        /// </summary>
        /// <param name="parameter"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Execute(object parameter)
        {

            int count = _viewModel.Nodes.Count;

            double x = 100 + count * 50;
            double y = 100 + count * 50;

            GraphNode newNode = new GraphNode(_viewModel.Name, x, y, Brushes.Green);
            _viewModel.Name = "";

            _viewModel.Nodes.Add(newNode);
        }
    }
}
