using TP_M2I_DOTNET.Views;

namespace TP_M2I_DOTNET
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TaskDetailView), typeof(TaskDetailView));
            Routing.RegisterRoute("CreateTaskView", typeof(CreateTaskView));
        }
    }
}
