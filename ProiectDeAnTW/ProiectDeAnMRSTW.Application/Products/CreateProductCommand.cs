using ProiectDeAnMRSTW.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProiectDeAnMRSTW.Application.Products
{
    public record CreateProductCommand(Guid Id) : ICommand<Guid>;
}
