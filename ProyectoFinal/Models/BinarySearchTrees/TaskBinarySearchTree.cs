using ProyectoFinal.Models.LinkedLists;
using System.Collections.Generic;

namespace ProyectoFinal.Models.BinarySearchTrees
{
    public class TaskBinarySearchTree
    {
        public TaskNode Root { get; private set; }

        /// <summary>
        /// Insertar una tarea al arbol.
        /// </summary>
        /// <param name="task"></param>
        public void Insert(UserTask task)
        {
            Root = InsertRecursive(Root, task);
        }

        /// <summary>
        /// Se ingresa un nodo de forma recursiva hasta llegar al nodo nulo. 
        /// Se implementa el arbol binario de búsqueda en base al peso de la tarea;
        /// si el peso de la tarea es menor que el del nodo se ingresa a la izquierda,
        /// de lo contrario se ingresa a la derecha.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        private TaskNode InsertRecursive(TaskNode node, UserTask task)
        {
            // Si el nodo es nulo se inicializa con el nodo a agregar.
            if (node == null)
            {
                return new TaskNode(task);
            }

            // Si el peso de la tarea a agregar es menor que el del nodo, se agrega a la izquierda de forma recursiva.
            if (task.Weight < node.Task.Weight)
            {
                node.Left = InsertRecursive(node.Left, task);
            }
            // Si el peso de la tarea a agregar es mayor que el del nodo, se agrega a la derecha de forma recursiva.
            else
            {
                node.Right = InsertRecursive(node.Right, task);
            }

            return node;
        }

        /// <summary>
        /// Buscar una tarea usando el peso de la misma.
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public TaskNode Search(double weight)
        {
            return SearchRecursive(Root, weight);
        }

        /// <summary>
        /// Buscar una tarea por su peso de forma recursiva.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        private TaskNode SearchRecursive(TaskNode node, double weight)
        {
            /**
             * Retornar el nodo si es nulo (no se encontró el peso) o si la tarea fue encontrada.
             */
            if (node == null || node.Task.Weight == weight)
            {
                return node;
            }

            // Si el peso a buscar es menor del peso de la tarea buscamos en la izquierda.
            if (weight < node.Task.Weight)
            {
                return SearchRecursive(node.Left, weight);
            }

            // Si el peso a buscar es mayor del peso de la tarea buscamos en la derecha.
            return SearchRecursive(node.Right, weight);
        }

        /// <summary>
        /// Generar recorrido inorden.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserTask> InOrder()
        {
            List<UserTask> tasks = new List<UserTask>();

            InOrderRecursive(Root, tasks);

            return tasks;
        }

        /// <summary>
        /// Iterar el árbol de forma recursiva generando una lista con los nodos en orden del recorrido.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="tasks"></param>
        private void InOrderRecursive(TaskNode node, List<UserTask> tasks)
        {
            // Si el nodo actual es nulo, retornamos.
            if (node == null)
            {
                return;
            }

            // Recorremos los nodos de la izquierda.
            InOrderRecursive(node.Left, tasks);
            // Agregamos la tarea a la lista.
            tasks.Add(node.Task);
            // Recorremos los nodos de la derecha.
            InOrderRecursive(node.Right, tasks);
        }

        /// <summary>
        /// Remover un nodo según su peso.
        /// </summary>
        /// <param name="weight"></param>
        public void Remove(double weight)
        {
            Root = RemoveRecursive(Root, weight);
        }

        private TaskNode RemoveRecursive(TaskNode node, double weight)
        {
            if (node == null)
            {
                return node;
            }

            if (weight < node.Task.Weight)
            {
                node.Left = RemoveRecursive(node.Left, weight);
            }
            else if (weight > node.Task.Weight)
            {
                node.Right = RemoveRecursive(node.Right, weight);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }

                UserTask minTask = FindMin(node.Right);
                node.Task = minTask;
                node.Right = RemoveRecursive(node.Right, minTask.Weight);
            }

            return node;
        }

        private UserTask FindMin(TaskNode node)
        {
            UserTask minTask = node.Task;
        
            while (node.Left != null)
            {
                node = node.Left;
                minTask = node.Task;
            }

            return minTask;
        }
    }
}
