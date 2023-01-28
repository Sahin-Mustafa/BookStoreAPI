using System.ComponentModel.DataAnnotations;

namespace BookAPI.Domain.Entites
{
    public class Address
    {
        public Address()
        {
            Orders = new List<Order>();
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        public Int32? ZipCode { get; set; }

        [MaxLength(300)]
        public string AddressDetail { get; set; }
        public DateTime CreatedTime { get; set; }= DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsDelete { get; set; }

        //mavigation properties
        public Customer Customer { get; set; }
        public List<Order> Orders { get; set; }
    }
}
