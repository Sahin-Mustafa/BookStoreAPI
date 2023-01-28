using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Services
{
    public interface IFileService
    {
        List<string> Upload(string path, IFormFileCollection files);
        bool CopyFile(string path,IFormFile file);
    }
}
