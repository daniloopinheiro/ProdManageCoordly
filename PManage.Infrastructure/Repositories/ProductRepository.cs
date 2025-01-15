using Microsoft.EntityFrameworkCore;
using PManage.Domain.Interfaces;
using PManage.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using PManage.Domain.Entities;  // For logging

namespace PManage.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        // Inject ILogger for better logging
        public ProductRepository(ApplicationDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.AsNoTracking().ToList();
        }

        public Product GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                _logger.LogWarning($"Product with ID {id} not found.");
            }
            return product;
        }

        public void Add(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error occurred while adding the product.");
                throw new InvalidOperationException("An error occurred while adding the product.", ex);
            }
        }

        public void Update(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error occurred while updating the product.");
                throw new InvalidOperationException("An error occurred while updating the product.", ex);
            }
        }

        public void Delete(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error occurred while deleting the product.");
                throw new InvalidOperationException("An error occurred while deleting the product.", ex);
            }
        }
    }
}
