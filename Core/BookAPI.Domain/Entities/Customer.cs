using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Domain.Entites
{
    public class Customer
    {
        //bu entitiyleri diger katmanlara soyutaraka açaçacak katmana ihtiyacımız var (interface) bu da application katmanımız
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Fullname { get; set; }
        [MaxLength(60)]
        public string Email { get; set; }
        [MinLength(8),MaxLength(16)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        public DateTime CreatedTime { get; set; }= DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsDelete { get; set; }

        //mavigation properties
        public List<Address> Addresses { get; set; }
        public List<ShoppingCard> ShoppingCards { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
