using PManage.Application.DTOs;
using PManage.Domain.Entities;
using PManage.Domain.Interfaces;
using PManage.Application.Interfaces;

namespace PManage.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            var productDtos = products.Select(p => new ProductDto
            {
                ProductID = p.ProductID,
                Name = p.Name,
                Price = p.Price,
                StockQuantity = p.StockQuantity
            });

            return productDtos;
        }

        public void CreateProduct(CreateProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity
            };

            _productRepository.Add(product);
        }

        public void UpdateProduct(int productId, UpdateProductDto productDto)
        {
            var product = _productRepository.GetById(productId);
            if (product == null) throw new Exception("Product not found");

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.StockQuantity = productDto.StockQuantity;

            _productRepository.Update(product);
        }

        public void DeleteProduct(int productId)
        {
            var product = _productRepository.GetById(productId);
            if (product == null) throw new Exception("Product not found");

            _productRepository.Delete(product);
        }
    }
}
