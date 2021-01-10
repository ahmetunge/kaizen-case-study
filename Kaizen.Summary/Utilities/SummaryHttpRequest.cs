using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Summary.Utilities
{
    public class SummaryHttpRequest : HttpRequestBase
    {
        public string ContextOfText { get; set; }
    }
}
