using CourseworkDB.Entities;
using CourseworkDB.Models.ProductionPlan;

namespace CourseworkDB.Interfaces
{
    public interface IProductionPlanService
    {
        ProductionPlan CreateProductionPlan(CreateProductionPlanModel model);

        ProductionPlan RecalculateProductionPlan(ProductionPlan plan, int addedAmountOfProduct);
    }
}