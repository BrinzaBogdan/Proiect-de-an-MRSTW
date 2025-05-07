using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products.Events;

namespace ProiectDeAnMRSTW.Domain.Products
{
	public class Legume : Aliment
	{
        private Legume(Guid id,string category,string name,string pageLink) 
            : base(id,category,name,pageLink)
        { }
        public Legume() :base()
        {
            
        }
        public static Legume Create(string category,string name,string pageLink)
        {
            var legume = new Legume(Guid.NewGuid(),category, name, pageLink);

            legume.RaiseDomainEvent(new AlimentCretedDomainEvent(legume.Id));

            return legume;
        }
    }
}
