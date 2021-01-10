using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kaizen.Blog.Business.Interfaces
{
    public interface ITokenCreator
    {
        string CreateToken(Claim[] claims);
    }
}
