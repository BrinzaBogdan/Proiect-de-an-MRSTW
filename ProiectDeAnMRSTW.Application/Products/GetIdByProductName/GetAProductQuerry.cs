using MediatR;
using ProiectDeAnMRSTW.Application.Abstractions.Messaging;
using ProiectDeAnMRSTW.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Products.GetIdByProductName
{
    public sealed record GetAProductQuerry(string ProductName) : IQuerry<Guid>;
}