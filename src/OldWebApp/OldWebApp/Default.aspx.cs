using OldWebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OldWebApp
{
    public partial class _Default : Page
    {
        
        public IQueryable MyGrid_GetData(string sortByExpression, int maximumRows, int startRowIndex, out int totalRowCount)
        {
            totalRowCount = GetCustomers().Count();
            return GetCustomers()
                .Skip(startRowIndex)
                .Take(maximumRows)
                .OrderBy(GetCustomerSortExpression(sortByExpression));
        }

        private static IQueryable<Customer> GetCustomers()
        {
            return new[]
            {
                new Customer(0, "Dani", "Michele"), new Customer(1, "Elissa", "Malone"), new Customer(2, "Raine", "Damian"),
                new Customer(3, "Gerrard", "Petra"), new Customer(4, "Clement", "Ernie"), new Customer(5, "Rod", "Fred"),
                new Customer(6, "Oliver", "Carr"), new Customer(7, "Jackson", "James"), new Customer(8, "Dexter", "Nicholson"),
                new Customer(9, "Jamie", "Rees"), new Customer(10, "Jackson", "Ross"), new Customer(11, "Alonso", "Sims"),
                new Customer(12, "Zander", "Britt"), new Customer(13, "Isaias", "Ford"), new Customer(14, "Braden", "Huffman"),
                new Customer(15, "Frederick", "Simpson"), new Customer(16, "Charlie", "Andrews"), new Customer(17, "Reuben", "Byrne")
            }.AsQueryable();
        }

        private static Expression<Func<Customer, object>> GetCustomerSortExpression(string sortByExpression)
        {
            Expression<Func<Customer, object>> sortBy;
            switch (sortByExpression)
            {
                case nameof(Customer.FirstName):
                    sortBy = c => c.FirstName;
                    break;
                case nameof(Customer.LastName):
                    sortBy = c => c.LastName;
                    break;
                default:
                case nameof(Customer.Id):
                    sortBy = c => c.Id;
                    break;
            }

            return sortBy;
        }
    }
}