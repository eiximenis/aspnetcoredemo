using MediatR;

namespace TodoList.Domain
{
    public abstract class DomainEvent : INotification
    {
        public DateTime Time { get; }
        public string Name { get; }

        public DomainEvent(string name)
        {
            Name = name;
            Time = DateTime.UtcNow;
        }
    }
}