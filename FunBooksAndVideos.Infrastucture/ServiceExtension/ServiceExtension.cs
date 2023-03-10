using FunBooksAndVideos.Core.Interfaces;
using FunBooksAndVideos.Infrastucture.Repositories;
using FunBooksAndVideos.Services;
using FunBooksAndVideos.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Infrastucture.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<DbContextClass>(options =>
            {
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

           
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderLineItemRepository, PurchaseOrderLineItemRepository>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();



            return services;
        }
    }
}
