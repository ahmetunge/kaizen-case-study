using Kaizen.CodeGenerator.Helpers;
using Kaizen.CodeGenerator.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.CodeGenerator.Models
{
    public class Coder
    {
        public Coder(int numberOfCodes, int codeLength)
        {
            NumberOfCodes = numberOfCodes;
            CodeLength = codeLength;
        }


        public int NumberOfCodes { get; set; } = 1;

        int minCodeLenth=8;

        private int codeLength;
        public int CodeLength
        {
            get { return codeLength; }
            set { codeLength = (value < minCodeLenth) ? minCodeLenth : value; }
        }


      
    }
}
