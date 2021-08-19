using Products.Models;
using System.Threading.Tasks;

namespace CommonLibraries.Interfaces
{
    public interface IProducts
    {
        Task<dynamic> GetAllProducts();
        Task<dynamic> GetProductDetailsById(long id);
        Task<dynamic> SaveProductDetails(Product product);
        Task<dynamic> UpdateProductDetails(Product product);
        Task<dynamic> DeleteProductDetails(Product product);
    }
}
