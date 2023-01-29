using Microsoft.AspNetCore.Components;
using MudBlazor;
using poc_blazor.Shared.DTO;
using poc_blazor.Shared.IServices;

namespace poc_blazor.Pages
{
    public partial class Register
    {
        [Inject] public IUserService UserService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }

        UserDTO.Register model = new();

        protected override async Task OnInitializedAsync()
        {
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Outlined;
        }

        private async Task RegisterAsync()
        {
            model.UserName = model.Email;
            bool succes = await UserService.Register(model);
            if (succes)
            {
                Snackbar.Add("Succesfully registered", Severity.Success);
                Navigation.NavigateTo("", forceLoad: true);
            }
            else
            {
                Snackbar.Add("Couldn't register", Severity.Error);
            }
        }
    }
}
