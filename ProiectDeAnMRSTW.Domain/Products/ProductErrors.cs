using ProiectDeAnMRSTW.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Domain.Products
{
    public static class ProductErrors
    {
        public static readonly Error NotFound = new(
            "Product.Found",
            "The Product with the specified identifier was not found");
        
        public static readonly Error NullValue = new(
            "NullValue",
            "The Return value is null");

        public static readonly Error Overlap = new(
            "Booking.Overlap",
            "The current booking is overlapping with an existing one");
    }

}
