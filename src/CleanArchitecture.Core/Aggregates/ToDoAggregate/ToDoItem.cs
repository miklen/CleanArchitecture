using CleanArchitecture.SharedKernel;

namespace CleanArchitecture.Core.Aggregates.ToDoAggregate
{
    public class ToDoItem : BaseEntity<int>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public bool IsDone { get; private set; }

        public void MarkComplete()
        {
            IsDone = true;
            Events.Add(new ToDoItemCompletedEvent(this));
        }
    }
}
