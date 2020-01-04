using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Interfaces;

namespace web.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        public async Task<IActionResult> Image([FromQuery] string path)
        {
            var file = await _fileService.GetPathFile(path);
            return File(file, "image/jpg");
        }
    }
}