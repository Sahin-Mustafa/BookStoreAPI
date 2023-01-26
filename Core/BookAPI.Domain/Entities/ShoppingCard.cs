namespace BookAPI.Domain.Entites
{
    public class ShoppingCard
    {
        public ShoppingCard()
        {
            BookShoppingCards=new List<BookShoppingCard>();
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public bool IsPay { get; set; }
        public ushort TotalPrice { get; set; }

        //navigation properties
        public Customer Customer { get; set; }
        public List<BookShoppingCard> BookShoppingCards { get; set; }
        public Order Order { get; set; }
    }
}
