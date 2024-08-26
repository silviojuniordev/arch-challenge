using Financial.Entries.Domain.Support.Messages;

namespace Financial.Entries.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity() 
        { 
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        private List<Event> _notificacoes;
        public IReadOnlyCollection<Event>? Notificacoes => _notificacoes?.AsReadOnly();

        public void AddEvent(Event evento)
        {
            _notificacoes = _notificacoes ?? new List<Event>();
            _notificacoes.Add(evento);
        }

        public void RemoveEvent(Event eventItem)
        {
            _notificacoes?.Remove(eventItem);
        }

        public void CleanEvent()
        {
            _notificacoes?.Clear();
        }
    }
}
