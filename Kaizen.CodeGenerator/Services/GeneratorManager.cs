using Kaizen.CodeGenerator.Extensions;
using Kaizen.CodeGenerator.Helpers;
using Kaizen.CodeGenerator.Models;
using Kaizen.CodeGenerator.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.CodeGenerator.Services
{
    public class GeneratorManager : IGeneratorService
    {
        private readonly ISpecification<SpecificationParams> _specification;
        private readonly IKeyValueLetters _keyValueLetters;

        public GeneratorManager(IKeyValueLetters keyValueLetters, ISpecification<SpecificationParams> specification)
        {
            _keyValueLetters = keyValueLetters;
            _specification = specification;
        }
        public List<string> GenerateCode(Coder coder)
        {
            List<string> allCodes = new();
            var letterWithValues = _keyValueLetters.GetKeyValueLetters();
            int count = letterWithValues.Count;

            for (int j = 0; j < coder.NumberOfCodes; j++)
            {
                int sumOfFirstThreeChar = 0;
                int sumOfLastThreeChar = 0;

                string code = "";

                for (int i = 0; i < coder.CodeLength; i++)
                {
                    var randomElement = letterWithValues.GetRandomElement(count);
                    if (i < 3)
                    {
                        sumOfFirstThreeChar = sumOfFirstThreeChar + randomElement.value;
                    }
                    else if (i > coder.CodeLength-4 && i < coder.CodeLength)
                    {
                        sumOfLastThreeChar = sumOfLastThreeChar + randomElement.value;
                    }
                    code = code + ($"{randomElement.character}");
                    
                }

                SpecificationParams chars = new SpecificationParams
                {
                    FirstThreeChars = sumOfFirstThreeChar,
                    LastThreeChars = sumOfLastThreeChar
                };

                if (_specification.IsSatisfiedBy(chars))
                {
                    allCodes.Add(code);
                }
                else
                {
                    j = j - 1;
                }

            }
            return allCodes;
        }

        public bool ValidateCode(string code)
        {
            int sumOfFirstThreeChar = 0;
            int sumOfLastThreeChar = 0;
            var letterWithValues = _keyValueLetters.GetKeyValueLetters();
            for (int i = 0; i < code.Length; i++)
            {
                int value;
                var codeChar = code[i].ToString();

                if (!letterWithValues.TryGetValue(codeChar,out value))
                {
                    return false;
                }

                if (i < 3)
                {
                    sumOfFirstThreeChar = sumOfFirstThreeChar + value;
                }
                else if (i > 4 && i < 8)
                {
                    sumOfLastThreeChar = sumOfLastThreeChar + value;
                }
            }
            SpecificationParams chars = new SpecificationParams
            {
                FirstThreeChars = sumOfFirstThreeChar,
                LastThreeChars = sumOfLastThreeChar
            };

            if (_specification.IsSatisfiedBy(chars))
            {
                return true;
            }

            return false;
        }
    }
}
