using Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.DBContext
{
    public interface IProducts
    {
        Task<List<UserProfile>> GetAllUserProfile();
        Task<List<SecretQuestions>> GetAllSecretQuestions();
        Task<List<Userdetails>> GetAllUserdetails();
        Task<List<UserAddress>> GetAllUserAddress();
        Task<List<Product>> GetAllProduct();
        Task<List<Customers>> GetAllCustomers();
        Task<List<Orders>> GetAllOrders();

    }
}
