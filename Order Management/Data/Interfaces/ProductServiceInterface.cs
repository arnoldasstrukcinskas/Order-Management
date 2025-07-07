using Order_Management.Data.Entity;

namespace Order_Management.Data
{
    public interface ProductServiceInterface
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProducts(Product product);
        Task<Product> GetProductByName(string productName);
        Task<List<Product>> GetProductsByName(string productsName);
    }
}
