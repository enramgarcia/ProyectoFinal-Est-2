using ProyectoFinal.ViewModels.Graphs;
using System.ComponentModel;

namespace ProyectoFinal.Commands.Graphs
{
    /// <summary>
    /// Comando para confirmar busqueda de distancia.
    /// </summary>
    public class FindDistanceCmd : BaseCommand
    {
        private FindDistanceViewModel _viewModel;

        public FindDistanceCmd(FindDistanceViewModel viewModel)
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
            if (args.PropertyName == nameof(FindDistanceViewModel.From)
                || args.PropertyName == nameof(FindDistanceViewModel.To))
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
            return _viewModel.From != null && _viewModel.To != null && base.CanExecute(parameter);
        }

        /// <summary>
        /// Confirmar busqueda.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            _viewModel.Owner.DialogResult = true;
            _viewModel.Owner.Close();
        }
    }
}
