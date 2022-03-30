using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain
{
    public class BaseEntity
    {
        private readonly List<DomainEvent> _events;


        public BaseEntity()
        {
            _events = new List<DomainEvent>();
        }

        public IEnumerable<DomainEvent> Events() => _events;
        public void ClearEvents() => _events.Clear();
        public int Id { get; set; }
        protected void AddEvent(DomainEvent evt) => _events.Add(evt);

        

    }
}
