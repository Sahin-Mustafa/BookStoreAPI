using B = BookAPI.Domain.Entites;
using MediatR;

namespace BookAPI.Application.Features.Commands.Book.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommandRequest, CreateBookCommandResponse>
    {
        
        public async Task<CreateBookCommandResponse> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            //get author
            B.Book book = new() 
            {
                CategoryId=request.CategoryId,
                Name=request.Name,
                PublishDate=request.PublishDate,
                UnitPrice=request.UnitPrice,
                Stock=request.Stock,
                NumberOfPage=request.NumberOfPage,
                //add author 
            };
            return new() {Book=book};
        }
    }
}
