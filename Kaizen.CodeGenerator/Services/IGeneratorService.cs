using Kaizen.CodeGenerator.Models;
using Kaizen.CodeGenerator.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.CodeGenerator.Services
{
    public interface IGeneratorService
    {
        List<string> GenerateCode(Coder coder);
        bool ValidateCode(string code);
    }
}
