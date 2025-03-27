using ProiectDeAnMRSTW.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Domain.Reviews;

public interface IReviewRepository
{
    //Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public void Add(Review review);
}
