using System.ComponentModel.DataAnnotations;

namespace BookAPI.Domain.Entites
{
    public class Category
    {
        public Category()
        {
            Books= new List<Book>();
        }
        public int Id { get; set; }
        public int BookId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }= DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        //navigation properties
        public List<Book> Books { get; set; }
    }
}
