using ProyectoFinal.Models.Graphs;
using ProyectoFinal.ViewModels;

namespace ProyectoFinal.Commands.Graphs
{
    /// <summary>
    /// Comando para eliminasr arista
    /// </summary>
    public class DeleteEdgeCmd : BaseCommand
    {
        private GraphViewModel _viewModel;

        public DeleteEdgeCmd(GraphViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// Eliminar una arista.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(GraphEdge))
            {
                return;
            }

            GraphEdge edge = parameter as GraphEdge;

            _viewModel.Edges.Remove(edge);
        }
    }
}
