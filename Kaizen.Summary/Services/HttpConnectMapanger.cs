using Kaizen.Summary.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Summary.Services
{
    public class HttpConnectMapanger : IHttpConnectService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpConnectMapanger(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> PostData(HttpRequestBase requestBase,string clientName)
        {
            var client = _httpClientFactory.CreateClient(clientName);

            var data = new StringContent(JsonConvert.SerializeObject(requestBase, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), Encoding.UTF8, "application/json");

            using var httpResponse = await client.PostAsync("", data);

            httpResponse.EnsureSuccessStatusCode();

            if (httpResponse.IsSuccessStatusCode)
            {
                var responseResult = await httpResponse.Content.ReadAsStringAsync();


               return  responseResult;
            }

            return null;

        }
    }
}
