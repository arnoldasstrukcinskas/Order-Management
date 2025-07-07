using Microsoft.EntityFrameworkCore;
using Order_Management.Data;
using Order_Management.Data.Entity;

namespace Order_Management.Services
{
    public class ProductServices : ProductServiceInterface
    {
        private AppDbContext _context;

        public ProductServices(AppDbContext context)
        {
            _context = context;
        }

        public Task<Product> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Task.FromResult(product);
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteProducts(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChangesAsync();
            return Task.FromResult(product);
        }

        public Task<Product> GetProductByName(string productName)
        {
            return _context.Products.FirstOrDefaultAsync(x => x.Name == productName);
        }

        public Task<List<Product>> GetProductsByName(string productsName)
        {
            return _context.Products.Where(p => p.Name.Contains(productsName)).ToListAsync();
        }

        //public Task<List<Product>> GetProductsByName(string productsName)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<Product> AddDiscount(Product product)
        {
            throw new NotImplementedException();
        }

    }


}
