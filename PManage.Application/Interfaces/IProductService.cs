using PManage.Application.DTOs;

namespace PManage.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        void CreateProduct(CreateProductDto productDto);
        void UpdateProduct(int productId, UpdateProductDto productDto);
        void DeleteProduct(int productId);
    }
}
