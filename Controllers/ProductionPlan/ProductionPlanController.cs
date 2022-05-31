using System;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkDB.Controllers.ProductionPlan
{
    public class ProductionPlanController : Controller
    {
        // GET
        public IActionResult CreateProductionPlan()
        {
            return View();
        }
    }
}