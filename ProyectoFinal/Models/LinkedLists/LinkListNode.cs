namespace ProyectoFinal.Models.LinkedLists
{
    /// <summary>
    /// Clase de definición de la lista enlazada.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkListNode<T>
    {
        /// <summary>
        /// Valor del nodo actual, usamos valor plantilla generico para aceptar cualquier tipo de dato.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Siguiente nodo dentro de la lista enlazada.
        /// </summary>
        public LinkListNode<T> Next { get; set; }

        /// <summary>
        /// Constructor del nodo.
        /// </summary>
        /// <param name="value"></param>
        public LinkListNode(T value)
        {
            Value = value;
        }
    }
}
