using System;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB.Entities
{
    public class ProductionPlan
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public int Reserved { get; set; }

        public int Shipment { get; set; }

        [Required]
        public int DomesticDemand { get; set; }

        [Required]
        public int Production { get; set; }

        public int RemainingStock { get; set; }

        public int AvailableToPromise { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}