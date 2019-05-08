using System.Collections.Generic;
using TechSupportData.Models;

namespace TechSupportData.Repositories.ProductTypes
{
    public interface IProductTypesRepository
    {
        IList<ProductType> GetAllProductTypes();

        ProductType GetDetail(int id);
    }
}