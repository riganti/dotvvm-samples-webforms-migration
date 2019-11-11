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
        private readonly AppDbContext dc;

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

        public DefaultViewModel(AppDbContext dc)
        {
            this.dc = dc;
        }

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(dc.Customers);
            }

            return base.PreRender();
        }
    }
}

