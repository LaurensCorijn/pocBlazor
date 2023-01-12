using Microsoft.AspNetCore.Components;
using MudBlazor;
using poc_blazor.Shared.DTO;
using poc_blazor.Shared.IServices;

namespace poc_blazor.Pages
{
    public partial class Login
    {
        [Inject] public IUserService UserService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }

        MudForm form;

        UserDTO.Login model = new();

        protected override async Task OnInitializedAsync()
        {
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Outlined;
        }

        private async Task LoginAsync()
        {
            bool succes = await UserService.LogIn(model);
            if (succes)
            {
                Snackbar.Add("Goed ingelogd", Severity.Success);
                Navigation.NavigateTo("");
            }
            else
            {
                Snackbar.Add("Couldn't login", Severity.Error);
            }
        }
    }
}
