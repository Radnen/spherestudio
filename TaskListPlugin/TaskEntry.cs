namespace SphereStudio.Plugins
{
    enum TaskPriority { High, Medium, Low, None };
    enum TaskType { Addition, Art, Bug, Feature, Gameplay, Other, UI };

    internal class TaskEntry
    {
        public TaskEntry(string name = "")
        {
            Name = name;
            Priority = TaskPriority.None;
            Type = TaskType.Other;
        }

        public TaskEntry(string name, TaskPriority priority)
            : this(name)
        {
            Priority = priority;
            Type = TaskType.Other;
        }

        public TaskEntry(string name, TaskPriority priority, TaskType type)
            : this(name, priority)
        {
            Type = type;
        }

        public string Name { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskType Type { get; set; }
        public bool IsFinished { get; set; }

        public void IncreasePriority()
        {
            int p = (int)Priority;
            if (p - 1 >= 0)
                p--;
            Priority = (TaskPriority)p;
        }

        public void DecreasePriority()
        {
            int p = (int)Priority;
            if (p + 1 <= 3)
                p++;
            Priority = (TaskPriority)p;
        }
    }
}
