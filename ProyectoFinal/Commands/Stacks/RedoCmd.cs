using ProyectoFinal.ViewModels.LinkedLists;
using System;
using System.Windows;

namespace ProyectoFinal.Commands.Stacks
{
    /// <summary>
    /// Acción para rehacer una acción.
    /// </summary>
    /// <param name="parameter"></param>
    public class RedoCmd : BaseCommand
    {
        private LinkedListViewModel _viewModel;

        public RedoCmd(LinkedListViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// Ejecutamos acción para rehacer una acción.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            try
            {
                _viewModel.UserTasks.Redo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
