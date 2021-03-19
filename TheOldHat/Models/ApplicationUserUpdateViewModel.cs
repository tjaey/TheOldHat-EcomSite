using System;
using TheOldHat.Domain;

namespace TheOldHat.Models
{
    public class ApplicationUserUpdateViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }

        public ApplicationUserUpdateViewModel()
        {
        }

        public ApplicationUserUpdateViewModel(ApplicationUser user)
        {
            CopyInformation(user);
        }

        private void CopyInformation(ApplicationUser user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Password = user.Password;
            Language = user.Language;
        }

    }
}
