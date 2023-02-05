using MediatR;

namespace BookAPI.Application.Features.Queries.Book.GetAllBooks
{
    public class GetAllBookQueryRequest : IRequest<List<GetAllBookQueryResponse>>
    {
        //This place is empty as all books are requested
    }

}
