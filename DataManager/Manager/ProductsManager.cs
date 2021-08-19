using CommonLibraries.Interfaces;
using Microsoft.EntityFrameworkCore;
using Products.DBContext;
using Products.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Manager
{  
    public class ProductsManager : IProducts
    {
        private readonly IDataUoW _dataUow;
        public ProductsManager(IDataUoW dataUow)
        {
            _dataUow = dataUow;
        }
        public async Task<dynamic> GetAllProducts()
        {
            var productsData = await _dataUow.Product.GetAll().ToListAsync();
            return productsData;
        }
        public async Task<dynamic> DeleteProductDetails(Product product)
        {
            _dataUow.Product.Delete(product);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> UpdateProductDetails(Product product)
        {
            _dataUow.Product.Update(product);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> SaveProductDetails(Product product)
        {
            _dataUow.Product.Add(product);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> GetProductDetailsById(long id)
        {
            var productData = await _dataUow.Product.GetAllWithNoTracking().Where(p => p.ProductId == id).FirstOrDefaultAsync();
            return productData;
        }
    }
}
