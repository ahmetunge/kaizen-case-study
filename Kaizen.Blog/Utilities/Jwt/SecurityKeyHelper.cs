using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Blog.Utilities.Jwt
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurity(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));
        }
    }
}
