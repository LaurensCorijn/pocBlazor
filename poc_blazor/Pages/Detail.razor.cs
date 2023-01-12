using Domain.Classes;
using Microsoft.AspNetCore.Components;
using poc_blazor.Shared.IServices;

namespace poc_blazor.Pages
{
    public partial class Detail
    {
        private Product product;
        [Parameter] public int Id { get; set; }
        [Inject] IProductService ProductService { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await GetProductAsync();
        }

        private async Task GetProductAsync()
        {
            var response = await ProductService.GetProductById(Id);
            product = response;
        }
    }
}
