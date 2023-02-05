using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.Application.Features.Commands.Book.DeleteBook
{
    public class DeleteBookCommandRequest :IRequest<DeleteBookCommandResponse>
    {
        public int Id { get; set; }
        
    }
}
