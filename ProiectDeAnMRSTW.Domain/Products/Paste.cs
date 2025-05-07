using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products.Events;

namespace ProiectDeAnMRSTW.Domain.Products
{
	public class Paste : Aliment
	{
        private Paste(Guid id,string category,string name,string pageLink) 
            : base(id,category,name,pageLink)
        { }
        public Paste() :base()
        {
            
        }
        public static Paste Create(string category,string name,string pageLink)
        {
            var paste = new Paste(Guid.NewGuid(),category, name, pageLink);

            paste.RaiseDomainEvent(new AlimentCretedDomainEvent(paste.Id));

            return paste;
        }
    }
}
