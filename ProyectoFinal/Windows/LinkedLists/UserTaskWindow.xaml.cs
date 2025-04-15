using ProyectoFinal.Models.LinkedLists;
using ProyectoFinal.ViewModels.LinkedLists;
using System.Windows;

namespace ProyectoFinal.Windows.LinkedLists
{
    /// <summary>
    /// Interaction logic for UserTaskWindow.xaml
    /// </summary>
    public partial class UserTaskWindow : Window
    {
        public UserTaskWindow(Window owner)
        {
            // Cargamos libreria de FontAwesome para evitar bug de binding.
            var type = typeof(FontAwesome.WPF.FontAwesome);

            Owner = owner;
            DataContext = new UserTaskViewModel(this);
            InitializeComponent();
        }

        public UserTaskWindow(Window owner, UserTask task)
        {
            // Cargamos libreria de FontAwesome para evitar bug de binding.
            var type = typeof(FontAwesome.WPF.FontAwesome);

            Owner = owner;
            DataContext = new UserTaskViewModel(this, task);
            InitializeComponent();
        }
    }
}
