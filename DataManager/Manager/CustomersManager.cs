using CommonLibraries.Interfaces;
using Microsoft.EntityFrameworkCore;
using Products.DBContext;
using Products.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Manager
{
    public class CustomersManager:ICustomers
    {
        private readonly IDataUoW _dataUow;        
        public CustomersManager(IDataUoW dataUow)
        {
            _dataUow = dataUow;            
        }

        public async Task<dynamic> GetAllCustomers()
        {
            var providerData = await _dataUow.Customers.GetAll().ToListAsync();
            return providerData;
        }
        public async Task<dynamic> DeleteCustomerDetails(Customers customer)
        {
            _dataUow.Customers.Delete(customer);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> UpdateCustomerDetails(Customers customer)
        {
            _dataUow.Customers.Update(customer);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> SaveCustomerDetails(Customers customer)
        {
            _dataUow.Customers.Add(customer);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> GetCustomerDetailsById(long id)
        {
            var customerData = await _dataUow.Customers.GetAllWithNoTracking().Where(p => p.CustomerId == id).FirstOrDefaultAsync();
            return customerData;
        }       
    }
}
