using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.DTO_s
{
    public class GetOrderItemsRequestDto
    {
        public Guid orderId {  get; set; }
        public Guid productId {  get; set; }
    }
}
