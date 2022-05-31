using System;
using CourseworkDB.Entities;
using CourseworkDB.Interfaces;
using CourseworkDB.Models;
using CourseworkDB.Models.ProductionPlan;
using Microsoft.EntityFrameworkCore;

namespace CourseworkDB.Services
{
    public class ProductionPlanService : IProductionPlanService
    {
        private readonly IDbContextFactory<CourseworkDbContext> _dbContextFactory;

        public ProductionPlanService(IDbContextFactory<CourseworkDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        
        public ProductionPlan CreateProductionPlan(CreateProductionPlanModel model)
        {
            int reserved = 0;
            int shipment = 0;
            var remaining = model.Production - model.Demand;
            var availableToPromise = remaining;
            if (availableToPromise >= model.OrderedAmount)
            {
                shipment = model.OrderedAmount;
                availableToPromise -= model.OrderedAmount;
            }
            else
            {
                shipment = availableToPromise;
                availableToPromise = 0;
                reserved = model.OrderedAmount - shipment;
            }
            
            return new()
            {
                Date = model.Date,
                ProductId = model.ProductId,
                Production = model.Production,
                DomesticDemand = model.Demand,
                Shipment = shipment,
                AvailableToPromise = availableToPromise,
                Reserved = reserved,
                RemainingStock = remaining
            };
        }

        public ProductionPlan RecalculateProductionPlan(ProductionPlan plan, int addedAmountOfProduct)
        {
            if (plan.AvailableToPromise >= addedAmountOfProduct)
            {
                plan.Shipment += addedAmountOfProduct;
                plan.AvailableToPromise -= addedAmountOfProduct;
            }
            else
            {
                var shipment = plan.AvailableToPromise;
                plan.AvailableToPromise = 0;
                plan.Reserved = addedAmountOfProduct - shipment;
                plan.Shipment += shipment;
            }

            return plan;
        }
    }
}