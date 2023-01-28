using BookAPI.Application.Services;
using BookAPI.Persistance.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BookAPI.Persistance.Concretes.FileService
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        private string FileRename(string path,string fileName)
        {
            string oldName = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string newFileName = $"{NameService.CharacterRegulatory(oldName)}{extension}";
            bool fileIsExists = false;
            int fileIndex = 0;
            do
            {
                if (File.Exists($"{path}\\{newFileName}"))
                {
                    fileIsExists = true;
                    fileIndex++;
                    newFileName = $"{NameService.CharacterRegulatory(oldName + "-" + fileIndex)}{extension}";
                }
                else
                {
                    fileIsExists = false;
                }
            } while (fileIsExists);

            return newFileName;
        }
        public bool CopyFile(string path, IFormFile file)
        {
            try
            {
                using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            catch (Exception)
            {
                //todo log
                return false;
            }
            return true;
        }

        public List<string> Upload(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<string> datas = new();
            List<bool> results = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = FileRename(uploadPath,file.FileName);
                bool result = CopyFile($"{uploadPath}\\{fileNewName}", file);
                datas.Add($"{uploadPath}\\{fileNewName}");
                results.Add(result);
                
            }

            if (results.TrueForAll(r => r.Equals(true)))
                return datas;

            //false varsa dosyanının yazılamadığını döndüren hata fırlatılacak
            return null;
        }
    }
}
