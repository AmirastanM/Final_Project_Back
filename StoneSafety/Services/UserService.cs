using Microsoft.AspNetCore.Identity;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Users;

namespace StoneSafety.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserRoleVM>> GetAllWithRolesMappedAsync(List<AppUser> users)
        {
            List<UserRoleVM> usersWithRoles = new();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userRoles = string.Join(", ", roles.ToArray());
                usersWithRoles.Add(new UserRoleVM
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = userRoles
                });
            }

            return usersWithRoles;
        }
    }
}
