using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Domain.Entities
{
    public class OrderProduct:BaseEntity
    {
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Quantity Should be Positive!")]
        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
