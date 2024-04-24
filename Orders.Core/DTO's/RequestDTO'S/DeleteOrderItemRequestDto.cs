using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.DTO_s
{
    public class DeleteOrderItemRequestDto
    {
        public Guid OrderId { get; set;}
        public Guid ProductId {  get; set;} 
    }
}
