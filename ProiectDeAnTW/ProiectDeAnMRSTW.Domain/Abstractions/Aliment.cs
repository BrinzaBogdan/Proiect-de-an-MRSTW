using ProiectDeAnMRSTW.Domain.Products.Events;
using System.ComponentModel.DataAnnotations;

namespace ProiectDeAnMRSTW.Domain.Abstractions
{
    public class Aliment
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProductPageLink { get; set; }
        protected Aliment(Guid id, string category, string name, string pageLink)
        {
            Id = id;
            Category = category;
            Name = name;
            ProductPageLink = pageLink;
        }
        public Aliment(Guid id)
        { Id = id; }
        public Aliment() { }

        public static Aliment Create(Guid id, string category, string name, string pageLink)
        {
            var aliment = new Aliment(id, category, name, pageLink);
            aliment.RaiseDomainEvent(new AlimentCretedDomainEvent(aliment.Id));

            return aliment;
        }

        public IReadOnlyList<IDomainEvent> GetDomainEvents() // luam tote evenimentele
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()// le stergem e toate
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent) // facem un eveniment cand se intampla ceva
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
