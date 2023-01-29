using poc_blazor.Shared.Classes;
using poc_blazor.Shared.DTO;

namespace poc_blazor.Shared.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<bool> CreateProductAsync(ProductDTO.Create model);
            
    }
}
