using System.Collections.Generic;
using TechSupportData.Models;

namespace TechSupportData.Repositories.Products
{
    public interface IProductsRepository
    {
        IList<Product> GetAllProductsByProductType(int productTypeId);

        void AddProduct(Product product);
    }
}