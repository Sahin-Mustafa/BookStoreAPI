

using BookAPI.Domain.Entites;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.Application.Features.Queries.Book.GetAllBooks
{
    public class GetAllBookQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public List<string> AuthorsName { get; set; }
        public string Img { get; set; }
        public ushort UnitPrice { get; set; }

    }
}
