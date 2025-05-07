using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products.Events;

namespace ProiectDeAnMRSTW.Domain.Products
{
	public class Peste : Aliment
	{
        private Peste(Guid id,string category,string name,string pageLink) 
            : base(id,category,name,pageLink)
        { }
        public Peste() :base()
        {
            
        }
        public static Peste Create(string category,string name,string pageLink)
        {
            var peste = new Peste(Guid.NewGuid(),category, name, pageLink);

            peste.RaiseDomainEvent(new AlimentCretedDomainEvent(peste.Id));

            return peste;
        }
    }
}
