using Microsoft.AspNetCore.Components;

namespace poc_blazor.Shared
{
    public partial class AccessControl
    {
        //Logout verwijdert iets en navigeert naar de homepagina.
        private bool _loggedIn;

        [Inject] NavigationManager _navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var token = await _localStorage.GetItemAsStringAsync("token");
            _loggedIn = token != null;
        }

        private async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");

            _navigationManager.NavigateTo("", forceLoad: true);
        }
    }
}
