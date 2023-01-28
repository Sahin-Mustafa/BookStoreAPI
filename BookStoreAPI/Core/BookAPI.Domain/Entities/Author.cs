using System.ComponentModel.DataAnnotations;

namespace BookAPI.Domain.Entites
{
    public class Author
    {
        public Author()
        {
            Books= new List<Book>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(60)]
        public string? Email { get; set; }
        //navigation properties
        public List<Book> Books { get; set; }

    }
}
