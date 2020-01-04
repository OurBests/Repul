using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Interfaces
{
    public interface IFileService
    {
        Task<byte[]> GetPathFile(string path);
    }
}
