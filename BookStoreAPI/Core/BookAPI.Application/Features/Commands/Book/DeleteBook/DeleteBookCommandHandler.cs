using BookAPI.Application.Repositories;
using B=BookAPI.Domain.Entites;
using MediatR;

namespace BookAPI.Application.Features.Commands.Book.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommandRequest, DeleteBookCommandResponse>
    {
        
        private IBookWriteRepository bookWriteRepository;

        public DeleteBookCommandHandler(IBookWriteRepository bookWriteRepository)
        {
            this.bookWriteRepository = bookWriteRepository;
            
        }

        public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            bool result =await bookWriteRepository.DeleteByIdAsync(request.Id);
            if (result)
            {
                await bookWriteRepository.SaveAsync();
                return new() { Success=true};
            }
            return new();
        }
    }
}
