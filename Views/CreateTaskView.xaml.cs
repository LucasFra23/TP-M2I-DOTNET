using TP_M2I_DOTNET.ViewModels;

namespace TP_M2I_DOTNET.Views;

public partial class CreateTaskView : ContentPage
{
    public CreateTaskView(TasksViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}