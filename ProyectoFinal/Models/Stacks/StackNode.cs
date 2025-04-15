namespace ProyectoFinal.Models.Stacks
{
    /// <summary>
    /// Clase de Nodo de una Pila.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StackNode<T>
    {
        /// <summary>
        /// Valor del nodo.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Siguiente nodo dentro de la pila.
        /// </summary>
        public StackNode<T> Next { get; set; }

        /// <summary>
        /// Constructor de la pila.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="next"></param>
        public StackNode(T value, StackNode<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
