using System.ComponentModel.DataAnnotations;

namespace BookAPI.Domain.Entites
{
    public class BookImg
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        [MaxLength(500)]
        public string Path { get; set; }
        public Book Book { get; set; }
    } 
}
