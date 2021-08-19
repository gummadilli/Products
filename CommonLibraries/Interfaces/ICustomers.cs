using Products.Models;
using System.Threading.Tasks;

namespace CommonLibraries.Interfaces
{
    public interface ICustomers
    {
        Task<dynamic> GetAllCustomers();
        Task<dynamic> GetCustomerDetailsById(long id);
        Task<dynamic> SaveCustomerDetails(Customers customer);
        Task<dynamic> UpdateCustomerDetails(Customers customer);
        Task<dynamic> DeleteCustomerDetails(Customers customer);
    }
}
