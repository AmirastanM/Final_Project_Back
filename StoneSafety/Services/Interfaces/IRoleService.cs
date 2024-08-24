using Microsoft.AspNetCore.Mvc.Rendering;
using StoneSafety.Models;

namespace StoneSafety.Services.Interfaces
{
    public interface IRoleService
    {
        Task<SelectList> GetAllSelectedAvailableAsync(AppUser user);
    }
}
