using System.Collections.Generic;
using TheOldHat.Domain;

namespace TheOldHat.Common.Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetLockedUsers();
    }
}
