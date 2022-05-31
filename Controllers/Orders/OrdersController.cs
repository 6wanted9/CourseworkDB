using System;
using System.Linq;
using System.Threading.Tasks;
using CourseworkDB.Entities;
using CourseworkDB.Interfaces;
using CourseworkDB.Models;
using CourseworkDB.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseworkDB.Controllers.Orders
{
    public class OrdersController : Controller
    {
        private readonly IDbContextFactory<CourseworkDbContext> _dbContextFactory;
        private readonly IOrderService _orderService;

        public OrdersController(IDbContextFactory<CourseworkDbContext> dbContextFactory, IOrderService orderService)
        {
            _dbContextFactory = dbContextFactory;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var context = _dbContextFactory.CreateDbContext();
                
            var customers = await context.Customers.ToListAsync();
            var products = await context.Products.ToListAsync();
            ViewBag.Customers = new SelectList(customers, "Id", "Name");
            ViewBag.Products = products;
            var createOrderModel = new CreateOrderModel();
            return View(createOrderModel);
        }
        
        [HttpPost]
        public async Task<RedirectResult> CreateOrder([FromForm] CreateOrderModel model)
        {
           await  _orderService.CreateOrder(model);
           return Redirect("/Home/Index");
        }
    }
}