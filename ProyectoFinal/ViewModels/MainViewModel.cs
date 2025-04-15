using ProyectoFinal.ViewModels.LinkedLists;
using System.Windows;

namespace ProyectoFinal.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Ventana dueña del DataContext principal.
        /// </summary>
        public Window Owner { get; set; }

        /// <summary>
        /// View Model de las interacciones de la lista enlazada, pila, cola y abb.
        /// </summary>
        public LinkedListViewModel LinkedListVm { get; set; }

        /// <summary>
        /// View model de las interacciones del modulo de ubicaciones.
        /// </summary>
        public GraphViewModel GraphVm { get; set; }

        public MainViewModel(Window owner)
        {
            Owner = owner;
            GraphVm = new GraphViewModel(this);
            LinkedListVm = new LinkedListViewModel(this);
        }
    }
}
