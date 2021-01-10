using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime? UpdateTime { get; set; }


        public DateTime InsertTime { get; set; }

        
    }
}
