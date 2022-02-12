using BankCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankCore.Interfaces
{
    public interface ICustomerRepo
    {

        Customer GetbyId(int Id);
        IEnumerable<Customer> GetAll();
        Customer Find(Expression<Func<Customer, bool>> expression, string[] includes = null);
        IEnumerable<Customer> FindAll(Expression<Func<Customer, bool>> expression, string[] includes = null);
        Customer Add(Customer entity);
        Customer Update(Customer entity);
        void Delete(int Id);
        int Count();        
        bool Transfer(int senderId, int receiverId, double amount);



    }
}
