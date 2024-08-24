using StoneSafety.Models;
using StoneSafety.ViewModels.Users;

namespace StoneSafety.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserRoleVM>> GetAllWithRolesMappedAsync(List<AppUser> users);
    }
}
