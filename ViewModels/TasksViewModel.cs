using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_M2I_DOTNET.Api;
using TP_M2I_DOTNET.Models;

namespace TP_M2I_DOTNET.ViewModels
{
    public partial class TasksViewModel : ObservableObject
    {
        private readonly ILogger<TasksViewModel> _logger;
        public ObservableCollection<TaskTP> Tasks { get; set; }
        public ObservableCollection<TaskTP> DisplayedTasks { get; set; }

        public List<Models.TaskStatus?> StatusFilterList { get; } = new() { null, Models.TaskStatus.todo, Models.TaskStatus.in_progress, Models.TaskStatus.done };

        [ObservableProperty]
        private Models.TaskStatus? _selectedStatusFilter;

        public TasksApi TasksApi { get; set; }

        public TasksViewModel(TasksApi tasksApi, ILogger<TasksViewModel> logger)
        {
            Tasks = new();
            DisplayedTasks = new();
            TasksApi = tasksApi;
            _logger = logger;
            _selectedStatusFilter = null;
        }

        public async void LoadTasks()
        {
            try
            {
                var tasksList = await TasksApi.GetTasksAsync();
                if (tasksList != null)
                {
                    Tasks.Clear();
                    foreach (var task in tasksList)
                    {
                        Tasks.Add(task);
                    }
                    _logger.LogInformation("Nombre de palettes de couleurs affichées : {Count}", Tasks.Count);
                    ApplyStatusFilter();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors du chargement des palettes de couleurs");
                Console.WriteLine($"Erreur lors du chargement des palettes de couleurs : {ex.Message}");

                //Fake tasks for test
                Tasks.Clear();
                Tasks.Add(new TaskTP(1, "Task 1", "Description 1", Models.TaskStatus.todo, TaskPriority.high, DateTime.Now, DateTime.Now, DateTime.Now.AddDays(7)));
                Tasks.Add(new TaskTP(2, "Task 2", "Description 2", Models.TaskStatus.in_progress, TaskPriority.medium, DateTime.Now, DateTime.Now, DateTime.Now.AddDays(5)));
                Tasks.Add(new TaskTP(3, "Task 3", "Description 3", Models.TaskStatus.done, TaskPriority.low, DateTime.Now, DateTime.Now, DateTime.Now.AddDays(3)));
                ApplyStatusFilter();
            }
        }

        partial void OnSelectedStatusFilterChanged(Models.TaskStatus? value)
        {
            ApplyStatusFilter();
        }

        private void ApplyStatusFilter()
        {
            if (SelectedStatusFilter == null)
            {
                DisplayedTasks.Clear();
                foreach (var task in Tasks)
                {
                    DisplayedTasks.Add(task);
                }
            }
            else
            {
                DisplayedTasks.Clear();
                foreach (var task in Tasks.Where(t => t.Status == SelectedStatusFilter))
                {
                    DisplayedTasks.Add(task);
                }
            }
            _logger.LogInformation("Nombre de palettes de couleurs affichées : {Count}", DisplayedTasks.Count);
        }
    }
}
