using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Features.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryResponse
    {
        public int Id { get; set; }      
        public string? Fullname { get; set; }       
        public string Email { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
