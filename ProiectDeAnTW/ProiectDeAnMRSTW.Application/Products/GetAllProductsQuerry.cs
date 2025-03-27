using ProiectDeAnMRSTW.Application.Abstractions.Messaging;
using ProiectDeAnMRSTW.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Products
{
    public sealed record GetAllProductQuerry(string product_name) : IQuerry<List<Aliment>>;
}
