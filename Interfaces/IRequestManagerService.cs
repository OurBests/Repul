using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using web.Models;

namespace web.Interfaces
{
    public interface IRequestManagerService
    {
        Task<object> Post(string route, object postObject);
        Task<T> Post<T>(string route, object postObject);
        Task<byte[]> Get(string route);
        Task Post(string route, ServiceRequest reqModel, IFormFile image);
    }
}
