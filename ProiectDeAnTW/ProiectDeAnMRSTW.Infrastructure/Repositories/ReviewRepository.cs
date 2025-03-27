using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products;
using ProiectDeAnMRSTW.Domain.Reviews;
using ProiectDeAnMRSTW.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Infrastructure.Repositories
{
    internal sealed class ReviewRepository : IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext dbContext)
            //: base(dbContext)
        {

        }

        public void Add(Review review)
        {
            //throw new NotImplementedException();
        }

        //public Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        //{
        //    return Task.CompletedTask;
        //}
    }
}
