using AutoMapper;
using Kaizen.Blog.Dtos;
using Kaizen.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Business.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ArticleToSaveDto, Article>();
            CreateMap<UserRegisterDto, User>();
        }
    }
}
