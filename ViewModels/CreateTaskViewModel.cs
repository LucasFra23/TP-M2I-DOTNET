using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_M2I_DOTNET.Models;

namespace TP_M2I_DOTNET.ViewModels
{
    public partial class CreateTaskViewModel : ObservableObject
    {
        [ObservableProperty] private string title;
        [ObservableProperty] private string description;
        [ObservableProperty] private DateTime dueDate;
        [ObservableProperty] private Models.TaskStatus status;
        [ObservableProperty] private TaskPriority priority;

        [ObservableProperty]
        private List<TaskPriority> priorities = new()
        {
            TaskPriority.low,
            TaskPriority.medium,
            TaskPriority.high
        };

        [ObservableProperty]
        private List<Models.TaskStatus> statuses = new()
        {
            Models.TaskStatus.todo,
            Models.TaskStatus.in_progress,
            Models.TaskStatus.done
        };

        private TasksViewModel _tasksViewModel;

        public CreateTaskViewModel()
        {
        }

        public CreateTaskViewModel(TasksViewModel tasksViewModel)
        {
            _tasksViewModel = tasksViewModel;
        }

        [RelayCommand]
        private async void CreateTask()
        {
            TaskTP taskTP = new TaskTP(1, Title, Description, Status, Priority, DateTime.Now, DateTime.Now, DueDate);
            await _tasksViewModel.AddTask(taskTP);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
