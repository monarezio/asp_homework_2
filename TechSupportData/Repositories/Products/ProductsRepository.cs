using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechSupportData.Models;

namespace TechSupportData.Repositories.Products
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly TechSupportDbContext _dbContext;

        public ProductsRepository(TechSupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Product> GetAllProductsByProductType(int productTypeId)
        {
            return _dbContext.Products
                .Where(i => i.ProductId == productTypeId)
                .ToList();
        }

        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }
    }
}