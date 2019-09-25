using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class ServiceResponse<T>
    {
        public int Code { get; set; }
        public object Data { get; set; }
        public T DataModel
        {
            get
            {
                try
                {
                    if (Data == null) return default;
                    if (Data is string)
                        return JsonConvert.DeserializeObject<T>(Data.ToString());
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(Data));
                }
                catch (Exception)
                {
                    return default;
                }
            }
        }
    }
}
