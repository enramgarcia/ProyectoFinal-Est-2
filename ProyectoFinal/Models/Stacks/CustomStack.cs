using System;

namespace ProyectoFinal.Models.Stacks
{
    /// <summary>
    /// Clase del manejo de la pila, para evitar problemas con el nombre de la clase Stack que ya viene con C# la clase la nombraremos CustomStack.
    /// </summary>
    public class CustomStack<T>
    {
        /// <summary>
        /// Tope de la pila, lo dejamos privado para evitar manipularlo externamente.
        /// </summary>
        private StackNode<T> _top;

        /// <summary>
        /// Encapsulador de cantidad de nodos dentro de la pila.
        /// </summary>
        private int _count;

        /// <summary>
        /// Cantidad de nodos dentro de la pila.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Indicador que la pila se encuentra vacía.
        /// </summary>
        public bool IsEmpty => _top == null;

        /// <summary>
        /// Apilar un nuevo nodo dentro de la pila.
        /// </summary>
        public void Push(T value)
        {
            // Creamos el nuevo nodo, cuyo nodo siguiente es el tope actual.
            StackNode<T> newNode = new StackNode<T>(value, _top);

            // Actualizamos el tope de la pila y la cantidad de nodos.
            _top = newNode;
            _count++;
        }

        /// <summary>
        /// Desapilar un nodo dentro de la pila.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Pila vacía.");
            }

            // Guardamos el nodo tope para retornarlo.
            T node = _top.Value;
            // Actualizamos el nodo tope con el siguiente nodo.
            _top = _top.Next;
            // Reducimos la cantidad de nodos por 1.
            _count--;

            return node;
        }

        /// <summary>
        /// Verificar el nodo tope de la pila sin eliminarlo.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Pila vacía.");
            }

            return _top.Value;
        }

        /// <summary>
        /// Limpiar la pila por completo.
        /// </summary>
        public void Clear()
        {
            _top = null;
            _count = 0;
        }
    }
}
