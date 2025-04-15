using ProyectoFinal.Commands.LinkedLists;
using ProyectoFinal.Enums.LinkedLists;
using ProyectoFinal.Models.LinkedLists;
using ProyectoFinal.Models.Misc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ProyectoFinal.ViewModels.LinkedLists
{
    public class UserTaskViewModel : BaseViewModel
    {
        public Window Owner { get; set; }

        private ObservableCollection<EnumList<TaskPriorityType>> _priorities;

        public IList<EnumList<TaskPriorityType>> Priorities => _priorities;

        private ObservableCollection<EnumList<TaskStatusType>> _statusList;

        public IList<EnumList<TaskStatusType>> StatusList => _statusList;

        private TaskPriorityType _priority;

        public TaskPriorityType Priority
        {
            get => _priority;
            set
            {
                _priority = value;
                OnPropertyChanged(nameof(Priority));
            }
        }

        private TaskStatusType _status;

        public TaskStatusType Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private Guid _id;

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

        public ICommand Save { get; set; }

        public UserTaskViewModel(Window owner)
        {
            Owner = owner;
            CompletionDate = DateTime.Now;
            InitLists();

            Save = new SaveTaskCmd(this);
        }

        public UserTaskViewModel(Window owner, UserTask task)
        {
            Owner = owner;
            Id = task.Id;
            Title = task.Title;
            Description = task.Description;
            Priority = task.Priority;
            Status = task.Status;
            CompletionDate = task.CompletionDate;

            InitLists();

            Save = new SaveTaskCmd(this);
        }

        /// <summary>
        /// Iniciamos la lista de las prioridades y estados con nombre legibles para facilidad el usuario final.
        /// </summary>
        private void InitLists()
        {
            _priorities = new ObservableCollection<EnumList<TaskPriorityType>>
            {
                new EnumList<TaskPriorityType>(TaskPriorityType.Urgent, "Urgenete"),
                new EnumList<TaskPriorityType>(TaskPriorityType.High, "Alta"),
                new EnumList<TaskPriorityType>(TaskPriorityType.Medium, "Media"),
                new EnumList<TaskPriorityType>(TaskPriorityType.Low, "Baja"),
            };

            _statusList = new ObservableCollection<EnumList<TaskStatusType>>
            {
                new EnumList<TaskStatusType>(TaskStatusType.Pending, "Pendiente"),
                new EnumList<TaskStatusType>(TaskStatusType.Started, "Iniciada"),
                new EnumList<TaskStatusType>(TaskStatusType.Finished, "Completada"),
            };
        }
    }
}
