using Microsoft.AspNetCore.Mvc;
using PManage.Application.DTOs;
using PManage.Application.Interfaces;

namespace PManage.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateProductDto createProductDto)
        {
            _productService.CreateProduct(createProductDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            _productService.UpdateProduct(id, updateProductDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
