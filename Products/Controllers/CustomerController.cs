using CommonLibraries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using System;
using System.Threading.Tasks;

namespace Products.Controllers
{   
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomers _icustomer;
        public CustomerController(ICustomers icustomer)
        {
            _icustomer = icustomer;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<DataResult<dynamic>> GetAllCustomers()
        {
            try
            {
                var customerData = await _icustomer.GetAllCustomers();

                if (customerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, customerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }

        [HttpGet("GetCustomerDetailsById/{id}")]
        public async Task<DataResult<dynamic>> GetCustomerDetailsById(int id)
        {
            try
            {
                var customerData = await _icustomer.GetCustomerDetailsById(id);

                if (customerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, customerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }

        [HttpGet("SaveCustomerDetails")]
        public async Task<DataResult<dynamic>> SaveCustomerDetails([FromBody] Customers customer)
        {
            try
            {
                var customerData = await _icustomer.SaveCustomerDetails(customer);

                if (customerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, customerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }

        [HttpGet("UpdateCustomerDetails")]
        public async Task<DataResult<dynamic>> UpdateCustomerDetails([FromBody] Customers customer)
        {
            try
            {
                var customerData = await _icustomer.UpdateCustomerDetails(customer);

                if (customerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, customerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }

        [HttpGet("DeleteCustomerDetails")]
        public async Task<DataResult<dynamic>> DeleteCustomerDetails([FromBody] Customers customer)
        {
            try
            {
                var customerData = await _icustomer.DeleteCustomerDetails(customer);

                if (customerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, customerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }
    }
}
