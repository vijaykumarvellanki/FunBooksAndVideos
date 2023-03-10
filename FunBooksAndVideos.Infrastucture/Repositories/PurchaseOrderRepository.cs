using FunBooksAndVideos.Core.Interfaces;
using FunBooksAndVideos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Infrastucture.Repositories
{
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(DbContextClass dbContext) : base(dbContext) { }
    }
}
