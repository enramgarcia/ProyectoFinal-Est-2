using ProyectoFinal.ViewModels.LinkedLists;
using System.ComponentModel;

namespace ProyectoFinal.Commands.LinkedLists
{
    /// <summary>
    /// Comando para confirmar form y agregar tarea.
    /// </summary>
    public class SaveTaskCmd : BaseCommand
    {
        private UserTaskViewModel _viewModel;

        public SaveTaskCmd(UserTaskViewModel viewModel)
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
            if (args.PropertyName == nameof(UserTaskViewModel.Title)
                || args.PropertyName == nameof(UserTaskViewModel.Description)
                || args.PropertyName == nameof(UserTaskViewModel.Priority)
                || args.PropertyName == nameof(UserTaskViewModel.Status))
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
            return !string.IsNullOrEmpty(_viewModel.Title)
                && !string.IsNullOrEmpty(_viewModel.Description)
                && base.CanExecute(parameter);
        }

        /// <summary>
        /// Confirma creacion de tarea.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            _viewModel.Owner.DialogResult = true;
            _viewModel.Owner.Close();
        }
    }
}
