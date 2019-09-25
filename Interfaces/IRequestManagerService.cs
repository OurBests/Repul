using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Interfaces
{
    public interface IRequestManagerService
    {
        Task<object> Post(string route, object postObject);
        Task<T> Post<T>(string route, object postObject) where T : new();
    }
}
