using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.Application.Features.Commands.Book.UpdateBook
{
    public class UpdateBookCommandRequest : IRequest<UpdateBookCommandResponse>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public List<int> AuthorsId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }

        [MaxLength(60)]
        public string Publisher { get; set; }
        public ushort UnitPrice { get; set; }
        public ushort Stock { get; set; }
        public ushort? NumberOfPage { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; }
    }
      
}
