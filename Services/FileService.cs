using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Interfaces;
using web.Models;

namespace web.Services
{
    public class FileService : IFileService
    {
        private readonly IRequestManagerService _requestManagerService;
        public FileService(IRequestManagerService requestManagerService)
        {
            _requestManagerService = requestManagerService;
        }
        public async Task<byte[]> GetPathFile(string path)
        {
            var result = await _requestManagerService.Get("/Files?file=" + (path.StartsWith("/") ? path.Remove(0, 1) : path));
            return result;
        }
    }
}
