using FunBooksAndVideos.Core.Interfaces;
using FunBooksAndVideos.Core.Models;
using FunBooksAndVideos.Services.Interfaces;
using FunBooksAndVideos.Service.Enums;

namespace FunBooksAndVideos.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public PurchaseOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            if(purchaseOrder != null)
            {
                CheckPurchaseOrderContainsMeembership(purchaseOrder);

                await CheckPurchaseOrderContainsPhysicalProduct(purchaseOrder);

                await _unitOfWork.PurchaseOrderRepository.Add(purchaseOrder);
                var result = _unitOfWork.Save();

                return result > 0 ? true : false;
            }
            return false;
        }

        public async Task<PurchaseOrder> GetPurchaseOrderById(int purchaseOrderId)
        {
            if (purchaseOrderId > 0)
            {
                var purchaseOrderDetails = await _unitOfWork.PurchaseOrderRepository.GetById(purchaseOrderId);
                if (purchaseOrderDetails != null)
                {
                    return purchaseOrderDetails;
                }
            }
            return null;
        }

        private void CheckPurchaseOrderContainsMeembership(PurchaseOrder purchaseOrder)
        {
            var clubMembership = purchaseOrder.PurchaseOrderLineItems.Where(x => x.LineItemId == (int)LineItemype.ClubMembership).ToList();
            if (clubMembership.Count > 0)
            {
                purchaseOrder.IsActivated = true;
            }
        }

        private Task CheckPurchaseOrderContainsPhysicalProduct(PurchaseOrder purchaseOrder)
        {
            var physicalOrder = purchaseOrder.PurchaseOrderLineItems.Where(x => (x.LineItemId == (int)LineItemype.Books || x.LineItemId == (int)LineItemype.Videos)).ToList();
            if (physicalOrder.Count > 0)
            {
                ProcessShippingSlip(purchaseOrder);
            }
            return Task.CompletedTask;
        }

        private void ProcessShippingSlip(PurchaseOrder purchaseOrder)
        {
            Console.WriteLine("Proccessed shipping slip");
        }
    }
}