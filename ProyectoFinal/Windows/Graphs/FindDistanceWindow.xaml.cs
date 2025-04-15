using ProyectoFinal.Models.Graphs;
using ProyectoFinal.ViewModels.Graphs;
using System.Collections.Generic;
using System.Windows;

namespace ProyectoFinal.Windows.Graphs
{
    /// <summary>
    /// Interaction logic for FindDistanceWindow.xaml
    /// </summary>
    public partial class FindDistanceWindow : Window
    {
        public FindDistanceWindow(Window owner, IList<GraphNode> locations)
        {
            // Cargamos libreria de FontAwesome para evitar bug de binding.
            var type = typeof(FontAwesome.WPF.FontAwesome);

            Owner = owner;
            DataContext = new FindDistanceViewModel(this, locations);
            InitializeComponent();
        }
    }
}
