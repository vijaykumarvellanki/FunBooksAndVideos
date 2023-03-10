using FunBooksAndVideos.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Infrastucture
{
    public class DbContextClass:DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {
            
        }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set;}

        public DbSet<PurchaseOrderLineItem> PurchaseOrderLineItem { get;}

    }
}