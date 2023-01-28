using System.ComponentModel.DataAnnotations;

namespace BookAPI.Domain.Entites
{
    public class Book
    {
        public Book()
        {
            Authors = new List<Author>();
            Comments= new List<Comment>();
            BookShoppingCards= new List<BookShoppingCard>();
            BookImages = new List<BookImg>(); 
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        [MaxLength(60)]
        public string Publisher { get; set; }
        public ushort UnitPrice { get; set; }
        public ushort Stock { get; set; }
        
        public ushort? NumberOfPage { get; set; }
        public DateTime CreatedTime { get; set; }= DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsDelete { get; set; }

        //navigation properties
        public List<Author> Authors { get; set; }
        public List<BookImg> BookImages { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        public List<BookShoppingCard> BookShoppingCards { get; set; }
    }
}
