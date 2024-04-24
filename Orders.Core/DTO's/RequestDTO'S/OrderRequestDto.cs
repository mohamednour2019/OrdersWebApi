using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.DTO_s
{
    public class OrderRequestDto
    {
        [Required(ErrorMessage = "Customer Name Can't be Blank!")]
        [MaxLength(50, ErrorMessage = "Customer Name Shouldn't Exceed 50 Characters!")]
        public string CustomerName { get; set; }
        [Required]
        public List<ProductDetailsRequestDto> ProductsDetails { get; set; }

    }

}
