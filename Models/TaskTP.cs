namespace TP_M2I_DOTNET.Models;

public enum TaskStatus
{
    todo,
    in_progress,
    done
}

public enum TaskPriority
{
    low,
    medium,
    high
}

public class TaskTP
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DueDate { get; set; }

    public TaskTP(int id, string title, string description, TaskStatus status, TaskPriority priority, DateTime createdAt, DateTime updatedAt, DateTime dueDate)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DueDate = dueDate;
    }

    public TaskTP()
    {
    }
}
