using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechSupport.Models;
using TechSupportData.Models;
using TechSupportData.Repositories.Products;
using TechSupportData.Repositories.ProductTypes;

namespace TechSupport.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : Controller
    {
        private readonly IProductTypesRepository _productTypesRepository;

        public ProductTypesController(IProductTypesRepository productTypesRepository)
        {
            _productTypesRepository = productTypesRepository;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            IList<ProductTypeViewModel> productTypeViewModels = _productTypesRepository
                .GetAllProductTypes()
                .Select(ProductTypeViewModel.CreateFrom)
                .ToList();

            return Json(productTypeViewModels);
        }

        [HttpGet("{id}")]
        public JsonResult GetDetail(int id)
        {
            ProductType productType = _productTypesRepository.GetDetail(id);

            return Json(
                ProductTypeViewModel.CreateFrom(productType)
            );
        }
    }
}