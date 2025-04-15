using ProyectoFinal.Models.LinkedLists;
using ProyectoFinal.ViewModels.Queues;
using System.Windows;

namespace ProyectoFinal.Windows.LinkedLists
{
    /// <summary>
    /// Interaction logic for UserTaskQueueWindow.xaml
    /// </summary>
    public partial class UserTaskQueueWindow : Window
    {
        public UserTaskQueueWindow(Window owner, ObservableLinkedList<UserTask> tasks)
        {
            // Cargamos libreria de FontAwesome para evitar bug de binding.
            var type = typeof(FontAwesome.WPF.FontAwesome);

            Owner = owner;
            DataContext = new UserTaskQueueViewModel(tasks);
            InitializeComponent();
        }
    }
}
