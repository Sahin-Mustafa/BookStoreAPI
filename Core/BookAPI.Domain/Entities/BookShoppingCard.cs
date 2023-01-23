namespace BookAPI.Domain.Entites
{
    public class BookShoppingCard
    {
        public int BookId { get; set; }
        public int ShoppingCardId { get; set; }
        public byte Piece { get; set; } = 1;
        public ushort price { get; set; }

        //navigation properties
        public ShoppingCard ShoppingCard { get; set; }
        public Book Book { get; set; }
    }
}
