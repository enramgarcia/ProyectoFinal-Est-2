using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ProyectoFinal.Models.LinkedLists
{
    /// <summary>
    /// Clase observable de la lista enlazada, la lógica de agregar, editar y eliminar nodos de la lista se encuentran definidas.
    /// Es importante poder extender las interfaces de INotifyCollectionChanged y IEnumerable para que pueda interactuar con las propiedades del control WPF.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableLinkedList<T> : INotifyCollectionChanged, IEnumerable<T>
    {
        /// <summary>
        /// Cabeza de la lista enlazada.
        /// </summary>
        private LinkListNode<T> _head;

        /// <summary>
        /// Evento de notificación de cambios en la colección para poder interactuar con el control y actualizar los componentes del DataGrid, ItemsControl, etc.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// Agregar un nodo nuevo a la lista enlazada.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            LinkListNode<T> newNode = new LinkListNode<T>(value);

            // Si la cabeza de la lista se encuentra vacía agregamos el nodo al inicio.
            if (_head == null)
            {
                _head = newNode;
                OnCollectionChanged(NotifyCollectionChangedAction.Add, value);
                return;
            }

            LinkListNode<T> current = _head;

            // Iteramos la lista hasta encontrar el fin (nodo Next nulo)
            while (current.Next != null)
            {
                current = current.Next;
            }

            // Actualizamos el fin de la lista agregando el nuevo nodo al final.
            current.Next = newNode;
            OnCollectionChanged(NotifyCollectionChangedAction.Add, value);
        }

        /// <summary>
        /// Insertar un nodo dentro de la lista en una posición especifica, esta función es requerida para poder deshacer la eliminación de un nodo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public void InsertAt(T value, int index)
        {
            LinkListNode<T> newNode = new LinkListNode<T>(value);

            // Si el indice es menor o igual a 0 o la cabeza es nula, agregamos el valor en la cabeza.
            if (index <= 0 || _head == null)
            {
                newNode.Next = _head;
                _head = newNode;

                OnCollectionChanged(NotifyCollectionChangedAction.Add, value);
                return;
            }

            LinkListNode<T> current = _head;
            int currentIndex = 0;

            // Iteramos hasta el fin de la lista enlazada o hasta llegar al indice - 1 para insertar el registro.
            while (current != null && currentIndex < index - 1)
            {
                current = current.Next;
                currentIndex++;
            }

            // En el caso que el indice exceda el tamaño de la lista insertamos el nodo al final.
            if (current == null)
            {
                Add(value);
                return;
            }

            // Reemplazamos el nodo actual con el nuevo nodo, efectivamente insertando el nodo devuelta.
            newNode.Next = current.Next;
            current.Next = newNode;

            OnCollectionChanged(NotifyCollectionChangedAction.Replace, value, index);
        }

        /// <summary>
        /// Eliminar un nodo de la lista iterando dentro de la lista enlazada hasta encontrarlo y reemplazamos el nodo.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            // Iniciamos el nodo actual como la cabeza y el nodo previo debe de ser nulo.
            LinkListNode<T> current = _head;
            LinkListNode<T> previous = null;

            int index = 0;

            // Iteramos la lista mientras el nodo actual no sea nulo.
            while (current != null)
            {
                // Si el nodo actual no es el nodo a eliminar continuamos iterando.
                if (!current.Value.Equals(value))
                {
                    // El nodo previo lo actualizamos al nodo actual y el nodo actual lo actualizamos al siguiente nodo.
                    previous = current;
                    current = current.Next;
                    index++;
                    continue;
                }

                // Si el nodo previo es nulo, significa que el nodo a eliminar es la cabeza, la eliminamos y la cabeza se convierte en el siguiente nodo.
                if (previous == null)
                {
                    _head = current.Next;
                }
                // Eliminamos el nodo actual convirtiendo el siguiente nodo del nodo previo al siguiente nodo del nodo actual.
                else
                {
                    previous.Next = current.Next;
                }

                OnCollectionChanged(NotifyCollectionChangedAction.Remove, value, index);

                return true;
            }

            // No se encontró el nodo a eliminar.
            return false;
        }

        /// <summary>
        /// Editar un nodo dentro de la lista, iteramos la lista hasta encontrar el nodo a actualizar y reemplazamos su valor por uno nuevo.
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public bool Edit(T oldValue, T newValue)
        {
            // Iniciamos la búsqueda del nodo en la cabeza.
            LinkListNode<T> current = _head;
            int index = 0;

            // Iteramos la lista mientras el nodo actual no sea nulo.
            while (current != null)
            {
                // El valor del nodo actual no es igual al valor del nodo a actualizar, así que continuamos.
                if (!current.Value.Equals(oldValue))
                {
                    current = current.Next;
                    index++;
                    continue;
                }

                T oldNode = current.Value;
                // Encontramos el nodo, lo actualizamos y notificamos que la colección ha cambiado con un reemplazo.
                current.Value = newValue;
                OnCollectionChanged(NotifyCollectionChangedAction.Replace, newValue, oldNode, index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Invocar el evento de cambio de la colección para notificar al componente.
        /// </summary>
        /// <param name="value"></param>
        private void OnCollectionChanged(NotifyCollectionChangedAction action, T value)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, value));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        private void OnCollectionChanged(NotifyCollectionChangedAction action, T value, int index)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, value, index));
        }

        /// <summary>
        /// Invocar el evento de cambio de la colección para notificar al componente.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldValue"></param>
        /// <param name="index"></param>
        private void OnCollectionChanged(NotifyCollectionChangedAction action, T value, T oldValue, int index)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, value, oldValue, index));
        }

        /// <summary>
        /// Enumeramos la lista enlazada para poder actualizar los registros del componente WPF (DataGrid, ItemsSource, etc.).
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            LinkListNode<T> current = _head;

            // Iteramos la lista hasta encontrar que el nodo siguiente es nulo.
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Enumeramos la lista enlazada para poder actualizar los registros del componente WPF (DataGrid, ItemsSource, etc.).
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
