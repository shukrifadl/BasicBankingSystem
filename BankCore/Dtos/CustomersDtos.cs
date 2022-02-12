using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCore.Dtos
{
    public class AddCustomerDto
    {
        [Required, StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required, StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required, EmailAddress, StringLength(50)]
        public string Email { get; set; }
        [Required]
        public double Balance { get; set; }
    }
}