using B=BookAPI.Domain.Entites;


namespace BookAPI.Application.Features.Commands.Book.CreateBook
{
    public class CreateBookCommandResponse
    {
        public B.Book Book { get; set; }
        
    }
}
