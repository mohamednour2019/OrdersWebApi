using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.DTO_s
{
    public class AddOrderProductRequestDto
    {

        [Required]
        public Guid orderId {  get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantatiy { get; set; }
    }
}
