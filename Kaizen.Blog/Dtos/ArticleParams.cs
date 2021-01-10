using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Dtos
{
    public class ArticleParams:Params
    {
        public int? CategoryId { get; set; }
        public string Title { get; set; }

        public string SortBy { get; set; }
    }
}
