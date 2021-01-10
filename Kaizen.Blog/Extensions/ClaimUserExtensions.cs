using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Kaizen.Blog.Extensions
{
    public static class ClaimUserExtensions
    {
        public static int? GetAuthenticatedUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                return null;

            if (claimsPrincipal.FindFirst("id") == null)
                return null;

            var userId = claimsPrincipal.FindFirst("id").Value;

            return int.Parse(userId);
        }
    }
}
