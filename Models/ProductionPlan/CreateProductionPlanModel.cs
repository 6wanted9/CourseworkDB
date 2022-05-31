using System;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB.Models.ProductionPlan
{
    public class CreateProductionPlanModel
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public int OrderedAmount { get; set; }

        public int Demand { get; set; }

        public int Production { get; set; }

        public int ProductId { get; set; }

    }
}