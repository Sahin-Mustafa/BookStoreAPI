using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAPI.Domain.Entites
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public DateTime DeliveryDate { get; set; } = DateTime.Now;
        public string OrderStatus { get; set; }
        public string? WhoHasDelivered { get; set; }
        public string? RecipentIdNumber { get; set; }
        //navigation properties
        public Order Order { get; set; }
    }
}
