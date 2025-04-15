using ProyectoFinal.ViewModels.LinkedLists;
using ProyectoFinal.Windows.LinkedLists;

namespace ProyectoFinal.Commands.Queues
{
    /// <summary>
    /// Comando para abrir ventana de cola de prioridad.
    /// </summary>
    public  class OpenPriorityQueueCmd : BaseCommand
    {
        private LinkedListViewModel _viewModel;

        public OpenPriorityQueueCmd(LinkedListViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// Ejecuta comando para abrir ventana de cola de prioridad.
        /// </summary>
        public override void Execute(object parameter)
        {
            UserTaskQueueWindow window = new UserTaskQueueWindow(_viewModel.MainVm.Owner, _viewModel.UserTasks.LinkList);

            window.ShowDialog();
        }
    }
}
