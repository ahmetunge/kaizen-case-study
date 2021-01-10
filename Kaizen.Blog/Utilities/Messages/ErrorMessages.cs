using Kaizen.Blog.Dtos;
using Kaizen.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Utilities.Messages
{
    public static class ErrorMessages
    {
        public static string InternalServerError = "Internal server error";
        public static string EmailAlreadyExist="Email already exist";
        public static string EmailOrPasswordIncorrect = "Incorrect email or password";

        public static string NoAuthenticatedUser = "There is no authenticated user";
        public static string ArticleNotFound = "Article not found";

    }
}
