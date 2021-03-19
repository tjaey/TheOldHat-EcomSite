using System;
using System.Collections.Generic;
using System.Linq;
using TheOldHat.Common;
using TheOldHat.Common.Interfaces;
using TheOldHat.Domain;

namespace TheOldHat.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        public ApplicationUserRepository()
        {
            Init();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _allUsers;
        }

        public IEnumerable<ApplicationUser> GetAllMatching(Predicate<ApplicationUser> condition)
        {
            return _allUsers.Where(u => condition(u)).ToArray();
        }

        public ApplicationUser GetOne(int id)
        {
            return _allUsers.FirstOrDefault(u => u.Id == id);
        }

        public void Add(ApplicationUser item)
        {
            _allUsers.Add(item);
        }

        public static int NextId()
        {
            return _allUsers.Count;
        }

        public static int Count()
        {
            return _allUsers.Count;
        }

        public void Update(ApplicationUser item)
        {
            var user = GetOne(item.Id);

            if (user == null)
            {
                throw new ArgumentException("Application user not found");
            }

            user.ChangeFirstName(user.FirstName);
            user.ChangeLastName(user.LastName);
            user.ChangeEmail(user.Email);
            user.ChangeLanguage(user.Language);
            user.ChangePassword(user.Password);
        }

        public void Delete(int id)
        {
            var user = GetOne(id);

            if (user == null)
            {
                throw new ArgumentException("Application user not found");
            }

            _allUsers.Remove(user);
        }

        public IEnumerable<ApplicationUser> GetLockedUsers()
        {
            return Enumerable.Empty<ApplicationUser>();
        }


        private static readonly List<ApplicationUser> _allUsers = new List<ApplicationUser>();

        private void Init()
        {
            if (_allUsers.Any())
            {
                return;
            }

            var users = new List<ApplicationUser>()
            {
                new ApplicationUser(0, "Admin", "ComIt", "admin@comit.com", "password"),
                new ApplicationUser(1, "Test", "Prime", "test@prime.com", "123455")
            };

            _allUsers.AddRange(users);

            foreach (var user in _allUsers)
            {
                if (user.Email.StartsWith("admin"))
                {
                    user.AddRole(Constants.Roles.Admin);
                }

                user.AddRole(Constants.Roles.User);
            }
        }
    }


}