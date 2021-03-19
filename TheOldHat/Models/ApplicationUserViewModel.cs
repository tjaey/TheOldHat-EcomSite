using System.Collections.Generic;
using TheOldHat.Domain;

namespace TheOldHat.Models
{
    public class ApplicationUserViewModel
    {
        public IReadOnlyList<ApplicationUser> ApplicationUsers { get; private set; }
        
        public ApplicationUserViewModel(IEnumerable<ApplicationUser> applicationUsers)
        {
            ApplicationUsers = new List<ApplicationUser>(applicationUsers);
        }
    }
}
