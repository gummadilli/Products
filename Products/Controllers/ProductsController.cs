using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.DBContext;
using Products.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    /// <summary>
    /// Products
    /// </summary>
    [Route("Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDataUoW _dataUow;       
        private readonly DataContext _dataContext;

        /// <summary>
        /// ProductsController
        /// </summary>
        /// <param name="dataUow"></param>
        /// <param name="dataContext"></param>
        public ProductsController(IDataUoW dataUow, DataContext dataContext)
        {
            _dataUow = dataUow;
            _dataContext = dataContext;           
        }

        /// <summary>
        /// GetUserProfileList
        /// </summary>
        /// <returns></returns>
        //User Profile Table
        [HttpGet("GetUserProfileList")]
        public async Task<dynamic> GetUserProfileList()
        {
            try
            {
                var providerData = await _dataUow.UserProfile.GetAll().ToListAsync();
                return providerData;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// GetUserProfileById
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <returns></returns>
        [HttpGet("GetUserProfileById/{id}")]
        public async Task<DataResult<dynamic>> GetUserProfileById(int id,string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.UserProfile.GetAllWithNoTracking().Where(p => p.UserProfileId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }

        /// <summary>
        /// SaveUserProfile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPost("SaveUserProfile")]
        public async Task<dynamic> SaveUserProfile(UserProfile profile)
        {
            try
            { 
                _dataUow.UserProfile.Add(profile);
                await _dataUow.CommitAsync("");
                return "Success";

            }
            catch(Exception ex)
            {
                return ex.Message;
            }          
        }

        /// <summary>
        /// UpdateUserProfile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPut("UpdateUserProfile")]
        public async Task<dynamic> UpdateUserProfile(UserProfile profile)
        {
            _dataUow.UserProfile.Update(profile);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpDelete("DeleteUserProfile")]
        public async Task<dynamic> DeleteUserProfile(UserProfile profile)
        {
            _dataUow.UserProfile.Delete(profile);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        //Secret Question Table
        [HttpGet("GetSecretQuestionList")]
        public async Task<dynamic> GetSecretQuestionList()
        {
            var providerData = await _dataUow.SecretQuestions.GetAll().ToListAsync();
            return providerData;
        }

        [HttpPost("SaveSecretQuestion")]
        public async Task<dynamic> SaveSecretQuestion(SecretQuestions question)
        {
            _dataUow.SecretQuestions.Add(question);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpPut("UpdateSecretQuestion")]
        public async Task<dynamic> UpdateSecretQuestion(SecretQuestions question)
        {
            _dataUow.SecretQuestions.Update(question);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpDelete("DeleteSecretQuestion")]
        public async Task<dynamic> DeleteSecretQuestion(SecretQuestions question)
        {
            _dataUow.SecretQuestions.Delete(question);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        //User details Table
        [HttpGet("GetUserdetailsList")]
        public async Task<dynamic> GetUserdetailsList()
        {
            var providerData = await _dataUow.Userdetails.GetAll().ToListAsync();
            return providerData;
        }

        [HttpPost("SaveUserdetails")]
        public async Task<dynamic> SaveUserdetails(Userdetails details)
        {
            _dataUow.Userdetails.Add(details);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpPost("UpdateUserdetails")]
        public async Task<dynamic> UpdateUserdetails(Userdetails details)
        {
            _dataUow.Userdetails.Update(details);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpPost("DeleteUserdetails")]
        public async Task<dynamic> DeleteUserdetails(Userdetails details)
        {
            _dataUow.Userdetails.Delete(details);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        //User Address Table
        [HttpGet("GetUserAddressList")]
        public async Task<dynamic> GetUserAddressList()
        {
            var providerData = await _dataUow.UserAddress.GetAll().ToListAsync();
            return providerData;
        }
        [HttpPost("SaveUserAddress")]
        public async Task<dynamic> SaveUserAddress(UserAddress address)
        {
            _dataUow.UserAddress.Add(address);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpPost("UpdateUserAddress")]
        public async Task<dynamic> UpdateUserAddress(UserAddress address)
        {
            _dataUow.UserAddress.Update(address);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpPost("DeleteUserAddress")]
        public async Task<dynamic> DeleteUserAddress(UserAddress address)
        {
            _dataUow.UserAddress.Delete(address);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        //Product Table
        [HttpGet("GetProductList")]
        public async Task<dynamic> GetProductList()
        {
            var providerData = await _dataUow.Product.GetAll().ToListAsync();
            return providerData;
        }
        [HttpPost("SaveProduct")]
        public async Task<dynamic> SaveProduct(Product product)
        {
            _dataUow.Product.Add(product);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpPost("UpdateProduct")]
        public async Task<dynamic> UpdateProduct(Product product)
        {
            _dataUow.Product.Update(product);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpPost("DeleteProduct")]
        public async Task<dynamic> DeleteProduct(Product product)
        {
            _dataUow.Product.Delete(product);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        //Customers Table
        [HttpGet("GetCustomersList")]
        public async Task<dynamic> GetCustomersList()
        {
            var providerData = await _dataUow.Customers.GetAll().ToListAsync();
            return providerData;
        }
        [HttpPost("SaveCustomers")]
        public async Task<dynamic> SaveCustomers(Customers customer)
        {
            _dataUow.Customers.Add(customer);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpPost("UpdateCustomers")]
        public async Task<dynamic> UpdateCustomers(Customers customer)
        {
            _dataUow.Customers.Update(customer);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpPost("DeleteCustomers")]
        public async Task<dynamic> DeleteCustomers(Customers customer)
        {
            _dataUow.Customers.Delete(customer);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        //Order Table
        [HttpGet("GetOrdersList")]
        public async Task<dynamic> GetOrdersList()
        {
            var providerData = await _dataUow.Orders.GetAll().ToListAsync();
            return providerData;
        }
        [HttpPost("SaveOrders")]
        public async Task<dynamic> SaveOrders(Orders order)
        {
            _dataUow.Orders.Add(order);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpPost("UpdateOrders")]
        public async Task<dynamic> UpdateOrders(Orders order)
        {
            _dataUow.Orders.Update(order);
            await _dataUow.CommitAsync("");
            return "Success";
        }

        [HttpPost("DeleteOrders")]
        public async Task<dynamic> DeleteOrders(Orders order)
        {
            _dataUow.Orders.Delete(order);
            await _dataUow.CommitAsync("");
            return "Success";
        }
    }
}
