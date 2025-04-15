using ProyectoFinal.Models.Graphs;
using ProyectoFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal.Commands.Graphs
{
    /// <summary>
    /// Clase del comando para eliminar un nodo al grafo.
    /// </summary>
    public class DeleteLocationCmd : BaseCommand
    {
        /// <summary>
        /// Variable del ViewModel desde el cual se llama el comando para poder acceder a las variables del mismo.
        /// </summary>
        private GraphViewModel _viewModel;

        public DeleteLocationCmd(GraphViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// Ejecución del comando de eliminar Nodo del Grafo.
        /// </summary>
        /// <param name="parameter"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(GraphNode))
            {
                return;
            }

            GraphNode location = parameter as GraphNode;

            List<GraphEdge> edges = _viewModel.Edges.Where(x => x.From.Id == location.Id || x.To.Id == location.Id).ToList();
        
            // No se encuentran aristas, se puede eliminar de forma segura.
            if (edges.Count == 0)
            {
                _viewModel.Nodes.Remove(location);
                return;
            }

            for (int i = _viewModel.Edges.Count - 1; i >= 0; i--)
            {
                int index = edges.FindIndex(x => x == _viewModel.Edges[i]);

                // Existe la arista, por ende se debe de eliminar del listado.
                if (index != -1)
                {
                    _viewModel.Edges.RemoveAt(i);
                }
            }

            _viewModel.Nodes.Remove(location);
        }
    }
}
