using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products.Events;

namespace ProiectDeAnMRSTW.Domain.Products
{
    public class Dulciuri : Aliment
    {
        private Dulciuri(Guid id, string category, string name, string pageLink)
            : base(id, category, name, pageLink)
        { }
        public Dulciuri() :base()
        {
            
        }
        public static Dulciuri Create(string category, string name, string pageLink)
        {
            var dulciuri = new Dulciuri(Guid.NewGuid(), category, name, pageLink);

            dulciuri.RaiseDomainEvent(new AlimentCretedDomainEvent(dulciuri.Id));

            return dulciuri;
        }
    }
}
