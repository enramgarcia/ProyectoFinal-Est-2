namespace ProyectoFinal.Models.Queues
{
    public class PriorityQueueNode<T>
    {
        /// <summary>
        /// Nodo actual.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Peso de prioridad.
        /// </summary>
        public double Priority { get; set; }

        /// <summary>
        /// Siguiente nodo.
        /// </summary>
        public PriorityQueueNode<T> Next { get; set; }

        public PriorityQueueNode(T value, double priority)
        {
            Value = value;
            Priority = priority;
            Next = null;
        }
    }
}
