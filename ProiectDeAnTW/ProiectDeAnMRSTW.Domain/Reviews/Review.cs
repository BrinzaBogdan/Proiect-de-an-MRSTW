using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Reviews.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Domain.Reviews;

public sealed class Review 
{
    private Review(Guid id, Guid productId, Rating rating, Comment comment, DateTime createdOnUtc)
    {
        Id = id;
        ProductId = productId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
    }

    public Review()
    {
    }
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public Rating Rating { get; set; }

    public Comment Comment { get; set; } = new Comment("");
     
    public DateTime CreatedOnUtc { get; set; }

    public static Result<Review> Create(Guid ProductId, Rating rating, Comment comment, DateTime createdOnUtc)
    {
        var review = new Review(
            Guid.NewGuid(),
            ProductId,
            rating,
            comment,
            createdOnUtc);

        //review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));

        return review;
    }
}
