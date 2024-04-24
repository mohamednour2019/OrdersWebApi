using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.DTO_s
{
    public class UpdateOrderItemRequestDto
    {
        public Guid orderId {  get; set; }

        public Guid productId {  get; set; }

        [Required]
        public int Quantity {  get; set; }
    }
}
