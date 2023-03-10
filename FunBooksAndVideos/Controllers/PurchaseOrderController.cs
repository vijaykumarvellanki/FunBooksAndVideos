

using Microsoft.AspNetCore.Mvc;
using FunBooksAndVideos.Services.Interfaces;
using FunBooksAndVideos.Core.Models;
using System.Diagnostics.CodeAnalysis;

namespace FunBooksAndVideos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController:ControllerBase
    {
        public readonly IPurchaseOrderService _purchaseOrderService;
        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService= purchaseOrderService;
        }

        [Route("CreatePurchaseOrder")]
        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            var isCreated = await _purchaseOrderService.CreatePurchaseOrder(purchaseOrder);

            if(isCreated) 
            {
                return Ok(isCreated);
            }
            return BadRequest();
        }

        [Route("GetPurchaseOrderById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPurchaseOrderById(int id)
        {
            var purchaseOrder = await _purchaseOrderService.GetPurchaseOrderById(id);

            if(purchaseOrder !=null)
            {
                return Ok(purchaseOrder);
            }
            return BadRequest();
        }
    }
}
