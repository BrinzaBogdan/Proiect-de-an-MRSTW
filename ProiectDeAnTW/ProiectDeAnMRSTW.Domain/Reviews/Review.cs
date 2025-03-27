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
    private Review(int id, Guid productId, Rating rating, Comment comment, DateTime createdOnUtc)
    {
        ProductId = productId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
        Id = id;
    }

    public Review()
    {
    }
    public int Id { get; set; }

    public Guid ProductId { get; set; }

    public Rating Rating { get; set; }

    public Comment Comment { get; set; } = new Comment("");
     
    public DateTime CreatedOnUtc { get; set; }

    public static Result<Review> Create(Aliment aliment, Rating rating, Comment comment, DateTime createdOnUtc)
    {
        Random random = new Random();
        int nr = random.Next(1, 101);
        var review = new Review(
            nr,
            aliment.Id,
            rating,
            comment,
            createdOnUtc);

        //review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));

        return review;
    }
}
