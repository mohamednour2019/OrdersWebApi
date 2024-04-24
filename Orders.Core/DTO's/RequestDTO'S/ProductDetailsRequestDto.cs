using Orders.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.DTO_s
{
    public class ProductDetailsRequestDto
    {
        public Guid Id { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Quantity Should be Positive!")]
        public int Quantity { get; set; }
    }
}
