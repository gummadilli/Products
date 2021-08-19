using Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraries.Interfaces
{
    public interface IUserProfile
    {
        Task<dynamic> GetAllUserProfiles();
        Task<dynamic> GetUserProfileById(long id);
        Task<dynamic> SaveUserProfile(UserProfile userProfile);
        Task<dynamic> UpdateUserProfile(UserProfile userProfile);
        Task<dynamic> DeleteUserProfile(UserProfile userProfile);
    }
}
