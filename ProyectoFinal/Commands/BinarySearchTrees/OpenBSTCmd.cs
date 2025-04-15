using ProyectoFinal.ViewModels.LinkedLists;
using ProyectoFinal.Windows.BinarySearchTrees;

namespace ProyectoFinal.Commands.BinarySearchTrees
{
    /// <summary>
    /// Comando para mostrar ABB.
    /// </summary>
    public class OpenBSTCmd : BaseCommand
    {
        private LinkedListViewModel _viewModel;

        public OpenBSTCmd(LinkedListViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// Ejecutar comando abrtiendo ventana de ABB.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            UserTaskBSTWindow window = new UserTaskBSTWindow(_viewModel.MainVm.Owner, _viewModel.UserTasks);

            window.ShowDialog();
        }
    }
}
