using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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

        public async Task<T> Post<T>(string route, object postObject)
        {
            var r = new RestRequest(route, Method.POST, DataFormat.Json);
            r.AddJsonBody(postObject);
            var result = await Task.Run(() => _client.Execute(r));
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ManualException("خطا در بر قراری ارتباط با سرویس!");
            return JsonConvert.DeserializeObject<T>(result.Content);
        }
        public async Task<byte[]> Get(string route)
        {
            var r = new RestRequest(route, Method.GET);
            var result = await Task.Run(() => _client.Execute(r));
            return result.RawBytes;
        }

        public async Task Post(string route, ServiceRequest reqModel, IFormFile file)
        {
            var r = new RestRequest(route, Method.POST, DataFormat.Json);

            var stream = file.OpenReadStream();
            var bytes = new byte[stream.Length];
            using (var ms = new MemoryStream())
            {
                await stream.CopyToAsync(ms);
                bytes = ms.ToArray();
            }
            r.AddFile("MyFile", bytes, file.FileName, file.ContentType);
            r.AddObject(reqModel);
            var result = await Task.Run(() => _client.Execute(r));
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ManualException("خطا در بر قراری ارتباط با سرویس!");
        }
    }
}
