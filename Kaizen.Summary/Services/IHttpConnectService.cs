using Kaizen.Summary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Summary.Services
{
    public interface IHttpConnectService
    {
        Task<string> PostData(HttpRequestBase requestBase,string clientName);
    }
}
