using ProyectoFinal.Enums.LinkedLists;
using ProyectoFinal.Models.LinkedLists;
using ProyectoFinal.Models.Queues;

namespace ProyectoFinal.ViewModels.Queues
{
    public class UserTaskQueueViewModel : BaseViewModel
    {
        private ObservablePriorityQueue<UserTask> _queue;

        /// <summary>
        /// Cola de prioridad para mostrar en vista.
        /// </summary>
        public ObservablePriorityQueue<UserTask> Queue => _queue;

        public UserTaskQueueViewModel(ObservableLinkedList<UserTask> tasks)
        {
            _queue = new ObservablePriorityQueue<UserTask>();

            foreach (UserTask task in tasks)
            {
                // Ignoramos de la cola las tareas completadas.
                if (task.Status == TaskStatusType.Finished)
                {
                    continue;
                }

                double weight = task.CalculateWeight();
                Queue.Enqueue(task, weight);
            }
        }

    }
}
