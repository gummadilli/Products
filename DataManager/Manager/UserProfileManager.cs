using CommonLibraries.Interfaces;
using Microsoft.EntityFrameworkCore;
using Products.DBContext;
using Products.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Manager
{
    public class UserProfileManager : IUserProfile
    {
        private readonly IDataUoW _dataUow;
        public UserProfileManager(IDataUoW dataUow)
        {
            _dataUow = dataUow;
        }
        public async Task<dynamic> GetAllUserProfiles()
        {
            var userProfileData = await _dataUow.UserProfile.GetAll().ToListAsync();
            return userProfileData;
        }
        public async Task<dynamic> DeleteUserProfile(UserProfile userProfile)
        {
            _dataUow.UserProfile.Delete(userProfile);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> UpdateUserProfile(UserProfile userProfile)
        {
            _dataUow.UserProfile.Update(userProfile);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> SaveUserProfile(UserProfile userProfile)
        {
            _dataUow.UserProfile.Add(userProfile);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> GetUserProfileById(long id)
        {
            var userProfileData = await _dataUow.UserProfile.GetAllWithNoTracking().Where(p => p.UserProfileId == id).FirstOrDefaultAsync();
            return userProfileData;
        }
    }
}
