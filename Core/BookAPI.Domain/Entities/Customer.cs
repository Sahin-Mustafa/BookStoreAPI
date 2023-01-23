using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Domain.Entites
{
    public class Customer
    {
        //bu entitiyleri diger katmanlara soyutaraka açaçacak katmana ihtiyacımız var (interface) bu da application katmanımız
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        
    }
    
}
