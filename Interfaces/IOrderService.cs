using System.Threading.Tasks;
using CourseworkDB.Models.Orders;

namespace CourseworkDB.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrderModel model);
    }
}