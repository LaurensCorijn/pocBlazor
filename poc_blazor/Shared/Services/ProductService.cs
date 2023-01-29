using poc_blazor.Infrastructure;
using poc_blazor.Shared.Classes;
using System.Net.Http.Json;
using poc_blazor.Shared.IServices;
using poc_blazor.Shared.DTO;

namespace poc_blazor.Shared.Services
{
    public class ProductService : IProductService
    {
        private readonly PublicClient publicClient;
        private readonly HttpClient authClient;
        private const string endpoint = "api/product";

        public ProductService( PublicClient publicClient, HttpClient authClient)
        {
            this.publicClient = publicClient;
            this.authClient = authClient;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var response = await publicClient.Client.GetFromJsonAsync<IEnumerable<Product>>($"{endpoint}");
            return response;
        }

        public async Task<Product> GetProductById(int id)
        {
            var response = await publicClient.Client.GetFromJsonAsync<Product>($"{endpoint}/{id}");
            return response;
        }

        public async Task<bool> CreateProductAsync(ProductDTO.Create model)
        {
            var response = await authClient.PostAsJsonAsync(endpoint, model);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
