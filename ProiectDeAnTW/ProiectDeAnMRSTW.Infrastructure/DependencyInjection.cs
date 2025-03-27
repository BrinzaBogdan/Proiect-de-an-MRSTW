using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProiectDeAnMRSTW.Application.Abstractions.Clock;
using ProiectDeAnMRSTW.Application.Abstractions.Email;
using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products;
using ProiectDeAnMRSTW.Domain.Reviews;
using ProiectDeAnMRSTW.Infrastructure.Clock;
using ProiectDeAnMRSTW.Infrastructure.Data;
using ProiectDeAnMRSTW.Infrastructure.Email;
using ProiectDeAnMRSTW.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration,string connectionString)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            services.AddTransient<IEmailService, EmailService>();
            //string connectionString = configuration.GetConnectionString("DefaultConnection") ??
            //                      throw new ArgumentNullException(nameof(configuration));

             //services.AddDbContext<ApplicationDbContext>(options =>
             //       options.UseSqlServer(connectionString));

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IReviewRepository, ReviewRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;

        }
    }
}
