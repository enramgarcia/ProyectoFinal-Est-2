using ProyectoFinal.Enums.LinkedLists;
using ProyectoFinal.Models.Stacks;

namespace ProyectoFinal.Models.LinkedLists
{
    /// <summary>
    /// Clase para poder manipular la lista enlazada y guardar las acciones ejecutadas sobre la misma para poder hacer uso de una pilo de deshacer y rehacer acciones.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkListWithActions<T>
    {
        /// <summary>
        /// Colección observable de la lista enlazada para insertar, eliminar y editar tareas y poder actualizar los controles.
        /// </summary>
        public ObservableLinkedList<T> LinkList { get; private set; } = new ObservableLinkedList<T>();

        /// <summary>
        /// Pila de acciones para deshacer en el estado actual del programa.
        /// </summary>
        private CustomStack<LinkListAction<T>> undoStack = new CustomStack<LinkListAction<T>>();

        /// <summary>
        /// Pila de acciones para rehacer en el estado actual del programa.
        /// </summary>
        private CustomStack<LinkListAction<T>> redoStack = new CustomStack<LinkListAction<T>>();

        /// <summary>
        /// Buscar el indice del valor dentro de la lista enlazada para poder ejecutar una acción dentro de la misma.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int GetIndex(T value)
        {
            int index = 0;

            foreach (T item in LinkList)
            {
                // Encontramos el valor en el listado, salimos del ciclo.
                if (item.Equals(value))
                {
                    break;
                }

                index++;
            }

            return index;
        }

        /// <summary>
        /// Agregar un registro a la lista enlazada y agregar acción a la pila de deshacer.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            LinkList.Add(value);

            int index = GetIndex(value);

            // Registramos en la pila el registro agregado a la lista enlazada.
            undoStack.Push(new LinkListAction<T>
            {
                Action = LinkListActionType.Add,
                NewValue = value,
                Index = index,
            });

            // Limpiamos la pila de rehacer.
            redoStack.Clear();
        }

        /// <summary>
        /// Editar un registro en la lista enlazada y agregar acción a la pila de deshacer.
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public void Edit(T oldValue, T newValue)
        {
            // Retiramos el index del valor a editar para guardarlo.
            int index = GetIndex(oldValue);

            bool edited = LinkList.Edit(oldValue, newValue);

            // No se pudo editar por algún motivo, no podemos agregar a la pila.
            if (!edited)
            {
                return;
            }

            // Agregamos la acción a la pila de rehacer.
            undoStack.Push(new LinkListAction<T>
            {
                Action = LinkListActionType.Edit,
                OldValue = oldValue,
                NewValue = newValue,
                Index = index,
            });

            // Limpiamos la pila de rehacer.
            redoStack.Clear();
        }

        /// <summary>
        /// Eliminar un registro de la lista enlazada y agregar acción a la pila de deshacer.
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            int index = GetIndex(value);

            bool removed = LinkList.Remove(value);

            // No se pudo eliminar por algún motivo, no podemos agregar a la pila.
            if (!removed)
            {
                return;
            }

            // Agregamos la acción a la pila de rehacer.
            undoStack.Push(new LinkListAction<T>
            {
                Action = LinkListActionType.Remove,
                OldValue = value,
                Index = index,
            });

            // Limpiamos la pila de rehacer.
            redoStack.Clear();
        }

        /// <summary>
        /// Deshacer una acción en la lista enlazada.
        /// </summary>
        public void Undo()
        {
            // La pila se encuentra vacía, no se puede deshacer.
            if (undoStack.Count == 0)
            {
                return;
            }

            // Desapilamos la acción para poder regresar al estado previo a la misma.
            LinkListAction<T> action = undoStack.Pop();
        
            switch (action.Action)
            {
                // Cuando se agrega una acción, al deshacer debemos eliminarla.
                case LinkListActionType.Add:
                    LinkList.Remove(action.NewValue);
                    break;

                // Cuando editamos una acción, debemos revertir al valor viejo.
                case LinkListActionType.Edit:
                    LinkList.Edit(action.NewValue, action.OldValue);
                    break;

                // Cuando eliminamos una acción, debemos agregar el valor en el indice original.
                case LinkListActionType.Remove:
                    LinkList.InsertAt(action.OldValue, action.Index);
                    break;
            }

            // Apilamos la acción en la pila de rehacer.
            redoStack.Push(action);
        }

        /// <summary>
        /// Rehacer una acción en la lista enlazada.
        /// </summary>
        public void Redo()
        {
            if (redoStack.Count == 0)
            {
                return;
            }

            // Desapilamos la acción para poder rehacer la acción.
            LinkListAction<T> action = redoStack.Pop();

            switch (action.Action)
            {
                // Agregamos el valor nuevamente.
                case LinkListActionType.Add:
                    LinkList.Add(action.NewValue);
                    break;

                // Editamos el valor nuevamente.
                case LinkListActionType.Edit:
                    LinkList.Edit(action.OldValue, action.NewValue);
                    break;

                // Eliminamos el valor nuevamente.
                case LinkListActionType.Remove:
                    LinkList.Remove(action.OldValue);
                    break;
            }

            // Apilamos la acción en la pila de deshacer.
            undoStack.Push(action);
        }
    }
}
