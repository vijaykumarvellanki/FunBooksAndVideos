using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPurchaseOrderRepository PurchaseOrderRepository { get; }   
        IPurchaseOrderLineItemRepository PurchaseOrderLineItemRepository { get;}
        int Save();
    }
}
