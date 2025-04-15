using ProyectoFinal.Commands.BinarySearchTrees;
using ProyectoFinal.Commands.LinkedLists;
using ProyectoFinal.Commands.Queues;
using ProyectoFinal.Commands.Stacks;
using ProyectoFinal.Models.LinkedLists;
using System;
using System.Windows.Input;

namespace ProyectoFinal.ViewModels.LinkedLists
{
    public class LinkedListViewModel
    {
        public MainViewModel MainVm { get; set; }

        private LinkListWithActions<UserTask> _userTasks;

        public LinkListWithActions<UserTask> UserTasks => _userTasks;

        /// <summary>
        /// Comando para abrir nueva tarea.
        /// </summary>
        public ICommand OpenNewTask { get; set; }

        /// <summary>
        /// Comando para editar una tarea.
        /// </summary>
        public ICommand OpenEditTask { get; set; }

        /// <summary>
        /// Comando para eliminar una tarea.
        /// </summary>
        public ICommand RemoveTask { get; set; }

        /// <summary>
        /// Comando para abrir cola de prioridad.
        /// </summary>
        public ICommand OpenQueue { get; set; }

        /// <summary>
        /// Comando para abrir ABB.
        /// </summary>
        public ICommand OpenBST { get; set; }

        /// <summary>
        /// Comando para deshacer tarea.
        /// </summary>
        public ICommand Undo { get; set; }

        /// <summary>
        /// Caomando para rehacer tarea.
        /// </summary>
        public ICommand Redo { get; set; }

        public LinkedListViewModel(MainViewModel mainVm)
        {
            MainVm = mainVm;

            DateTime today = DateTime.Now;

            _userTasks = new LinkListWithActions<UserTask>();

            // Datos dummy.
            UserTask task = new UserTask("Problema urgente", "Description", today.AddDays(1), Enums.LinkedLists.TaskPriorityType.Urgent, Enums.LinkedLists.TaskStatusType.Pending);
            UserTask taskB = new UserTask("Problema alto", "Description", today.AddDays(2), Enums.LinkedLists.TaskPriorityType.High, Enums.LinkedLists.TaskStatusType.Pending);
            UserTask taskC = new UserTask("Problema medio", "Description", today.AddDays(1), Enums.LinkedLists.TaskPriorityType.Medium, Enums.LinkedLists.TaskStatusType.Pending);
            UserTask taskD = new UserTask("Probelam bajo", "Description", today.AddDays(4), Enums.LinkedLists.TaskPriorityType.Low, Enums.LinkedLists.TaskStatusType.Pending);

            UserTasks.Add(task);
            UserTasks.Add(taskB);
            UserTasks.Add(taskC);
            UserTasks.Add(taskD);

            OpenNewTask = new OpenNewTaskCmd(this);
            OpenEditTask = new OpenEditTaskCmd(this);
            RemoveTask = new RemoveTaskCmd(this);
            OpenQueue = new OpenPriorityQueueCmd(this);
            OpenBST = new OpenBSTCmd(this);
            Undo = new UndoCmd(this);
            Redo = new RedoCmd(this);
        }
    }
}
