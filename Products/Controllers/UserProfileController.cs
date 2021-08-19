using CommonLibraries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{   
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfile _iUserProfile;
        public UserProfileController(IUserProfile iUserProfile)
        {
            _iUserProfile = iUserProfile;
        }

        [HttpGet("GetAllUserProfiles1")]
        public async Task<dynamic> GetAllUserProfiles1()
        {
            try
            {
                var customerData = await _iUserProfile.GetAllUserProfiles();
                return customerData;
                //if (customerData != null)
                //{
                //    return new DataResult<dynamic>(StatusCodes.Status200OK, customerData);
                //}
                //else
                //{
                //    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                //}
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("GetAllUserProfiles")]
        public async Task<DataResult<dynamic>> GetAllUserProfiles()
        {
            try
            {
                var customerData = await _iUserProfile.GetAllUserProfiles();

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
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("SaveUserProfiles")]
        public async Task<DataResult<dynamic>> SaveUserProfiles([FromBody]UserProfile userprofile)
        {
            try
            {
                var customerData = await _iUserProfile.SaveUserProfile(userprofile);

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
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("EditUserProfiles")]
        public async Task<DataResult<dynamic>> EditUserProfiles([FromBody]UserProfile userprofile)
        {
            try
            {
                var customerData = await _iUserProfile.UpdateUserProfile(userprofile);

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
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteUserProfiles/{id}")]
        public async Task<DataResult<dynamic>> DeleteUserProfiles(int id)
        {
            try
            {
                UserProfile obj = new UserProfile()
                {
                    UserProfileId= id                    
                };

                var customerData = await _iUserProfile.DeleteUserProfile(obj);

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
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
