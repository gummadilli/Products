using CommonLibraries.Interfaces;
using Microsoft.EntityFrameworkCore;
using Products.DBContext;
using Products.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Manager
{
    public class UserDetailsManager : IUserDetails
    {
        private readonly IDataUoW _dataUow;
        public UserDetailsManager(IDataUoW dataUow)
        {
            _dataUow = dataUow;
        }
        public async Task<dynamic> GetAllUserDetails()
        {
            var userDetailsData = await _dataUow.Userdetails.GetAll().ToListAsync();
            return userDetailsData;
        }
        public async Task<dynamic> DeleteUserDetails(Userdetails userDetails)
        {
            _dataUow.Userdetails.Delete(userDetails);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> UpdateUserDetails(Userdetails userDetails)
        {
            _dataUow.Userdetails.Update(userDetails);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> SaveUserDetails(Userdetails userDetails)
        {
            _dataUow.Userdetails.Add(userDetails);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> GetUserDetailsById(long id)
        {
            var userDetailsData = await _dataUow.Userdetails.GetAllWithNoTracking().Where(p => p.UserDetailsId == id).FirstOrDefaultAsync();
            return userDetailsData;
        }
    }
}
