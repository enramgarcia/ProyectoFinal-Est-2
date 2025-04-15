using ProyectoFinal.ViewModels;
using System.Windows;

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Cargamos libreria de FontAwesome para evitar bug de binding.
            var type = typeof(FontAwesome.WPF.FontAwesome);

            DataContext = new MainViewModel(this);
            InitializeComponent();
        }
    }
}
