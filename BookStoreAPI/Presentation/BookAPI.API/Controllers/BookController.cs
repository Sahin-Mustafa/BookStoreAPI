using BookAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IBookWriteRepository _bookWriteRepository;
        public BookController(IBookWriteRepository bookWriteRepository, IBookReadRepository bookReadRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookWriteRepository = bookWriteRepository;
            _bookReadRepository = bookReadRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("[action]")]
        public  IActionResult Upload()
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/image");
            if(!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            foreach (IFormFile file in Request.Form.Files)
            {
                string fullPath = Path.Combine(uploadPath, file.FileName);
                using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024*1024,useAsync:false);
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return Ok();
        }
    }
}
