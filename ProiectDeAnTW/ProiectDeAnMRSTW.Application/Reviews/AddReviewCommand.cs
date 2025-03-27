using ProiectDeAnMRSTW.Application.Abstractions.Messaging;
using ProiectDeAnMRSTW.Domain.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProiectDeAnMRSTW.Application.Reviews
{
    public record AddReviewCommand(Guid productId, Rating Rating, Comment Comment) : ICommand<int>;
}
