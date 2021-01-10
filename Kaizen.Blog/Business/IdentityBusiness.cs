using AutoMapper;
using Kaizen.Blog.Business.Interfaces;
using Kaizen.Blog.DataAccess.Interfaces;
using Kaizen.Blog.Dtos;
using Kaizen.Blog.Entities;
using Kaizen.Blog.Utilities.Messages;
using Kaizen.Blog.Utilities.Results;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kaizen.Blog.Business
{
    public class IdentityBusiness : IIdentityService
    {
        private readonly ITokenCreator _tokenCreator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public IdentityBusiness(ITokenCreator tokenCreator,IUserRepository userRepository,IMapper mapper, IUnitOfWork unitOfWork)
        {
            _tokenCreator = tokenCreator;
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<AuthResponseDto>> Login(UserLoginDto userLoginDto)
        {
            var user =await _userRepository
                .FindAsync(u => u.Email == userLoginDto.Email && u.Password == userLoginDto.Password);

            if (user == null)
            {
                return new ErrorDataResult<AuthResponseDto>(ErrorMessages.EmailOrPasswordIncorrect, HttpStatusCode.Conflict);
            }

            var authResponse = GetToken(user);

            return new SuccessDataResult<AuthResponseDto>(authResponse, HttpStatusCode.Created);
        }

        public async Task<IDataResult<AuthResponseDto>> Register(UserRegisterDto userRegister)
        {
            if(await IsUserExist(userRegister.Email))
            {
                return new ErrorDataResult<AuthResponseDto>(ErrorMessages.EmailAlreadyExist,HttpStatusCode.Conflict);
            }

            var user = _mapper.Map<User>(userRegister);

            _userRepository.Add(user);

           await _unitOfWork.CompleteAsync();

            var authResponse = GetToken(user);

            return new SuccessDataResult<AuthResponseDto>(authResponse,HttpStatusCode.Created);
        }

        public async Task<bool> IsUserExist(string email)
        {
            var user = await _userRepository.FindAsync(u => u.Email == email);

            return user == null ? false : true;
        }

        private AuthResponseDto GetToken(User user)
        {
            Claim[] claims = new[]
           {
               new Claim(JwtRegisteredClaimNames.Sub,user.Email),
               new Claim(JwtRegisteredClaimNames.Email, user.Email),
               new Claim("id", user.Id.ToString())
            };


            var token = _tokenCreator.CreateToken(claims);

            var authResponse = new AuthResponseDto { Token = token };

            return authResponse;
        }

        public async Task<bool> IsUserExist(int userId)
        {
            var user = await _userRepository.FindAsync(u => u.Id == userId);

            return user == null ? false : true;
        }
    }
}

