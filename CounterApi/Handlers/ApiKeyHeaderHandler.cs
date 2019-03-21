using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using CounterApi.Models;

namespace CounterApi.Handlers
{
   
    public class ApiKeyHeaderHandler : DelegatingHandler
    {
       

        public const string _apiKeyHeader = "X-Api-Key";
        public const string _apiQueryString = "api_key";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var context = new ApplicationContext();
            var apiKeyInDb = context.XApiKeys.SingleOrDefault(a => a.Id == 1);
            string apiKey = null;
            if (request.Headers.Contains(_apiKeyHeader))
                apiKey = request.Headers.GetValues(_apiKeyHeader).SingleOrDefault();

            else
            {
                var queryString = request.GetQueryNameValuePairs();
                var keyValueInPairs = queryString.FirstOrDefault(k => k.Key.ToLowerInvariant().Equals(queryString));

                if (!string.IsNullOrEmpty(keyValueInPairs.Value))
                    apiKey = keyValueInPairs.Value;
            }

            if (string.IsNullOrEmpty(apiKey))
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Missing API Key")
                };
                return Task.FromResult(response);
            }

            if (apiKey != apiKeyInDb.ApiKey)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("API Key is invalid")
                };
                return Task.FromResult(response);
            }

            request.Properties.Add(_apiKeyHeader, apiKey);
            return base.SendAsync(request, cancellationToken);
        }
    }
}