using FluentValidation;
using Kaizen.Blog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Utilities.Validation.FluentValidation
{
    public class ArticleValidator: AbstractValidator<ArticleToSaveDto>
    {
        public ArticleValidator()
        {
            RuleFor(c => c.CategoryId).GreaterThan(0);
            RuleFor(c => c.Title).MaximumLength(255);
            RuleFor(c => c.Content).NotEmpty().NotNull().MinimumLength(100);
        }
    }
}
