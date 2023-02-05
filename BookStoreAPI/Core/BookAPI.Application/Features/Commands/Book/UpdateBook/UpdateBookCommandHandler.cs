using B = BookAPI.Domain.Entites;
using BookAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Application.Features.Commands.Book.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>
    {
        private IBookReadRepository bookReadRepository;
        private IBookWriteRepository bookWriteRepository;

        public UpdateBookCommandHandler(IBookWriteRepository bookWriteRepository, IBookReadRepository bookReadRepository)
        {
            this.bookWriteRepository = bookWriteRepository;
            this.bookReadRepository = bookReadRepository;
        }

        public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            B.Book book = bookReadRepository.GetWhere(x => x.Id == request.Id).Include(x => x.Category).Include(x => x.Authors).FirstOrDefault();
            if (book == null)
            {
                book.CategoryId=request.CategoryId;
                book.Name=request.Name;
                book.PublishDate=request.PublishDate;
                book.Publisher=request.Publisher;
                book.UnitPrice=request.UnitPrice;
                book.Stock=request.Stock;
                book.NumberOfPage=request.NumberOfPage;
                book.ModifiedDate=request.ModifiedDate;
                book.IsDelete = request.IsDelete;
                List<int> authorsId = book.Authors.Select(author => author.Id).ToList<int>();
                for (int i = 0; i < request.AuthorsId.Count; i++)
                {
                    authorsId[i] = request.AuthorsId[i];
                }
                await bookWriteRepository.SaveAsync();
                return new()
                {
                    Success = true
                };
            }
            return new();
        }
    }
}
