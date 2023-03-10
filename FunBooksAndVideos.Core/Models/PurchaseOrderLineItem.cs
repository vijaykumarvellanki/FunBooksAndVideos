using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Core.Models
{
    [Table("PurchaseOrderLineItem")]
    public class PurchaseOrderLineItem
    {
        public int LineItemId { get; set; }

        [ForeignKey(nameof(PurchaseOrder))]
        public int POID { get; set; }

        public int LineItemTypeId { get; set; }

        public int ProductId { get; set; }

        //public PurchaseOrder PurchaseOrder { get; set; }
    }
}
