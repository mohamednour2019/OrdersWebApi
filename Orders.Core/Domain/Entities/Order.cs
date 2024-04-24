using Orders.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Domain.Entities
{
    public class Order:BaseEntity
    {
        public string OrderNumber { get; set; }
        [Required(ErrorMessage ="Customer Name Can't be Blank!")]
        [MaxLength(50,ErrorMessage ="Customer Name Shouldn't Exceed 50 Characters!")]
        public string CustomerName {  get; set; }
        [Required(ErrorMessage ="Order Date Shouldn't be Blank!")]
        public DateTime OrderDate { get; set; }= DateTime.Now;
        [Range(1,double.MaxValue,ErrorMessage ="Total Amount Should be Positive!")]
        public double TotalAmount {  get; set; }

        public List<OrderProduct> OrderProduct { get; set; }
    }
}
