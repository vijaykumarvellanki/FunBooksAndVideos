using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Core.Models
{
    [Table("PurchaseOrder")]
    public class PurchaseOrder
    {
        public int POID { get; set; }

        [Required(ErrorMessage ="Total Required")]
        public decimal Total { get; set; }

        public int CustomerID { get; set; }

        public bool IsActivated { get; set; }

        public ICollection<PurchaseOrderLineItem> PurchaseOrderLineItems { get; set; }
    }
}
