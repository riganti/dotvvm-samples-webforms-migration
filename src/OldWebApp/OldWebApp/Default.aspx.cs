using OldWebApp.Model;
using System;
using System.CodeDom;
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
        private AppDbContext dc;

        public _Default()
        {
            dc = new AppDbContext();
        }

        public IQueryable MyGrid_GetData(string sortByExpression, int maximumRows, int startRowIndex, out int totalRowCount)
        {
            totalRowCount = dc.Customers.Count();

            if (string.IsNullOrEmpty(sortByExpression))
            {
                sortByExpression = nameof(Customer.Id);
            }

            return dc.Customers
                .SortBy(sortByExpression)
                .Skip(startRowIndex)
                .Take(maximumRows);
        }

        public override void Dispose()
        {
            dc.Dispose();
            base.Dispose();
        }
            
    }
}