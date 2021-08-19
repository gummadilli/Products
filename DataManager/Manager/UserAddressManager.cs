using CommonLibraries.Interfaces;
using Microsoft.EntityFrameworkCore;
using Products.DBContext;
using Products.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Manager
{   
    public class UserAddressManager : IUserAddress
    {
        private readonly IDataUoW _dataUow;
        public UserAddressManager(IDataUoW dataUow)
        {
            _dataUow = dataUow;
        }


        public async Task<dynamic> GetAllUserAddress()
        {
            var userAddressData = await _dataUow.UserAddress.GetAll().ToListAsync();
            return userAddressData;
        }
        public async Task<dynamic> DeleteUserAddress(UserAddress userAddress)
        {
            _dataUow.UserAddress.Delete(userAddress);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> UpdateUserAddress(UserAddress userAddress)
        {
            _dataUow.UserAddress.Update(userAddress);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> SaveUserAddress(UserAddress userAddress)
        {
            _dataUow.UserAddress.Add(userAddress);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> GetUserAddressById(long id)
        {
            var userAddressData = await _dataUow.UserAddress.GetAllWithNoTracking().Where(p => p.AddressId == id).FirstOrDefaultAsync();
            return userAddressData;
        }
    }
}
