using System.Collections.Generic;
using TheOldHat.Domain;

namespace TheOldHat.Models
{
    public class SecretViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}
