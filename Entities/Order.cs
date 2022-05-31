using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public Guid Number { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}