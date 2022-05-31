using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB.Entities
{
    public class OrderLine
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public int Amount { get; set; }
        
        public int OrderId { get; set; }

        public Order Order { get; set; }
        
        public List<ProductOrderLine> ProductOrderLines { get; set; }
    }
}