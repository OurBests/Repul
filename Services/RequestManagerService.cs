using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Common;
using web.Interfaces;
using web.Models;

namespace web.Services
{
    public class RequestManagerService : IRequestManagerService
    {
        private readonly ServiceConfiguration _serviceConfiguration;
        private readonly RestClient _client;
        public RequestManagerService(IOptionsMonitor<ServiceConfiguration> serviceConfiguration)
        {
            _serviceConfiguration = serviceConfiguration.CurrentValue;
            _client = new RestClient(_serviceConfiguration.ServiceUri);
        }
        public async Task<object> Post(string route, object postObject)
        {
            var r = new RestRequest(route, Method.POST, DataFormat.Json);
            r.AddJsonBody(postObject);
            var result = await Task.Run(() => _client.Execute(r));
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ManualException("خطا در بر قراری ارتباط با سرویس!");
            return JsonConvert.DeserializeObject(result.Content);
        }

        public async Task<T> Post<T>(string route, object postObject) where T : new()
        {
            var r = new RestRequest(route, Method.POST, DataFormat.Json);
            r.AddJsonBody(postObject);
            var result = await Task.Run(() => _client.Execute(r));
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ManualException("خطا در بر قراری ارتباط با سرویس!");
            return JsonConvert.DeserializeObject<T>(result.Content);
        }
    }
}
