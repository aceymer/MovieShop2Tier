using MovieShopDAL.Context;
using MovieShopDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repository
{
    public class CustomerRepository
    {
        public List<Customer> ReadAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Customers.ToList();
            }
        }

        public void Add(Customer customer)
        {
            using (var ctx = new MovieShopContext())
            {
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }
        }


        public Customer FindCustomer(int customerId)
        {
            foreach (var item in ReadAll())
            {
                if (item.Id == customerId)
                {
                    return item;
                }

            }
            return null;
        }

        public void Update(Customer customer)
        {
            using (var ctx = new MovieShopContext())
            {
                foreach (var movieDB in ctx.Customers.ToList())
                {
                    if (customer.Id == movieDB.Id)
                    {
                        movieDB.Name = customer.Name;
                        movieDB.Email = customer.Email;
                        movieDB.Password = customer.Password;
                        ctx.SaveChanges();

                    }
                }
            }


        }
        public void Delete(int customerId)
        {
            Customer customer = FindCustomer(customerId);

            {
                using (var ctx = new MovieShopContext())
                {
                    ctx.Customers.Attach(customer);
                    ctx.Customers.Remove(customer);
                    ctx.SaveChanges();
                }
            }
        }
    }
    
}
