using MediatR;
using ProiectDeAnMRSTW.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Abstractions.Messaging
{
    public interface IQuerry<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
