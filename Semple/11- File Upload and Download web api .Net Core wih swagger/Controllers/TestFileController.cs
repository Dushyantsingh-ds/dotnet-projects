using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.IO;
using System.Threading;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Hosting;

namespace FileUploadDownload.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TestFileController : ControllerBase
    {
        private static IWebHostEnvironment _webHostEnvironment;
        public TestFileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        private async Task<string> WriteFile(IFormFile file, string f_name)
        {
            string fileName = f_name;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = fileName + extension;
                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files");
                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files",
                   fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception e)
            {
            }
            return fileName;
        }


        [HttpPost]
        [Route("SaveFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(IFormFile file, string f_name, CancellationToken cancellationToken)
        {

            var result = await WriteFile(file, f_name);


            return Ok(result);
        }



        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(string NameFile)
        {
            // ... code for validation and get the file
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files",
                   NameFile);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
    }
}
