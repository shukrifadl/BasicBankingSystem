using BankCore.Models;
using Microsoft.EntityFrameworkCore;
namespace BankEF
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {

        }
       public DbSet<Customer> Customers { get; set; }
       public DbSet<Transfer> Transfers { get; set; }
    }
}
