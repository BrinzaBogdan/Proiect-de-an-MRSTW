using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Reviews
{
    public class AddReviewCommandValidator : AbstractValidator<AddReviewCommand>//Validam tipul AddReviewCommand
    {
        public AddReviewCommandValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty();
            RuleFor(c => c.Comment).NotEmpty();
            RuleFor(c => c.Rating).NotEmpty();
        }
    }
}
