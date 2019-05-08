using TechSupportData.Models;

namespace TechSupport.Models
{
    public class ProductViewModel
    {
        public readonly int productId;
        public readonly string name;

        private ProductViewModel(int productId, string name)
        {
            this.productId = productId;
            this.name = name;
        }

        public static ProductViewModel CreateFrom(Product product)
        {
            return new ProductViewModel(product.ProductId, product.Name);
        }
    }
}