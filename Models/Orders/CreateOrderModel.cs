using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseworkDB.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CourseworkDB.Models.Orders
{
    public class CreateOrderModel
    {
        public int CustomerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public List<OrderLineModel> OrderLines { get; set; }
    }
}