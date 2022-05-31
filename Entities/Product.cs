using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB.Entities
{
    public class Product
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public List<ProductOrderLine> ProductOrderLines { get; set; }

        public List<ProductionPlan> ProductionPlans { get; set; }
    }
}