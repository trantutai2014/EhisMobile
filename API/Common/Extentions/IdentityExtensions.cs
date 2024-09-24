using Common.Constants;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace MDP.Common.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = ((ClaimsIdentity)claimsPrincipal.Identity!).Claims.Single(x => x.Type == ClaimConsts.UserId);
            return claim.Value;
        }

        public static string GetUserId(IHttpContextAccessor httpContextAccessor)
        {
            var claim = httpContextAccessor.HttpContext.User;
            return claim.GetUserId();
        }

        public static string GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
