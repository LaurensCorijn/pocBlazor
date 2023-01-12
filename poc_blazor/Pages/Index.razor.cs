using Domain.Classes;
using Microsoft.AspNetCore.Components;
using poc_blazor.Shared.IServices;

namespace poc_blazor.Pages
{
    public partial class Index
    {
        [Inject] IProductService ProductService { get; set; }
        private IEnumerable<Product> products;
        private IEnumerable<Product> filteredProducts;

        protected override async Task OnInitializedAsync()
        {
            var response = await ProductService.GetProducts();
            products = response;
            filteredProducts = response;
        }

        private void OnSearchBalkChanged(ChangeEventArgs args)
        {
            if (args.Value != null && !args.Value.ToString().Equals(' '))
            {
                filteredProducts = products.Where(p => p.Name.Contains(args.Value.ToString())).ToList();
            } else
            {
                filteredProducts = products;
            }
            
        }
    }
}
