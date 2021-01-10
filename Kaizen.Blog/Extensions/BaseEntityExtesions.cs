using Kaizen.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Extensions
{
    public static class BaseEntityExtesions
    {
        public static void SetDateTime(this BaseEntity baseEntity)
        {
            if (baseEntity.Id > 0)
            {
                baseEntity.UpdateTime = DateTime.Now;
            }
            else
            {
                baseEntity.InsertTime = DateTime.Now;
            }
        }
    }
}
