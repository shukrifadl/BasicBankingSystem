using BankCore.Interfaces;
using BankCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BankEF.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly BankDbContext Context;

        public CustomerRepo(BankDbContext context)
        {
            Context = context;
        }

        public Customer Add(Customer entity)
        {
            var res = Context.Add(entity);
            Context.SaveChanges();
            return res.Entity;
        }

        public int Count()
        {
           return Context.Customers.Count();
        }

        public void Delete(int Id)
        {
            var entity = GetbyId(Id);
            Context.Customers.Remove(entity);
            Context.SaveChanges();
            
        }

        public IEnumerable<Customer> FindAll(Expression<Func<Customer, bool>> expression, string[] includes = null)
        {
            var query = Context.Customers;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }
            return query.Where(expression).ToList();
        }

        public Customer Find(Expression<Func<Customer, bool>> expression, string[] includes = null)
        {
            var query = Context.Customers;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }
            return query.Find(expression);
        }

        public  IEnumerable<Customer> GetAll()
        {
            return  Context.Customers.ToList();
        }

        public Customer GetbyId(int Id)
        {
            return  Context.Customers.Find(Id);
        }

        public  bool Transfer(int senderId, int receiverId, double amount)
        {
            var transaction = Context.Database.BeginTransaction();

            var sender = Context.Customers.Find(senderId);
            var reciever = Context.Customers.Find(receiverId);
            if (sender.Balance <amount )
            {
                return false;
            }
            sender.Balance-=amount;
            reciever.Balance+=amount;
            
             Context.Transfers.Add(new Transfer 
            { Sender = sender, Reciever = reciever, Amount = amount, DateTime = DateTime.Now });

            transaction.Commit();
            Context.SaveChanges();
            return true;
        }

        public Customer Update(Customer entity)
        {
            var res=Context.Customers.Update(entity);
            Context.SaveChanges();
            return res.Entity;            
        }
    }
}
