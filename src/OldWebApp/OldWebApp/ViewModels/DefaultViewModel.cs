using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using OldWebApp.Model;

namespace OldWebApp.ViewModels
{
    public class DefaultViewModel : SiteViewModel
    {
        public override string Title => "Home Page";


        public GridViewDataSet<Customer> Customers { get; set; } = new GridViewDataSet<Customer>()
        {
            PagingOptions =
            {
                PageSize = 10
            },
            SortingOptions =
            {
                SortExpression = nameof(Customer.Id)
            }
        };


        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetCustomers());
            }

            return base.PreRender();
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
    }
}

