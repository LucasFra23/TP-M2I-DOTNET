using TP_M2I_DOTNET.ViewModels;

namespace TP_M2I_DOTNET.Views;

public partial class TasksView : ContentPage
{
    TasksViewModel _viewModel;

    public TasksView(TasksViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = _viewModel;
        InitializeComponent();
    }

    private void OnAppear(object sender, EventArgs e)
    {
        _viewModel.LoadTasks();
    }
}