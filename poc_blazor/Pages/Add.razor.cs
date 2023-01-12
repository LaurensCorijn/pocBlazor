using Domain.Classes;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using poc_blazor.Shared.IServices;
using poc_blazor.Shared.DTO;

namespace poc_blazor.Pages
{
    public partial class Add
    {
        [Inject] public IProductService ProductService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }

        MudForm form;

        ProductDTO.Create model = new();

        protected override async Task OnInitializedAsync()
        {
            var token = await _localStorage.GetItemAsStringAsync("token");
            if (token == null)
            {
                Navigation.NavigateTo("login");
            }

            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Outlined;
        }

        private async Task CreateProductAsync()
        {
            model.Id = 1;
            bool succes = await ProductService.CreateProductAsync(model);
            if (succes)
            {
                Snackbar.Add("Product toegevoegd", Severity.Success);
                Navigation.NavigateTo("");
            }
            else
            {
                Snackbar.Add("Product couldn't be added", Severity.Error);
            }
        }
    }
}
