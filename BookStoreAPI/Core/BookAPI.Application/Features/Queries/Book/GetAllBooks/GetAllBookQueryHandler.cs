using B = BookAPI.Domain.Entites;
using BookAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Application.Features.Queries.Book.GetAllBooks
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQueryRequest, List<GetAllBookQueryResponse>>
    {
        private IBookReadRepository bookReadRepository;

        public GetAllBookQueryHandler(IBookReadRepository bookReadRepository)
        {
            this.bookReadRepository = bookReadRepository;
        }

        public async Task<List<GetAllBookQueryResponse>> Handle(GetAllBookQueryRequest request, CancellationToken cancellationToken)
        {
            List<B.Book> books = bookReadRepository.GetAll().Include(x=>x.Authors).Include(x=>x.Category).Include(x=>x.BookImages).ToList();
            List<GetAllBookQueryResponse> responses = new();
            foreach (B.Book book in books) 
            {
                responses.Add(
                    new GetAllBookQueryResponse 
                    {
                        Id=book.Id,
                        Name= book.Name,
                        CategoryName=book.Category.Name,
                        AuthorsName=book.Authors.Where(author=>author.Books.Any(x=>x.Id==book.Id)).Select(x=>$"{x.Name} {x.Surname}").ToList<string>(),
                        Img=book.BookImages.FirstOrDefault()?.Path,
                        UnitPrice=book.UnitPrice,
                    }
                    );
            }
            return responses;
        }
    }
}
/*
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public string Img { get; set; }
        public ushort UnitPrice { get; set; } 
all ımages =Img=book.BookImages.Where(x=>x.BookId==book.Id).Select(x=>x.Path).ToList<string>(),
 */