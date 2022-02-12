
using BankCore.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankCore.Dtos { 
    public class TransferViewModel
    {
        [Required]
        public Customer Sender { get; set; }
        public int ReceiverId { get; set; }
        public IEnumerable<Customer> Receivers { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
