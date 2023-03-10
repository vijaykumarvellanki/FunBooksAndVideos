using FunBooksAndVideos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Infrastucture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public IPurchaseOrderRepository PurchaseOrderRepository { get; }
        public IPurchaseOrderLineItemRepository PurchaseOrderLineItemRepository { get; }

        public UnitOfWork(DbContextClass dbContext, 
                                IPurchaseOrderRepository purchaseOrderRepository, 
                                IPurchaseOrderLineItemRepository purchaseOrderLineItemRepository)
        {
            _dbContext = dbContext;
            PurchaseOrderRepository = purchaseOrderRepository;
            PurchaseOrderLineItemRepository = purchaseOrderLineItemRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing) 
        {
            if(disposing) 
            {
                _dbContext.Dispose();
            }
        }
    }
}
