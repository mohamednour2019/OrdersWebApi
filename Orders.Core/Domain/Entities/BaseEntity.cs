using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Domain.Entities
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

    }
}
