using ProyectoFinal.Models.LinkedLists;
using ProyectoFinal.ViewModels.LinkedLists;
using ProyectoFinal.Windows.LinkedLists;

namespace ProyectoFinal.Commands.LinkedLists
{
    /// <summary>
    /// Comando para editar tarea.
    /// </summary>
    public class OpenEditTaskCmd : BaseCommand
    {
        private LinkedListViewModel _viewModel;

        public OpenEditTaskCmd(LinkedListViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// Se abre pantalla de form con los datos de la tarea y se reemplazan por los nuevos al confirmar el form.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(UserTask))
            {
                return;
            }

            UserTask oldTask = parameter as UserTask;

            UserTaskWindow window = new UserTaskWindow(_viewModel.MainVm.Owner, oldTask);

            if (window.ShowDialog() != true)
            {
                return;
            }

            UserTaskViewModel userTaskVm = window.DataContext as UserTaskViewModel;

            UserTask task = new UserTask(oldTask.Id,
                userTaskVm.Title,
                userTaskVm.Description,
                userTaskVm.CompletionDate,
                userTaskVm.Priority,
                userTaskVm.Status);

            _viewModel.UserTasks.Edit(oldTask, task);
        }
    }
}
