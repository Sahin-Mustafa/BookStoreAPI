using BookAPI.Application.Repositories;
using BookAPI.Application.Services;
using BookAPI.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IBookWriteRepository _bookWriteRepository;
        public BookController(IBookWriteRepository bookWriteRepository, IBookReadRepository bookReadRepository, IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            _bookWriteRepository = bookWriteRepository;
            _bookReadRepository = bookReadRepository;
            _fileService = fileService;
        }

        [HttpPut("{id}/[action]")]
        public  IActionResult UploadImg(int id)
        {
            List<string> paths =_fileService.Upload("resource/book-images", Request.Form.Files);
            Book book = _bookReadRepository.GetById(id);
            foreach (string path in paths)
            {
                book.BookImages.Add(new() {Path=path});
            }
            _bookWriteRepository.Update(book);
            _bookWriteRepository.Save();
            return Ok();
        }
    }
}
