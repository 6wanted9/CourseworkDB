using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB.Entities
{
    public class ProductOrderLine
    {
        [Key, Required]
        public int Id { get; set; }
        
        public int OrderLineId { get; set; }

        public OrderLine OrderLine { get; set; }
        
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}