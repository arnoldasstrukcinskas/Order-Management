using Microsoft.EntityFrameworkCore;
using Order_Management.Data;

namespace Order_Management.Services
{
    public class OrderManagerServices : ProductServiceInterface
    {
        private AppDbContext _context;

        public OrderManagerServices(AppDbContext context)
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

        public Task<Product> DeleteProducts(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByName(string productName)
        {
            return _context.Products.FirstOrDefaultAsync(x => x.Name == productName);
        }

        public Task<Product> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product> AddDiscount(Product product)
        {
            throw new NotImplementedException();
        }

    }


}
