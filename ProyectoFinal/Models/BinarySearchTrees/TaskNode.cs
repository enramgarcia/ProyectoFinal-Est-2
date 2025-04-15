using ProyectoFinal.Models.LinkedLists;

namespace ProyectoFinal.Models.BinarySearchTrees
{
    public class TaskNode
    {
        /// <summary>
        /// Valor del Nodo.
        /// </summary>
        public UserTask Task { get; set; }

        /// <summary>
        /// Nodo de izquierdo.
        /// </summary>
        public TaskNode Left { get; set; }

        /// <summary>
        /// Nodo derecho.
        /// </summary>
        public TaskNode Right { get; set; }

        /// <summary>
        /// Constructor iniciando el valor del Nodo y los Nodo derecha izquieda se inicializan nulos.
        /// </summary>
        /// <param name="task"></param>
        public TaskNode(UserTask task)
        {
            Task = task;
            Left = null;
            Right = null;
        }
    }
}
