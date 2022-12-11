using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.Utilities
{
    public static class FileHelper
    {
        public static string UploadImage(IWebHostEnvironment webHostEnvironment,IFormFile file, string folderName)
        {
            string uniqueFilename = "";
            var folderPath = Path.Combine(webHostEnvironment.WebRootPath, folderName);
            uniqueFilename = Guid.NewGuid() + "_" + file.FileName;
            var filePath = Path.Combine(folderPath, uniqueFilename);

            using (var fileStream = System.IO.File.Create(filePath))
            {
                file.CopyTo(fileStream);
            }
            return uniqueFilename;
        }
    }
}
