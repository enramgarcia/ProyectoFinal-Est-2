using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ProyectoFinal.Models.Queues
{
    public class ObservablePriorityQueue<T> : INotifyCollectionChanged, IEnumerable<T>
    {
        private PriorityQueueNode<T> _head;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void Enqueue(T value, double priority)
        {
            PriorityQueueNode<T> newNode = new PriorityQueueNode<T>(value, priority);

            /**
             * Si no existe un nodo cabeza, o la prioridad del nodo es mayor a la prioridad del nodo cabeza actual,
             * agregamos el nuevo nodo en la cabeza.
             */
            if (_head == null || _head.Priority < priority)
            {
                newNode.Next = _head;
                _head = newNode;
                OnCollectionChanged(NotifyCollectionChangedAction.Add, value, 0);
                return;
            }

            PriorityQueueNode<T> current = _head;
            int index = 0;

            /**
             * Iteramos la cola para buscar el punto a insertar el nodo dependiendo de si la prioridad es menor a la del
             * siguiente nodo.
             */
            while (current.Next != null && current.Next.Priority >= priority)
            {
                current = current.Next;
                index++;
            }

            // Insertamos el nodo dentro de la cola.
            newNode.Next = current.Next;
            current.Next = newNode;

            OnCollectionChanged(NotifyCollectionChangedAction.Add, value, index + 1);
        }

        /// <summary>
        /// Función para desencolar, buscamos que el nodo cabeza no sea nulo, de lo contrario arrojamos una excepción,
        /// luego cambiamos el valor de la cabeza con el del siguiente nodo y notificamos que ha cambiado la colección
        /// para actualizar el componente.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Dequeue()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Cola vacía.");
            }

            T value = _head.Value;
            // Cambiamos el valor de la cabeza por el valor del siguiente nodo.
            _head = _head.Next;
            OnCollectionChanged(NotifyCollectionChangedAction.Remove, value, 0);

            return value;
        }

        /// <summary>
        /// Buscamos cual es la cabeza sin la necesidad de eliminar el nodo, en el caso de no existir nodo cabeza arrojamos una excepción.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Peek()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Cola vacía.");
            }

            return _head.Value;
        }

        private void OnCollectionChanged(NotifyCollectionChangedAction action, T value, int index)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, value, index));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            PriorityQueueNode<T> current = _head;

            // Iteramos la cola hasta que el valor del nodo sea nulo.
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
