using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoLogin.Controllers
{
    public class UpLoadController : Controller
    {
        [HttpPost]
        public IActionResult UploadFile()
        {
            var files = Request.Form.Files;
            return Ok();
        }

        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var filePath = Path.GetTempFileName();
            foreach(var formFile in files)
            {
                if(formFile.Length > 0)
                {
                    using( var stream= new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { count = files.Count, size, filePath });
        }
    }
    
}