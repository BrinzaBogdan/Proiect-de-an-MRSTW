using ProiectDeAnMRSTW.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Domain.Products.Events;
//{
//    internal class AlimentCretedDomainEvent
//    {
//    }
//}

public sealed record AlimentCretedDomainEvent(Guid id) : IDomainEvent;