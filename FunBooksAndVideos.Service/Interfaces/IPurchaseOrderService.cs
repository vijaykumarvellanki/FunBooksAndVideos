using FunBooksAndVideos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Services.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<bool> CreatePurchaseOrder(PurchaseOrder purchaseOrder);
        Task<PurchaseOrder> GetPurchaseOrderById(int purchaseOrderId);
    }
}
