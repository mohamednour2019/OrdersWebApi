using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.DTO_s
{
    public class UpdateOrderRequestDto
    {
        public Guid Id;
        [Required]
        public string OrderName { get; set; }

    }
}
