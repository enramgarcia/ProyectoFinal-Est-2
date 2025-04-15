using ProyectoFinal.ViewModels.Graphs;
using System.ComponentModel;

namespace ProyectoFinal.Commands.Graphs
{
    /// <summary>
    /// Agregar arista a otro nodo.
    /// </summary>
    public class AddEdgeCmd : BaseCommand
    {
        private EdgeLocationViewModel _viewModel;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="viewModel"></param>
        public AddEdgeCmd(EdgeLocationViewModel viewModel)
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
            if (args.PropertyName == nameof(EdgeLocationViewModel.Distance)
                || args.PropertyName == nameof(EdgeLocationViewModel.To))
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
            return _viewModel.Distance > 0 && _viewModel.To != null && base.CanExecute(parameter);
        }

        /// <summary>
        /// Cerrar pantalla con ejecucion de aceptado.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            _viewModel.Owner.DialogResult = true;
            _viewModel.Owner.Close();
        }
    }
}
