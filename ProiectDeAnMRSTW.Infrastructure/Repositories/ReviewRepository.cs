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
        protected readonly ApplicationDbContext _DbContext;
        public ReviewRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void Add(Review review)
        {
            _DbContext.Add(review);
        }
    }
}
