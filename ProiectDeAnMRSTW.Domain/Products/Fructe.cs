using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products.Events;

namespace ProiectDeAnMRSTW.Domain.Products
{
    public class Fructe : Aliment
	{
        private Fructe(Guid id,string category,string name,string pageLink) 
            : base(id,category,name,pageLink)
        { }
        public Fructe() :base()
        {
            
        }
        public static Fructe Create(string category,string name,string pageLink)
        {
            var fructe = new Fructe(Guid.NewGuid(),category, name, pageLink);

            fructe.RaiseDomainEvent(new AlimentCretedDomainEvent(fructe.Id));

            return fructe;
        }
    }
}
