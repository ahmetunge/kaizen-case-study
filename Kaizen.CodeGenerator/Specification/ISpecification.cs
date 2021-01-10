using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.CodeGenerator.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
