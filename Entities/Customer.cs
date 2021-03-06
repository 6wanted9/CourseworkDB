using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}