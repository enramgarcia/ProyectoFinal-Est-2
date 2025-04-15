using ProyectoFinal.Enums.LinkedLists;
using ProyectoFinal.ViewModels;
using System;
using System.Windows.Media;

namespace ProyectoFinal.Models.LinkedLists
{
    public class UserTask : BaseViewModel
    {
        private Guid _id;

        /// <summary>
        /// ID único de la tarea, se utiliza un GUID para evitar colisión de IDs.
        /// </summary>
        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _title;

        /// <summary>
        /// Titulo de la tarea.
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _description;

        /// <summary>
        /// Descripción de la tarea.
        /// </summary>
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private DateTime _completionDate;

        /// <summary>
        /// Fecha estimada para completar la tarea.
        /// </summary>
        public DateTime CompletionDate
        {
            get => _completionDate;
            set
            {
                _completionDate = value;
                OnPropertyChanged(nameof(CompletionDate));
            }
        }

        private TaskPriorityType _priority;

        /// <summary>
        /// Nivel de prioridad de la tarea.
        /// </summary>
        public TaskPriorityType Priority
        {
            get => _priority;
            set
            {
                _priority = value;
                OnPropertyChanged(nameof(Priority));
                UpdatePriorityInfo(value);
            }
        }

        private SolidColorBrush _priorityBg;

        /// <summary>
        /// Color de fondo para icono de la prioridad.
        /// </summary>
        public SolidColorBrush PriorityBg
        {
            get => _priorityBg;
            set
            {
                _priorityBg = value;
                OnPropertyChanged(nameof(PriorityBg));
            }
        }

        private string _priorityDescription;

        /// <summary>
        /// Descripción de la prioridad para mostrar en componente.
        /// </summary>
        public string PriorityDescription
        {
            get => _priorityDescription;
            set
            {
                _priorityDescription = value;
                OnPropertyChanged(nameof(PriorityDescription));
            }
        }

        private TaskStatusType _status;

        /// <summary>
        /// Estado de la tarea.
        /// </summary>
        public TaskStatusType Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
                UpdateStatusInfo(value);
            }
        }

        private SolidColorBrush _statusBg;

        /// <summary>
        /// Color de fondo del estado.
        /// </summary>
        public SolidColorBrush StatusBg
        {
            get => _statusBg;
            set
            {
                _statusBg = value;
                OnPropertyChanged(nameof(StatusBg));
            }
        }

        private string _statusDescription;

        /// <summary>
        /// Descrpción del estado de la tarea.
        /// </summary>
        public string StatusDescription
        {
            get => _statusDescription;
            set
            {
                _statusDescription = value;
                OnPropertyChanged(nameof(StatusDescription));
            }
        }

        private double _weight;

        /// <summary>
        /// Peso de la tarea, es visible en la cola como informativo.
        /// </summary>
        public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        /// <summary>
        /// Iniciamos el constructor para poder editar una tarea.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="completionDate"></param>
        /// <param name="priority"></param>
        /// <param name="status"></param>
        public UserTask(
            Guid id, 
            string title,
            string description,
            DateTime completionDate,
            TaskPriorityType priority,
            TaskStatusType status)
        {
            Id = id;
            Title = title;
            Description = description;
            CompletionDate = completionDate;
            Priority = priority;
            Status = status;
        }

        /// <summary>
        /// Iniciamos el constructor para poder crear una tarea.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="completionDate"></param>
        /// <param name="priority"></param>
        /// <param name="status"></param>
        public UserTask(
            string title,
            string description,
            DateTime completionDate,
            TaskPriorityType priority,
            TaskStatusType status)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            CompletionDate = completionDate;
            Priority = priority;
            Status = status;
        }

        /// <summary>
        /// Calcular el peso de la prioridad de la cola, usando como factoras la prioridad, estado y fechas para completar.
        /// 
        /// La formula matemática para calcular el peso de una tarea es la siguiente:
        /// w = pf + sf + ds/(dr +1)
        /// W = Peso
        /// PF = Factor de Prioridad, el cual equivale al nivel de prioridad (enum) convertido a entero múltiplicado por 10.
        /// SF = Factor del estado, el cual equivale a 5 para estado pendiente y 0 para cualquier otro estado.
        /// DS = Escala de fecha, el cual equivale a 100.
        /// DR = Fechas restantes, el cual equivale a la cantidad de días para completar la tarea al día de hoy,
        ///      si el día de hoy es posterior a la fecha de entrega el factor es 0, por esto sumamos por 1 para evitar dividir entre 0.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public double CalculateWeight()
        {
            double daysRemaining = (CompletionDate - DateTime.Now).TotalDays;

            // Si la tarea ya venció entonces cambiamos los días faltantes a 0.
            if (daysRemaining < 0)
            {
                daysRemaining = 0;
            }

            // El factor de prioridad es el número del enum múltiplicado por 10.
            double priorityFactor = (int)Priority * 10;

            // El factor por estado es de 5 para tareas pendientes y 0 para tareas en progreso.
            double statusFactor = (Status == TaskStatusType.Pending) ? 5 : 0;

            // El factor de las fechas para completar es de 100 / días restantes + 1, sumamos 1 para evitar dividir entre 0.
            double dateFactor = 100 / (daysRemaining + 1);

            // El peso total del la prioridad de cola es la suma de los factoras de prioridad, estado y fecha.
            double weight = priorityFactor + statusFactor + dateFactor;

            Weight = weight;

            return weight;
        }

        /// <summary>
        /// Actualizar los colores del icono de la prioridad y el texto de la prioridad.
        /// </summary>
        /// <param name="value"></param>
        private void UpdatePriorityInfo(TaskPriorityType value)
        {
            switch (value)
            {
                case TaskPriorityType.Urgent:
                    PriorityBg = ConvertHex("#9b1f29");
                    PriorityDescription = "Urgente";
                    break;

                case TaskPriorityType.High:
                    PriorityBg = ConvertHex("#e84b23");
                    PriorityDescription = "Alta";
                    break;

                case TaskPriorityType.Medium:
                    PriorityBg = ConvertHex("#fac61b");
                    PriorityDescription = "Media";
                    break;

                default:
                    PriorityBg = ConvertHex("#082c60");
                    PriorityDescription = "Baja";
                    break;
            }
        }

        /// <summary>
        /// Actualizar los colores del icono del estado y el texto del estado.
        /// </summary>
        /// <param name="value"></param>
        private void UpdateStatusInfo(TaskStatusType value)
        {
            switch (value)
            {
                case TaskStatusType.Pending:
                    StatusBg = ConvertHex("#cf2a27");
                    StatusDescription = "Pendiente";
                    break;

                case TaskStatusType.Started:
                    StatusBg = ConvertHex("#597daa");
                    StatusDescription = "Iniciada";
                    break;

                case TaskStatusType.Finished:
                    StatusBg = ConvertHex("#009e10");
                    StatusDescription = "Completada";
                    break;
            }
        }

        /// <summary>
        /// Convertir un Color Hexadecimal a un SolidColorBrush para renderizar en el control.
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        private SolidColorBrush ConvertHex(string hex)
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex));
        }
    }
}
