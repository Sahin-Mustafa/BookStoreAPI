using MediatR;

namespace BookAPI.Application.Features.Commands.Book.CreateBook
{
    public class CreateBookCommandRequest : IRequest<CreateBookCommandResponse>
    {
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string Publisher { get; set; }
        public ushort UnitPrice { get; set; }
        public ushort Stock { get; set; }
        public ushort? NumberOfPage { get; set; }
    }
}
