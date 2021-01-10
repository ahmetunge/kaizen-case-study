using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Entities
{
    public class Category: BaseEntity, IEntity
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
