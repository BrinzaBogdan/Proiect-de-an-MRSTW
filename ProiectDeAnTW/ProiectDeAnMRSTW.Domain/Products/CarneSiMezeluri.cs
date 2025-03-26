using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products.Events;
using System.Xml.Linq;

namespace ProiectDeAnMRSTW.Domain.Products
{
    public class CarneSiMezeluri : Aliment
    {
        private CarneSiMezeluri(Guid id, string category, string name, string pageLink)
            : base(id, category, name, pageLink)
        { }
        public CarneSiMezeluri() :base()
        {
            
        }

        public static CarneSiMezeluri Create(string category, string name, string pageLink)
        {
            var Carne = new CarneSiMezeluri(Guid.NewGuid(), category, name, pageLink);

            Carne.RaiseDomainEvent(new AlimentCretedDomainEvent(Carne.Id));

            return Carne;
        }
    }
}
