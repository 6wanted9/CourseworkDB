using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseworkDB.Entities;
using CourseworkDB.Interfaces;
using CourseworkDB.Models;
using CourseworkDB.Models.Orders;
using CourseworkDB.Models.ProductionPlan;
using Microsoft.EntityFrameworkCore;

namespace CourseworkDB.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDbContextFactory<CourseworkDbContext> _dbContextFactory;
        private IProductionPlanService _productionPlanService;

        public OrderService(
            IDbContextFactory<CourseworkDbContext> dbContextFactory,
            IProductionPlanService productionPlanService)
        {
            _dbContextFactory = dbContextFactory;
            _productionPlanService = productionPlanService;
        }

        public async Task CreateOrder(CreateOrderModel model)
        {
            var context = _dbContextFactory.CreateDbContext();

            var notEmptyOrderLines = model.OrderLines.Where(l => l.Amount > 0).ToList();
            
            var order = new Order
            {
                CustomerId = model.CustomerId,
                Number = Guid.NewGuid(),
                Date = DateTime.Now.Date,
            };
            
            var newOrder = context.Add(order).Entity;
            await context.SaveChangesAsync();
            foreach (var orderLineModel in notEmptyOrderLines)
            {
                var orderLine = new OrderLine
                {
                    Amount = orderLineModel.Amount,
                    OrderId = newOrder.Id
                };

                var newOrderLine = context.Add(orderLine).Entity;

                await context.SaveChangesAsync();
                var productOrderLine = new ProductOrderLine
                {
                    OrderLineId = newOrderLine.Id,
                    ProductId = orderLineModel.ProductId
                };

                context.Add(productOrderLine);
                await context.SaveChangesAsync();
            }
            
            foreach (var orderLine in notEmptyOrderLines)
            {
                var productionPlan = GetPlanForProductAndDate(context, orderLine.ProductId, order.Date);

                if (productionPlan != null)
                {
                    var updatedProductionPlan =
                        _productionPlanService.RecalculateProductionPlan(productionPlan, orderLine.Amount);

                    context.Update(updatedProductionPlan);
                }
                else
                {
                    var createProductionPlanModel = new CreateProductionPlanModel
                    {
                        Date = order.Date,
                        OrderedAmount = orderLine.Amount,
                        ProductId = orderLine.ProductId,
                        Demand = model.OrderLines.First(o => o.ProductId == orderLine.ProductId).DemandAmount,
                        Production = model.OrderLines.First(o => o.ProductId == orderLine.ProductId).ProductionAmount
                    };
                    var newProductionPlan = _productionPlanService.CreateProductionPlan(createProductionPlanModel);

                    await context.AddAsync(newProductionPlan);
                }
            }
            
            await context.SaveChangesAsync();
        }

        private ProductionPlan GetPlanForProductAndDate(
            CourseworkDbContext context,
            int productId,
            DateTime date)
        {
            var productionPlan =
                from plan in context.ProductionPlans
                where plan.Date == date && plan.ProductId == productId
                select plan;

            return productionPlan.FirstOrDefault();
        }
    }
}