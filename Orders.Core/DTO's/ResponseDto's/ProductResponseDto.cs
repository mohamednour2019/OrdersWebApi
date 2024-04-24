﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.DTO_s
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Product Name Can't be Blank!")]
        [MaxLength(50, ErrorMessage = "Product Name Shouldn't Exceed 50 Characters!")]
        public string ProductName { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Unit Price Should be Positive!")]
        public double UnitPrice { get; set; }
    }
}
