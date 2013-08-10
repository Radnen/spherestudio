namespace TaskListPlugin
{
    enum TaskPriority { Hi, Med, Lo, None };
    enum TaskType { Addition, Art, Bug, Feature, Gameplay, Other, UI };

    internal class Task
    {
        public Task() : this("") { }

        public Task(string name)
        {
            Name = name;
            Priority = TaskPriority.None;
            Type = TaskType.Other;
        }

        public Task(string name, TaskPriority priority)
            : this(name)
        {
            Priority = priority;
            Type = TaskType.Other;
        }

        public Task(string name, TaskPriority priority, TaskType type)
            : this(name, priority)
        {
            Type = type;
        }

        public string Name { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskType Type { get; set; }
        public bool Finished { get; set; }

        public void IncreasePriority()
        {
            int p = (int)Priority;
            if (p - 1 >= 0) p--;
            Priority = (TaskPriority)p;
        }

        public void DecreasePriority()
        {
            int p = (int)Priority;
            if (p + 1 <= 3) p++;
            Priority = (TaskPriority)p;
        }
    }
}
