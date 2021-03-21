using System;
using System.Collections.Generic;

namespace TheOldHat.Domain
{
    public class ApplicationUser : IEntity
    {
        private readonly List<string> _roles = new List<string>();
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Language { get; private set; }
        public IReadOnlyList<string> Roles => _roles;
        private string DEFAULT_LANGAUGE = "english";

        public ApplicationUser(int id, string firstName, string lastName, string email, string password)
        {
            if (id < 0)
            {
                throw new ArgumentException("id");
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("firstName");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("lastName");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("email");
            }

            if (string.IsNullOrWhiteSpace(password)){
                throw new ArgumentException("password");
            }

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Language = DEFAULT_LANGAUGE;
        }

        public void ChangeId(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id");
            }
            Id = id;
        }

        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }

        public void ChangeLanguage(string language)
        {
            Language = language;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void AddRole(string role)
        {
            _roles.Add(role);
        }
    }
}
