using BookAPI.Application.Features.Commands.Book.CreateBook;
using BookAPI.Application.Features.Commands.Book.DeleteBook;
using BookAPI.Application.Features.Commands.Book.UpdateBook;
using BookAPI.Application.Features.Queries.Book.GetAllBooks;
using BookAPI.Application.Repositories;
using BookAPI.Application.Services;
using BookAPI.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace BookAPI.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    //[Authorize(AuthenticationSchemes ="admin")]
    public class BookController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IBookWriteRepository bookWriteRepository;
        readonly IMediator mediator;
        public BookController(IBookWriteRepository bookWriteRepository, IWebHostEnvironment webHostEnvironment, IFileService fileService, IMediator mediator)
        {
            bookWriteRepository = bookWriteRepository;
            _fileService = fileService;
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery] GetAllBookQueryRequest getAllBookQueryRequest)
        {
            return Ok(await mediator.Send(getAllBookQueryRequest));
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateBookCommandRequest createBookCommandRequest)
        {
            if (Request.Form.Files != null && Request.Form.Files.Count > 0)
            {
                CreateBookCommandResponse createBookCommandResponse = await mediator.Send(createBookCommandRequest);

                return await UploadImg(createBookCommandResponse.Book, Request.Form.Files);
            }
            return BadRequest();
        }

        private async Task<IActionResult> UploadImg(Book book,IFormFileCollection file)
        {
            List<string> paths =_fileService.Upload("resource/book-images", file);
            foreach (string path in paths)
            {
                book.BookImages.Add(new() {Path=path});
            }
            await bookWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBookCommandRequest deleteBookCommandRequest)
        {
            DeleteBookCommandResponse response = await mediator.Send(deleteBookCommandRequest);
            return response.Success?  Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateBookCommandRequest updateBookCommandRequest)
        {
            UpdateBookCommandResponse response = await mediator.Send(updateBookCommandRequest);
            return response.Success?  Ok(response) : BadRequest(response);
        }



    }
}
