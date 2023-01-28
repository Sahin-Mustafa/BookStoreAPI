namespace BookAPI.Domain.Entites
{
    public class Comment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }

        //navigation properties
        public Customer Customer { get; set; }
        public Book Book{ get; set; }
    }
}
