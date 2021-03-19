using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TheOldHat.Common.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace TheOldHat.Services
{
    public interface INativeAuthenticationService
    {
        Task<AuthenticationResult> SignIn(HttpContext context, string email, string password);
        Task<AuthenticationResult> SignOut(HttpContext context);
    }

    public class AuthenticationResult
    {
        public bool Success { get; private set; }
        public string Error { get; private set; }

        public AuthenticationResult()
        {
            Success = true;
            Error = string.Empty;
        }

        public void SetError(string error)
        {
            Error = error;
            Success = false;
        }
    }

    public class NativeAutheticationService : INativeAuthenticationService
    {
        private readonly IApplicationUserRepository _repo;

        public NativeAutheticationService(IApplicationUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<AuthenticationResult> SignIn(HttpContext context, string email, string password)
        {
            var result = new AuthenticationResult();
            var user = _repo.GetAllMatching(u => u.Email == email).FirstOrDefault();

            if(user == null)
            {
                result.SetError("User not found, please register for an account");
                return result;
            }

            if(user.Password == password)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.AuthenticationMethod, "Native"),
                    new Claim("Language", user.Language),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await context.SignInAsync(principal);

                return result;
            }
            else
            {
                result.SetError("Invalid password, try again");
                return result;
            }
        }

        public async Task<AuthenticationResult> SignOut(HttpContext context)
        {
            var result = new AuthenticationResult();

            await context.SignOutAsync();

            return result;
        }
    }
}
