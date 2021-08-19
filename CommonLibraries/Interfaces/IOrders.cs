using Products.Models;
using System.Threading.Tasks;

namespace CommonLibraries.Interfaces
{
    public interface IOrders
    {
        Task<dynamic> GetAllOrders();
        Task<dynamic> GetOrderDetailsById(long id);
        Task<dynamic> SaveOrderDetails(Orders order);
        Task<dynamic> UpdateOrderDetails(Orders order);
        Task<dynamic> DeleteOrderDetails(Orders order);
    }
}
