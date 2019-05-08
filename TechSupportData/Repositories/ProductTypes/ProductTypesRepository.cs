using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechSupportData.Models;

namespace TechSupportData.Repositories.ProductTypes
{
    public class ProductTypesRepository : IProductTypesRepository
    {
        private readonly TechSupportDbContext _dbContext;

        public ProductTypesRepository(TechSupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Models.ProductType> GetAllProductTypes()
        {
            return _dbContext.ProductTypes.ToList();
        }

        public ProductType GetDetail(int id)
        {
            return _dbContext.ProductTypes
                .Include(i => i.Products)
                .First(i => i.ProductTypeId == id);
        }
    }
}