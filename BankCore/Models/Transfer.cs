﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCore.Models
{
    public class Transfer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public Customer Sender { get; set; }
        [Required]
        public Customer Reciever { get; set; }

    }
}
