using Kaizen.Blog.Dtos;
using Kaizen.Blog.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Business.Interfaces
{
    public interface IIdentityService
    {
        Task<IDataResult<AuthResponseDto>> Register(UserRegisterDto userRegister);

        Task<IDataResult<AuthResponseDto>> Login(UserLoginDto userRegister);

        Task<bool> IsUserExist(int userId);
    }
}
