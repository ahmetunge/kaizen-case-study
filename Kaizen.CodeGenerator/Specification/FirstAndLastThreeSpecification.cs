using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.CodeGenerator.Specification
{
    public class FirstAndLastThreeSpecification : ISpecification<SpecificationParams>
    {

        public bool IsSatisfiedBy(SpecificationParams entity)
        {
            return entity.FirstThreeChars == 5771 && entity.LastThreeChars == 5778;
        }
    }
}
