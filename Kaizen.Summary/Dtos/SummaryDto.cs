using Kaizen.Summary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Summary.Dtos
{
    public class SummaryDto: HttpRequestBase
    {
        public string ContextOfText { get; set; }
    }
}
