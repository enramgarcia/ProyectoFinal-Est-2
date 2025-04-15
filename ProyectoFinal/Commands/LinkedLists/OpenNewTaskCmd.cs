using ProyectoFinal.Models.LinkedLists;
using ProyectoFinal.ViewModels.LinkedLists;
using ProyectoFinal.Windows.LinkedLists;

namespace ProyectoFinal.Commands.LinkedLists
{
    /// <summary>
    /// Comando para crear una nueva tarea.
    /// </summary>
    public class OpenNewTaskCmd : BaseCommand
    {
        private LinkedListViewModel _viewModel;

        public OpenNewTaskCmd(LinkedListViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// Abre un form para llenar los datos y poder crear una tarea al confirmar.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            UserTaskWindow window = new UserTaskWindow(_viewModel.MainVm.Owner);

            if (window.ShowDialog() != true)
            {
                return;
            }

            UserTaskViewModel userTaskVm = window.DataContext as UserTaskViewModel;

            UserTask task = new UserTask(userTaskVm.Title,
                userTaskVm.Description,
                userTaskVm.CompletionDate,
                userTaskVm.Priority,
                userTaskVm.Status);

            _viewModel.UserTasks.Add(task);
        }
    }
}
