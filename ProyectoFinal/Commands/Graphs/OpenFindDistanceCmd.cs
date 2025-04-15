using ProyectoFinal.ViewModels;
using ProyectoFinal.ViewModels.Graphs;
using ProyectoFinal.Windows.Graphs;
using System.ComponentModel;

namespace ProyectoFinal.Commands.Graphs
{
    /// <summary>
    /// Comando para buscar rutas entre 2 nodos.
    /// </summary>
    public class OpenFindDistanceCmd : BaseCommand
    {
        private GraphViewModel _viewModel;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="viewModel"></param>
        public OpenFindDistanceCmd(GraphViewModel viewModel)
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
            if (args.PropertyName == nameof(GraphViewModel.Edges))
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
            return _viewModel.Edges.Count > 0 && base.CanExecute(parameter);
        }

        /// <summary>
        /// Ejecuar comando para preguntar el origen y destino de la busqueda.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            FindDistanceWindow window = new FindDistanceWindow(_viewModel.MainVm.Owner, _viewModel.Nodes);

            if (window.ShowDialog() != true)
            {
                return;
            }

            FindDistanceViewModel findDistanceVm = window.DataContext as FindDistanceViewModel;

            _viewModel.SearchRoute(findDistanceVm.From, findDistanceVm.To);
        }
    }
}
