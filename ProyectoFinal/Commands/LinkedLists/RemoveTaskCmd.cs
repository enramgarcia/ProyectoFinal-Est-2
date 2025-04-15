using ProyectoFinal.Models.LinkedLists;
using ProyectoFinal.ViewModels.LinkedLists;
using System.Windows;

namespace ProyectoFinal.Commands.LinkedLists
{
    /// <summary>
    /// Comando para eliminar una tarea.
    /// </summary>
    public class RemoveTaskCmd : BaseCommand
    {
        private LinkedListViewModel _viewModel;

        public RemoveTaskCmd(LinkedListViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// Se valida confimacion para eliminar y tarea y se elimina al confirmar.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(UserTask))
            {
                return;
            }


            UserTask oldTask = parameter as UserTask;

            MessageBoxResult result = MessageBox.Show("Desea eliminar la tarea?",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            _viewModel.UserTasks.Remove(oldTask);
        }
    }
}
