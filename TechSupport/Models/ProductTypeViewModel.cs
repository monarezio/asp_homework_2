using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechSupportData.Models;

namespace TechSupport.Models
{
    /// <summary>
    /// This class allows me to more freely choose how the API will return it's data
    /// </summary>
    public class ProductTypeViewModel
    {
        public readonly int productTypeId;
        public readonly string name;
        public readonly IList<ProductViewModel> products;

        private ProductTypeViewModel(int productTypeId, string name, IList<ProductViewModel> products)
        {
            this.productTypeId = productTypeId;
            this.name = name;
            this.products = products;
        }

        public static ProductTypeViewModel CreateFrom(ProductType productType)
        {
            IList<ProductViewModel> productViewModels;
            if (productType.Products == null)
                productViewModels = new List<ProductViewModel>();
            else
                productViewModels = productType.Products
                    .Select(ProductViewModel.CreateFrom)
                    .ToList(); //This removes the recursive link + makes the json "nicer"
            
            return new ProductTypeViewModel(productType.ProductTypeId, productType.Name, productViewModels);
        }
    }
}