using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Entities
{
    public class User: BaseEntity, IEntity
    {
        public User()
        {
            Articles = new HashSet<Article>();
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
