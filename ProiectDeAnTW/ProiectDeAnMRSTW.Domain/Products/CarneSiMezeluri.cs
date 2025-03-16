using ProiectDeAnMRSTW.Domain.Products.Events;

namespace ProiectDeAnTW.Models
{
	public class CarneSiMezeluri : Aliment
	{
        private CarneSiMezeluri(Guid id) 
            : base(id)
        { }

        public static CarneSiMezeluri Create()
        {
            var Carne = new CarneSiMezeluri(Guid.NewGuid());

            Carne.RaiseDomainEvent(new AlimentCretedDomainEvent(Carne.Id));

            return Carne;
        }
    }
}
