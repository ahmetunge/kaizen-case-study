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
    public class FakeCodeGenerator : IGeneratorService
    {
        private readonly IKeyValueLetters _keyValueLetters;

        public FakeCodeGenerator(IKeyValueLetters keyValueLetters)
        {
            _keyValueLetters = keyValueLetters;
        }
        public List<string> GenerateCode(Coder coder)
        {
            List<string> allCodes = new();
            var letterWithValues = _keyValueLetters.GetKeyValueLetters();
            int count = letterWithValues.Count;

            for (int j = 0; j < coder.NumberOfCodes; j++)
            {
                string code = "";

                for (int i = 0; i < coder.CodeLength; i++)
                {
                    var randomElement = letterWithValues.GetRandomElement(count);

                    code = code + ($"{randomElement.character}");

                }
                Console.WriteLine(code);
                allCodes.Add(code);
            }

            Console.WriteLine("Completed");

            return allCodes;
        }

        public bool ValidateCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
