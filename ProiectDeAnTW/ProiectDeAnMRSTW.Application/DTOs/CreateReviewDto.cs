using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectDeAnMRSTW.Domain.Reviews;

namespace ProiectDeAnMRSTW.Application.DTOs
{
    public class CreateReviewDto
    {
        public string ProductName { get; set; }
        public Rating Rating { get; set; } = new();
        public Comment Comment { get; set; } = new();
    }
}
