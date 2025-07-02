namespace Order_Management.Data
{
    public interface ProductServiceInterface
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProducts(string name);
        Task<Product> GetProductByName(string productId);
        Task<Product> GetProductsByName(string name);
        Task<Product> AddDiscount(Product product);
    }
}
