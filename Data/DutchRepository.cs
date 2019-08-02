using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext context;
        private readonly ILogger<DutchRepository> logger;

        public DutchRepository(DutchContext context, ILogger<DutchRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public void AddEntity(object model)
        {
            context.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            // do if includeitems has been set to true.
            if (includeItems)
            {
                return context.Orders
                              .Include(o => o.Items)
                              .ThenInclude(i => i.Product)
                              .ToList();
            }
            else
            {
                return context.Orders
                              .ToList();    //exclude the include items
            }

        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                logger.LogInformation("Get All products was called.");

                return from p in context.Products
                       orderby p.Title
                       select p;
            }
            catch(Exception ex)
            {
                logger.LogError($"Failed to get all products: {ex}");
                return null;
            }

        }

        public Order GetOrderById(int id)
        {
            return context.Orders
                   .Include(o => o.Items)
                   .ThenInclude(i => i.Product)
                   .Where(o => o.Id == id)
                   .FirstOrDefault();

        }

        public IEnumerable<Product> GetProductByCategory(string category)
        {
            return from p in context.Products
                   where p.Category.StartsWith(category) || string.IsNullOrEmpty(category)
                   select p;

        }

        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }
    }
}
