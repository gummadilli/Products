using CommonLibraries.Interfaces;
using Microsoft.EntityFrameworkCore;
using Products.DBContext;
using Products.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Manager
{   
    public class OrdersManager : IOrders
    {
        private readonly IDataUoW _dataUow;
        public OrdersManager(IDataUoW dataUow)
        {
            _dataUow = dataUow;
        }

        public async Task<dynamic> GetAllOrders()
        {
            var ordersData = await _dataUow.Orders.GetAll().ToListAsync();
            return ordersData;
        }
        public async Task<dynamic> DeleteOrderDetails(Orders order)
        {
            _dataUow.Orders.Delete(order);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> UpdateOrderDetails(Orders order)
        {
            _dataUow.Orders.Update(order);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> SaveOrderDetails(Orders order)
        {
            _dataUow.Orders.Add(order);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> GetOrderDetailsById(long id)
        {
            var customerData = await _dataUow.Orders.GetAllWithNoTracking().Where(p => p.OrderId == id).FirstOrDefaultAsync();
            return customerData;
        }
    }
}
