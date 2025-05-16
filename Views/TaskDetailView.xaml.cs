using TP_M2I_DOTNET.Models;

namespace TP_M2I_DOTNET.Views;

[QueryProperty(nameof(Task), "Task")]
public partial class TaskDetailView : ContentPage
{
    public TaskTP Task
    {
        get => BindingContext as TaskTP;
        set => BindingContext = value;
    }

    public TaskDetailView()
    {
        InitializeComponent();
    }
}